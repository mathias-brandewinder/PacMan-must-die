namespace PacMan

open System
open System.Windows
open System.Windows.Controls
open System.Windows.Input
open System.Windows.Media
open System.Windows.Media.Imaging

type Keys (control:Control) =
    #if SILVERLIGHT
    #else // WPF specific workaround
    do  control.Focusable <- true
    do  control.Focus() |> ignore
    #endif
    let mutable keysDown = Set.empty  
    do  control.KeyDown.Add (fun e -> e.Handled <- true; keysDown <- keysDown.Add e.Key)
    do  control.KeyUp.Add (fun e -> e.Handled <- true; keysDown <- keysDown.Remove e.Key)
    do  control.LostFocus.Add (fun _ -> keysDown <- Set.empty)
    member keys.IsKeyDown key = keysDown.Contains key

[<AutoOpen>]
module Rendering = 
    let run (control:Control) rate update =
        let rate = TimeSpan.FromSeconds(rate)
        let focus = ref true
        let pause = TimeSpan.FromSeconds(0.5)
        let lastUpdate = ref (DateTime.Now + pause)
        let residual = ref (TimeSpan.Zero)
        let gotFocus _ =
            focus := true
            let pause = TimeSpan.FromSeconds(0.5)
            lastUpdate := DateTime.Now + pause
            residual := TimeSpan.Zero
        let lostFocus _ = 
            focus := false
        let subscriptions = [
            #if SILVERLIGHT
            control.GotFocus.Subscribe(gotFocus)
            control.LostFocus.Subscribe(lostFocus)
            #else
            Application.Current.MainWindow.Activated.Subscribe(gotFocus)
            Application.Current.MainWindow.Deactivated.Subscribe(lostFocus)
            #endif
            CompositionTarget.Rendering.Subscribe (fun _ ->
                let now = DateTime.Now
                if now >= !lastUpdate then
                    residual := !residual + (now - !lastUpdate)
                    if !focus then
                        while !residual > rate do
                            update(); residual := !residual - rate
                    lastUpdate := now
            )]
        { new IDisposable with
            member this.Dispose() =
                subscriptions |> List.iter (fun d -> d.Dispose())
        }
    
[<AutoOpen>]
module Imaging =
    let createBitmap (width:int,height:int) (lines:int[][]) =
#if SILVERLIGHT
        let bitmap = WriteableBitmap(width, height)
        let pixels = bitmap.Pixels
        lines |> Seq.iteri (fun y line ->
            for x = 0 to width-1 do 
                pixels.[x+y*width] <- line.[x]
        )
        bitmap
#else
        let bitmap = WriteableBitmap(width, height, 300.0, 300.0, PixelFormats.Bgra32, null)
        lines |> Seq.iteri (fun y line ->
            bitmap.WritePixels(Int32Rect(0,0,width,1), line, width*4, 0 , y)
        )  
        bitmap
