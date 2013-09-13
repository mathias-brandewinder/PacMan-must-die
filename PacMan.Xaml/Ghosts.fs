namespace PacMan

module Ghosts =
    
    open System
    open Board

    let private rng = Random()

    let dirToMove (dx: int<pix>, dy: int<pix>) =
        match dx, dy with
        | 0<pix>,-1<pix> -> Up
        | 0<pix>, 1<pix> -> Down
        | -1<pix>,0<pix> -> Left
        | 1<pix>, 0<pix> -> Right
        | _, _ -> invalidOp ""

    let moveToDir move =
        match move with
        | Up    -> 0<pix>,-1<pix>
        | Down  -> 0<pix>, 1<pix>
        | Left  -> -1<pix>,0<pix>
        | Right -> 1<pix>, 0<pix>

    let backwards move =
        match move with
        | Up -> Down
        | Down -> Up
        | Left -> Right
        | Right -> Left

    let randomMove (choices: Move Set) =
        let i = rng.Next(0, Set.count choices)
        choices 
        |> Set.toArray 
        |> fun c -> c.[i]
        
    let decision (current: Move) (lineOfSight: Sight) (choices: Move Set) =
        let restricted = 
            choices 
            |> Set.filter (fun c -> not (c = backwards current))
        if (restricted |> Set.count > 0)
        then randomMove restricted
        else randomMove choices