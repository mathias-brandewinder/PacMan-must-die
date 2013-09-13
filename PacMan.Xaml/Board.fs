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

module Board =

    let TileSize = 8

    type Tile = Nothing | Wall | Power | Pill

    let tileFromPix (x, y) = 
        int ((x + 6) / TileSize), 
        int ((y + 6) / TileSize)

    let isWall = function
        | '_' | '|' | '!' | '/' | '7' | 'L' | 'J' | '-' | '*' -> true
        | _ -> false
    
    let tileAt (board: string []) x y =
        if x < 0 || x > 30 then Nothing
        else 
            let symbol = board.[y].[x]
            if symbol = '.' then Pill
            elif symbol = 'o' then Power
            elif (isWall symbol) then Wall
            else Nothing