#endif
    let toBitmap (paint:Paint) (lines:int seq) =
        let lines = lines |> Seq.toArray
        let width, height = 8, lines.Length
        let white = paint.Color
        let black = 0x00000000
        let toColor = function true -> white | false -> black
        lines |> Array.mapi (fun y line ->
            Array.init width (fun x ->
                let bit = 1 <<< (width - 1 - x) 
                line &&& bit = bit |> toColor
            )
        )
        |> createBitmap (width,height)
    let toImage (bitmap:#BitmapSource) =
        let w, h = float bitmap.PixelWidth, float bitmap.PixelHeight  
        Image(Source=bitmap,Stretch=Stretch.Fill,Width=w,Height=h) 
    let loadBitmap path =
        #if SILVERLIGHT
        let stream = Application.GetResourceStream(new Uri(path, UriKind.Relative)).Stream
        let image = BitmapImage()
        image.SetSource(stream)
        #else
        let image = BitmapImage(Uri(path, UriKind.Relative))
        #endif
        image
    let loadImage path =
        path |> loadBitmap |> toImage

type Scene (canvas:Canvas) =
    let contents = Contents(canvas)
    interface IScene with
        member scene.AddLayer () = 
            let layer = Canvas()
            canvas.Children.Add(layer) |> ignore
            Layer(layer) :> ILayer
        member scene.LoadBitmap(path) = 
            let bitmap = loadBitmap path
            Bitmap(bitmap) :> IBitmap
        member scene.CreateBitmap(paint,lines) = 
            let bitmap = toBitmap paint lines
            Bitmap(bitmap) :> IBitmap
        member scene.CreateBitmap(width,height,lines) =
            let bitmap = createBitmap (width,height) lines
            Bitmap(bitmap) :> IBitmap
        member scene.CreateText(text:string) =
            let whiteBrush = SolidColorBrush Colors.White
            let block = 
                TextBlock(
                    FontFamily=FontFamily("Courier New"),
                    Foreground=whiteBrush, 
                    FontSize=15.0,
                    FontWeight=FontWeights.ExtraBold,
                    Text=text
                )
            TextContent(block) :> ITextContent
        member scene.Contents = contents :> IContents
and  Bitmap (source:BitmapSource) =
    interface IBitmap with
        member bitmap.CreateContent() =
            let w, h = float source.PixelWidth, float source.PixelHeight  
            let image = Image(Source=source,Stretch=Stretch.Fill,Width=w,Height=h)
            Content(image) :> IContent
and  Contents (canvas:Canvas) =
    inherit Content(canvas)
    let children = canvas.Children
    interface IContents with
        member contents.Add content = 
            children.Add(content.Control :?> UIElement) |> ignore
        member contents.Remove content = 
            children.Remove(content.Control :?> UIElement) |> ignore
        member contents.Contains content =
            children.Contains(content.Control :?> UIElement)
and  Layer (canvas:Canvas) =
    let content = Content(canvas) :> IContent
    let contents = Contents(canvas) :> IContents
    interface ILayer with
        member this.Move(x,y) = content.Move(x,y)
        member this.SetOpacity(value) = content.SetOpacity(value)
        member this.Control = canvas :> obj
        member this.Contents = contents
and  Content (element:UIElement) =
    interface IContent with
        member content.Move (x,y) =
            Canvas.SetLeft(element, x)
            Canvas.SetTop(element, y)
        member content.SetOpacity (value) = 
            element.Opacity <- value
        member content.Control = element :> obj
and  TextContent (block:TextBlock) =
    let content = Content(block) :> IContent
    interface ITextContent with
        member this.Move(x,y) = content.Move(x,y)
        member this.SetOpacity(value) = content.SetOpacity(value)
        member this.Control = block :> obj
        member this.SetText value = block.Text <- value
 
type GameControl () as control =
    inherit UserControl(Background=SolidColorBrush Colors.Black, IsTabStop=true)
    let keys = Keys(control)
    let width, height = 28.0 * 8.0, (32.0+3.0) * 8.0
    let grid = Grid(Background = SolidColorBrush Colors.Black)
    let canvas = Canvas(Background = SolidColorBrush Colors.Black)
    do  canvas.Width <- width; canvas.Height <- height
    let clip = RectangleGeometry(Rect=Rect(Width=canvas.Width,Height=canvas.Height))
    do  canvas.Clip <- clip
    let transform =
        ScaleTransform(
            ScaleX=1.0,
            ScaleY=1.0,
            CenterX=width/2.0,
            CenterY=height/2.0
        )
    do  canvas.RenderTransform <- transform
    do  grid.Children.Add(canvas) |> ignore
    do  control.Content <- grid
    let scene = Scene(canvas) :> IScene
    let input = 
        let up, down, left, right = Key.Up, Key.Down, Key.Left, Key.Right
        let pressed key = keys.IsKeyDown key
        { new IInput with
            member this.IsUp = pressed up
            member this.IsDown = pressed down
            member this.IsLeft = pressed left
            member this.IsRight = pressed right
        }
    let game = Game(scene, input)
    let start _ = run control (1.0/50.0) game.Update |> ignore
#if SILVERLIGHT
    do  if Application.Current.IsRunningOutOfBrowser then start()
        else
            let prompt = scene.CreateText("Click To Start")
            prompt.Move(6.0*8.0, 15.0*8.0)
            scene.Contents.Add(prompt)
            async { 
                do! control.MouseLeftButtonDown |> Async.AwaitEvent |> Async.Ignore
                scene.Contents.Remove(prompt)
                start ()
            } |> Async.StartImmediate
#else
    do  control.Loaded.Subscribe start |> ignore 
#endif
    override control.MeasureOverride(size) =
        let mutable scale = 1.0
        while (width * scale) < size.Width && 
              (height * scale) < size.Height do 
              scale <- scale + 0.5
        let scale = scale - 0.5
        let scale = if scale < 1.0 then 1.0 else scale 
        if transform.ScaleX <> scale then
            transform.ScaleX <- scale
            transform.ScaleY <- scale
        size

#if SILVERLIGHT
type App() as this =
    inherit Application()
    do  this.Startup.AddHandler(fun o e ->
            this.RootVisual <- GameControl()
        )
#else
module App =
    [<System.STAThread>]
    do  let win = new Window(Title="PacMan", Content=GameControl(), SizeToContent=SizeToContent.WidthAndHeight)
        (new Application()).Run(win) |> ignore
#endif
