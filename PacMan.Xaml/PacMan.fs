namespace PacMan

open PacMan.Ghosts
open PacMan.Board

[<AutoOpen>]
module Algorithm =
    let flood canFill fill (x,y) =
        let rec f n = function
            | [] -> ()
            | ps ->
                let ps = ps |> List.filter canFill
                ps |> List.iter (fill n)
                ps |> List.collect (fun (x,y) -> [(x-1,y);(x+1,y);(x,y-1);(x,y+1)])
                |> f (n+1)
        f 0 [(x,y)]

module Seq =
    let private rand = System.Random()
    let unsort xs =
        xs
        |> Seq.map (fun x -> rand.Next(),x)
        |> Seq.cache
        |> Seq.sortBy fst
        |> Seq.map snd
    // Workaround for issue in VS11(RC) running in F# Portable library from C# Metro App
    let sortBy f xs = 
        System.Linq.Enumerable.OrderBy(xs,System.Func<_,_>(f))
        |> Seq.readonly



type Game(scene:IScene, input:IInput) =
    let createText text = scene.CreateText(text)
    let toBitmap color lines = scene.CreateBitmap(color,lines)
    let toImage (bitmap:IBitmap) = bitmap.CreateContent()
    let load s =
        let w,h,lines = Images.nameToValue |> Seq.find (fst >> (=) s) |> snd
        scene.CreateBitmap(w,h,lines).CreateContent()
    let add item = scene.Contents.Add(item)
    let remove item = scene.Contents.Remove(item)
    let contains item = scene.Contents.Contains(item)
    let set (element:IContent) (x: int<pix>, y: int<pix>) = element.Move(x - 16<pix> |> float, y + 8<pix> |> float)
    let maze = "
