namespace PacMan

type Paint(aarrggbb:int) =
    static member White = Paint(0xFFFFFFFF)
    static member Black = Paint(0x00000000)
    static member Blue = Paint(0xFF0000FF)
    static member Yellow = Paint(0xFFFFFF00)
    static member Transparent = Paint(0x00FFFFFF)
    member this.Color = aarrggbb 

type IScene =
    abstract member AddLayer : unit -> ILayer
    abstract member CreateBitmap : Paint * int seq -> IBitmap
    abstract member CreateBitmap : int * int * int[][] -> IBitmap
    abstract member LoadBitmap : string -> IBitmap
    abstract member CreateText : string -> ITextContent
    abstract member Contents : IContents
and  IContents = 
    abstract member Add : IContent -> unit
    abstract member Remove : IContent -> unit
    abstract member Contains: IContent -> bool
and IContent =
    abstract member Control : obj
    abstract member Move : float * float -> unit
    abstract member SetOpacity : float -> unit
and IBitmap =
    abstract member CreateContent : unit -> IContent
and ILayer =
    inherit IContent
    abstract member Contents : IContents
and ITextContent =
    inherit IContent
    abstract member SetText: string -> unit

type IInput =
    abstract member IsUp : bool
    abstract member IsDown : bool
    abstract member IsLeft : bool
    abstract member IsRight : bool

[<Measure>] type pix

module Board =

    let TileSize = 8<pix>

    type Move = Up | Down | Left | Right

    type TileContent = Nothing | Wall | Power | Pill

    let tileFromPix (x:int<pix>, y:int<pix>) = 
        int ((x + 6<pix>) / TileSize), 
        int ((y + 6<pix>) / TileSize)

    let isWall = function
        | '_' | '|' | '!' | '/' | '7' | 'L' | 'J' | '-' | '*' -> true
        | _ -> false
    
    let contains (scene: IScene) (item: IContent) = scene.Contents.Contains(item)

    let tileAt (board: string []) x y =
        if x < 0 || x > 30 then Nothing
        else 
            let symbol = board.[y].[x]
            if symbol = '.' then Pill
            elif symbol = 'o' then Power
            elif (isWall symbol) then Wall
            else Nothing

    let noWall (board: string []) (x, y) move =
        let tx, ty =
            match move with
            | Up    -> tileFromPix (x, y - 4<pix>)
            | Down  -> tileFromPix (x, y + 5<pix>)
            | Left  -> tileFromPix (x - 4<pix>, y)
            | Right -> tileFromPix (x + 5<pix>, y)
        tileAt board tx ty = Wall |> not     