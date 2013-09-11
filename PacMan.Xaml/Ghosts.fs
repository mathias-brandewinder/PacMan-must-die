namespace PacMan

module Ghosts =
    
    open System

    type Move = Up | Down | Left | Right

    let private rng = Random()

    let dirToMove (dx, dy) =
        match dx, dy with
        | 0,-1 -> Up
        | 0, 1 -> Down
        | -1,0 -> Left
        | 1, 0 -> Right
        | _, _ -> invalidOp ""

    let moveToDir move =
        match move with
        | Up    -> 0,-1
        | Down  -> 0, 1
        | Left  -> -1,0
        | Right -> 1, 0

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
        
    let decision (current: Move) (choices: Move Set) =
        let restricted = 
            choices 
            |> Set.filter (fun c -> not (c = backwards current))
        if (restricted |> Set.count > 0)
        then randomMove restricted
        else randomMove choices