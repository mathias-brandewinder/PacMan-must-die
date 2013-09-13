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

type Ghost = {
    Blue : IContent
    Eyes : IContent * IContent * IContent * IContent
    Body : IContent * IContent * IContent * IContent
    Image : IContent
    X : int<pix>
    Y : int<pix>
    V : int<pix> * int<pix>
    IsReturning : bool
    }

module Board =

    let TileSize = 8<pix>

    type Move = Up | Down | Left | Right

    type TileContent = Nothing | Wall | Power | Pill

    type Creature = Nobody | PacMan of int | Ghost | WeakGhost

    type TileAt = (int * int) -> TileContent

    type Sight = { 
        Up:    (TileContent * Creature list) list;
        Down:  (TileContent * Creature list) list;
        Left:  (TileContent * Creature list) list;
        Right: (TileContent * Creature list) list; }

    let tileFromPix (x:int<pix>, y:int<pix>) = 
        int ((x + 6<pix>) / TileSize), 
        int ((y + 6<pix>) / TileSize)

    let isWall = function
        | '_' | '|' | '!' | '/' | '7' | 'L' | 'J' | '-' | '*' -> true
        | _ -> false
    
    let contains (scene: IScene) (item: IContent) = scene.Contents.Contains(item)

            
        
    let tileAt (board: string []) x y =
        if x < 0 || x > 30 
        then Nothing
        else 
            let symbol = board.[y].[x]
            if symbol = '.' then Pill
            elif symbol = 'o' then Power
            elif (isWall symbol) then Wall
            else Nothing

    let tileAnalyzer (board: string []) (scene: IScene) (tiles: IContent [][]) =
        fun (x: int, y: int) ->
            if x < 0 || x > 30 
            then Nothing
            else 
                let symbol = board.[y].[x]
                if (isWall symbol) then Wall
                elif symbol = '.' then 
                    if scene.Contents.Contains(tiles.[y].[x])
                    then Pill
                    else Nothing
                elif symbol = 'o' then 
                    if scene.Contents.Contains(tiles.[y].[x])
                    then Power
                    else Nothing                    
                else Nothing
            
    let creaturesAt pacman (ghosts: Ghost seq) (x, y) =
        [   let px, py, power = pacman
            if tileFromPix (px, py) = (x, y) then yield PacMan(power)
            for ghost in ghosts do
                if tileFromPix (ghost.X, ghost.Y) = (x, y)
                then
                    if ghost.IsReturning 
                    then yield WeakGhost 
                    else yield Ghost ]

    let noWall (board: string []) (x, y) move =
        let tx, ty =
            match move with
            | Up    -> tileFromPix (x, y - 4<pix>)
            | Down  -> tileFromPix (x, y + 5<pix>)
            | Left  -> tileFromPix (x - 4<pix>, y)
            | Right -> tileFromPix (x + 5<pix>, y)
        tileAt board tx ty = Wall |> not     

    let lineOfSight (at: TileAt) pacman ghosts (x: int<pix>, y: int<pix>) =
        let X, Y = tileFromPix (x, y)
        let rec search line (x, y) (dx, dy) =
            let x = 
                if x + dx > 30 then 0
                elif x + dx < 0 then 30
                else x + dx
            let y = y + dy
            let tile = at (x, y)
            let creatures = creaturesAt pacman ghosts (x, y)
            let line' = (tile, creatures) :: line            
            if tile = Wall then line' else search line' (x, y) (dx, dy)

        let up = search [] (X, Y) (0, -1) |> List.rev
        let down = search [] (X, Y) (0, 1) |> List.rev
        let left = search [] (X, Y) (-1, 0) |> List.rev
        let right = search [] (X, Y) (1, 0) |> List.rev

        { Up = up; Down = down; Left = left; Right = right; }