##/------------7/------------7##
##|............|!............|##
##|./__7./___7.|!./___7./__7.|##
##|o|  !.|   !.|!.|   !.|  !o|##
##|.L--J.L---J.LJ.L---J.L--J.|##
##|..........................|##
##|./__7./7./______7./7./__7.|##
##|.L--J.|!.L--7/--J.|!.L--J.|##
##|......|!....|!....|!......|##
##L____7.|L__7 |! /__J!./____J##
#######!.|/--J LJ L--7!.|#######
#######!.|!          |!.|#######
#######!.|! /__==__7 |!.|#######
-------J.LJ |      ! LJ.L-------
########.   | **** !   .########
_______7./7 |      ! /7./_______
#######!.|! L______J |!.|#######
#######!.|!          |!.|#######
#######!.|! /______7 |!.|#######
##/----J.LJ L--7/--J LJ.L----7##
##|............|!............|##
##|./__7./___7.|!./___7./__7.|##
##|.L-7!.L---J.LJ.L---J.|/-J.|##
##|o..|!.......<>.......|!..o|##
##L_7.|!./7./______7./7.|!./_J##
##/-J.LJ.|!.L--7/--J.|!.LJ.L-7##
##|......|!....|!....|!......|##
##|./____JL__7.|!./__JL____7.|##
##|.L--------J.LJ.L--------J.|##
##|..........................|##
##L--------------------------J##"

    let tops = [
        0b00000000, 0b00000000, 0b00000000
        0b00000000, 0b00000000, 0b00000000
        0b00000000, 0b00000000, 0b00000000
        0b00000000, 0b00000000, 0b00000000
        0b00000011, 0b11111111, 0b11000000
        0b00000100, 0b00000000, 0b00100000
        0b00001000, 0b00000000, 0b00010000
        0b00001000, 0b00000000, 0b00010000]
    let mids = [
        0b00001000, 0b00000000, 0b00010000
        0b00001000, 0b00000000, 0b00010000
        0b00001000, 0b00000000, 0b00010000
        0b00001000, 0b00000000, 0b00010000
        0b00001000, 0b00000000, 0b00010000
        0b00001000, 0b00000000, 0b00010000
        0b00001000, 0b00000000, 0b00010000
        0b00001000, 0b00000000, 0b00010000]
    let bots = [
        0b00001000, 0b00000000, 0b00010000
        0b00001000, 0b00000000, 0b00010000
        0b00000100, 0b00000000, 0b00100000
        0b00000011, 0b11111111, 0b11000000
        0b00000000, 0b00000000, 0b00000000
        0b00000000, 0b00000000, 0b00000000
        0b00000000, 0b00000000, 0b00000000
        0b00000000, 0b00000000, 0b00000000]
    let door' = [
        0b00000000
        0b00000000
        0b00000000
        0b00000000
        0b11111111
        0b00000000
        0b00000000
        0b00000000]
    let pill' = [
        0b00000000
        0b00000000
        0b00000000
        0b00011000
        0b00011000
        0b00000000
        0b00000000
        0b00000000]
    let power' = [
        0b00000000
        0b00011000
        0b00111100
        0b01111110
        0b01111110
        0b00111100
        0b00011000
        0b00000000]

    let fromTriple xs = 
        let convert = toBitmap Paint.Blue
        List.foldBack (fun (l,m,r) (ls,ms,rs) -> l::ls, m::ms, r::rs) xs ([],[],[])
        |> fun (l,m,r) -> convert l, convert m, convert r

    let tl, top, tr         = fromTriple tops
    let left, blank, right  = fromTriple mids
    let bl, bottom, br      = fromTriple bots
    let door = toBitmap Paint.White door'
    let pill = toBitmap Paint.Yellow pill'
    let power = toBitmap Paint.Yellow power'

    let toTile c =
        match c with
        | '=' -> door
        | '_' -> top
        | '|' -> left
        | '!' -> right
        | '/' -> tl
        | '7' -> tr
        | 'L' -> bl
        | 'J' -> br
        | '-' -> bottom
        | '.' -> pill
        | 'o' -> power
        | _ -> blank

    let isEdible = function '.' | 'o' -> true | _ -> false
    let mutable totalDots = 0
    let walls = scene.AddLayer()
    let lines = maze.Split('\n')
    let tiles =
        lines |> Array.mapi (fun y line ->
            line.ToCharArray() |> Array.mapi (fun x item ->
                let tile = toTile item |> toImage
                set tile (x * TileSize, y * TileSize)
                if isEdible item then totalDots <- totalDots + 1
                if isWall item 
                then walls.Contents.Add tile |> ignore
                else scene.Contents.Add tile |> ignore
                tile
            )
        )

    // wrap up all state in one function
    let tileFrom = Board.tileAnalyzer lines scene tiles

    let route_home =
        let numbers =
            lines |> Array.map (fun line ->
                line.ToCharArray() 
                |> Array.map (fun c -> if isWall c then System.Int32.MaxValue else -1)
            )
        let canFill (x,y) =
            y>=0 && y < numbers.Length &&
            x>=0 && x < numbers.[y].Length &&
            numbers.[y].[x] = -1
        let fill n (x,y) = numbers.[y].[x] <- n
        flood canFill fill (16,16)
        numbers

    let p = load "p"
    let pu = load "pu1", load "pu2"
    let pd = load "pd1", load "pd2"
    let pl = load "pl1", load "pl2"
    let pr = load "pr1", load "pr2"
    
    let mutable finished = false
    let mutable lives = [for _ in 1..9 -> load "pl1"]
    do  lives |> List.iteri (fun i life -> add life; set life (16<pix> + 16<pix> * i, (32*8<pix>)))
    do  lives <- lives |> List.rev
    let decLives () =
        lives <-
            match lives with
            | [] -> 
                let text = createText "GAME OVER"
                set text (12 * TileSize, 15 * TileSize)
                add text
                finished <- true
                []
            | x::xs -> 
                remove x
                xs

    let ghost_starts = 
        [
            "red", (16, 16), (1<pix>, 0<pix>)
            "cyan", (14, 16), (1<pix>, 0<pix>)
            "pink" , (16, 14), (0<pix>, -1<pix>)
            "orange" , (18, 16), (-1<pix>, 0<pix>)
        ]
        |> List.map (fun (color,(x,y),v) -> 
            let blue = load "blue"
            let eyes = load "eyeu", load "eyed", load "eyel", load "eyer"
            let body = load (color+"u"), load (color+"d"), load (color+"l"), load (color+"r")
            let _,image,_,_ = body
            { Blue=blue; Eyes=eyes; Body=body; X=x * TileSize - 7<pix>; Y = y * TileSize - 3<pix>; V=v; Image=image; IsReturning=false }
        )
    let mutable ghosts = ghost_starts
    do  ghosts |> List.iter (fun ghost -> 
        add ghost.Image
        set ghost.Image (ghost.X,ghost.Y)
        )

    let mutable score = 0
    let mutable bonus = 0
    let mutable bonuses = []
    let x = ref (16 * TileSize - 7<pix>)
    let y = ref (24 * TileSize - 3<pix>)
    let v = ref (0<pix>, 0<pix>)
    let pacman = ref p
    do  add !pacman
    do  set !pacman (!x,!y)
    let mutable powerCount = 0

    let fillValue (x: int<pix>, y: int<pix>) (ex: int<pix>, ey: int<pix>) =
        let bx, by = tileFromPix (x + ex, y + ey)
        route_home.[by].[bx]

    let verticallyAligned (x,y) = x % TileSize = 5<pix>
    let horizontallyAligned (x,y) = y % TileSize = 5<pix>

    let canGoUp (x,y) = verticallyAligned (x,y) && noWall lines (x,y) Up
    let canGoDown (x,y) = verticallyAligned (x,y) && noWall lines (x,y) Down
    let canGoLeft (x,y) = horizontallyAligned (x,y) && noWall lines (x,y) Left
    let canGoRight (x,y) = horizontallyAligned (x,y) && noWall lines (x,y) Right

    let fillUp (x,y) = fillValue (x,y) (0<pix>, -4<pix>)
    let fillDown (x,y) = fillValue (x,y) (0<pix>,5<pix>)
    let fillLeft (x,y) = fillValue (x,y) (-4<pix>,0<pix>)
    let fillRight (x,y) = fillValue (x,y) (5<pix>,0<pix>)

    let go (x: int<pix>, y: int<pix>) (dx: int<pix>, dy: int<pix>) =
        let x = 
            if   dx = -1<pix> && x = 0<pix> then 30 * TileSize
            elif dx = 1<pix>  && x = 30 * TileSize then 0<pix>
            else x
        x + dx, y + dy

    let newGhosts () =
        ghosts |> List.map (fun ghost ->

            let pacman = (!x, !y, powerCount)
            let view = lineOfSight tileFrom pacman ghosts (ghost.X, ghost.Y)

            let x, y = ghost.X, ghost.Y
            let dx, dy = ghost.V
            let u,d,l,r = ghost.Body
            let u',d',l',r' = ghost.Eyes

            let face, eye =
                match dx, dy with
                | 0<pix>,-1<pix> -> u, u'
                | 0<pix>, 1<pix> -> d, d'
                | -1<pix>,0<pix> -> l, l'
                | 1<pix>, 0<pix> -> r, r'
                | _, _ -> invalidOp ""
            
            let possible =                        
                [   if canGoUp (x,y) then yield Up
                    if canGoDown (x,y) then yield Down
                    if canGoLeft (x,y) then yield Left
                    if canGoRight(x,y) then yield Right ]
            
            let fill move =
                match move with
                | Up -> fillUp (x,y)
                | Down -> fillDown (x,y)
                | Left -> fillLeft (x,y)
                | Right -> fillRight (x,y)

            let directions =
                if ghost.IsReturning then
                    possible
                    |> Seq.sortBy fill
                    |> Seq.head
                    |> moveToDir
                else
                    possible
                    |> Set.ofList
                    |> decision (ghost.V |> dirToMove) view
                    |> fun d -> 
                        if (possible |> Set.ofSeq |> Set.contains d) 
                        then d 
                        else randomMove (possible |> Set.ofSeq)
                    |> moveToDir

            let dx, dy = directions
            let x,y = go (x,y) (dx,dy)
            let returning =
                if ghost.IsReturning && 0 = (fillValue (x,y) (0<pix>,0<pix>))
                then false
                else ghost.IsReturning
            remove ghost.Image
            let face = 
                if ghost.IsReturning then eye
                else
                    if powerCount > 0 then ghost.Blue else face
            add face
            set face (x,y)
            { ghost with X = x; Y = y; V = (dx,dy); Image = face; IsReturning = returning }
        )

    let mutable ghostCounter = 0

    let updateGhosts () = 
        let modulus = if powerCount > 0 then 4 else 16
        if ghostCounter % modulus <> 0 then
            ghosts <- newGhosts ()
        ghostCounter <- ghostCounter + 1

    let updatePacman () =
        let inputs = 
            [
            if input.IsUp then yield canGoUp (!x,!y), (0<pix>,-1<pix>), pu
            if input.IsDown then yield canGoDown (!x,!y), (0<pix>,1<pix>), pd
            if input.IsLeft  then yield canGoLeft (!x,!y), (-1<pix>,0<pix>), pl
            if input.IsRight then yield canGoRight (!x,!y), (1<pix>,0<pix>), pr
            ] 
        let move ((dx,dy),(d1,d2)) =
            let x', y' = go (!x,!y) (dx,dy)
            x := x'; y := y'; v := (dx,dy)
            remove !pacman
            let d = if (!x/6<pix> + !y/6<pix>) % 2 = 0 then d1 else d2
            add d
            pacman := d
        let availableDirections =
            inputs
            |> List.filter (fun (can,_,_) -> can)
            |> List.map (fun (_,v,f) -> v,f)
            |> Seq.sortBy (fun (v',_) -> v' = !v)
        if Seq.length availableDirections > 0 then
            availableDirections |> Seq.head |> move
        else
            let goForward =
                match !v with
                | 0<pix>,-1<pix> -> canGoUp(!x,!y), pu
                | 0<pix>,1<pix>  -> canGoDown(!x,!y), pd
                | -1<pix>,0<pix> -> canGoLeft(!x,!y), pl
                | 1<pix>, 0<pix> -> canGoRight(!x,!y), pr
                | 0<pix>, 0<pix> -> false, pu
                | _ -> invalidOp ""
            if fst goForward && inputs.Length > 0 then
                (!v, snd goForward) |> move 

        let tx, ty = tileFromPix(!x, !y)

        match tileFrom (tx, ty) with
        | Pill ->
            score <- score + 10
            remove (tiles.[ty].[tx])
            totalDots <- totalDots - 1
        | Power -> 
            score <- score + 50
            powerCount <- 500
            bonus <- 0
            totalDots <- totalDots - 1
            remove (tiles.[ty].[tx])
        | _ -> ignore ()

        set !pacman (!x,!y)
        if totalDots = 0 then
            let text = createText "LEVEL COMPLETED"
            set text (7 * TileSize, 15 * TileSize)
            add text
            finished <- true

    let updatePower () =
        if powerCount > 0 then
            if (powerCount/5) % 2 = 1 then walls.SetOpacity(0.5)
            else walls.SetOpacity(1.0)
        else walls.SetOpacity(1.0)
        powerCount <- powerCount - 1

    let mutable flashCount = 0

    let updateFlash () =
        if flashCount > 0 then
            if ((flashCount / 5) % 2) = 1 then (!pacman).SetOpacity(0.5)
            else (!pacman).SetOpacity(1.0)
            flashCount <- flashCount - 1
        else (!pacman).SetOpacity(1.0)

    let touchGhosts () =
        let px, py = !x, !y
        ghosts |> List.filter (fun ghost ->
            let x,y = ghost.X, ghost.Y
            ((px >= x && px < x + 13<pix>) ||
             (x < px + 13<pix> && x >= px)) &&
            ((py >= y && py < y + 13<pix>) ||
             (y < py + 13<pix> && y >= py))
        )

    let handleTouching () =
        let touching = touchGhosts()
        if touching.Length > 0 then
            if powerCount > 0 
            then ghosts <- ghosts |> List.mapi (fun i ghost ->
                if not ghost.IsReturning && 
                   touching |> List.exists ((=) ghost)
                then
                    score <- score + (pown 2 bonus) * 200 
                    let b = load ([|"200";"400";"800";"1600"|]).[bonus]
                    set b (ghost.X, ghost.Y)
                    add b
                    bonuses <- (100,b) :: bonuses
                    bonus <- min 3 (bonus + 1)
                    { ghost with IsReturning = true; }
                else ghost
            )
            else
                if flashCount = 0 then
                    decLives()
                    flashCount <- 30

    let updateBonuses () =
        let removals,remainders =
            bonuses 
            |> List.map (fun (count,x) -> count-1,x)
            |> List.partition (fst >> (=) 0)
        bonuses <- remainders
        removals |> List.iter (fun (_,x) -> remove x)

    let p1 = createText("SCORE")
    do  p1.Move(0.0,0.0); scene.Contents.Add(p1)
    let s1 = createText("")
    do  s1.Move(5.0*8.0,0.0); scene.Contents.Add(s1)

    let updateScore () =
        s1.SetText(sprintf "%7d" score)

    do  updateScore ()

    let update () =
        updatePacman ()
        updateGhosts ()
        handleTouching ()
        updateFlash ()
        updatePower ()
        updateBonuses ()
        updateScore ()

    member this.Update () = 
        if not finished then update ()