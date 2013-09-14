namespace PacMan

module Brains =
    
    open System

    type Move = Up | Down | Left | Right

    type TileContent = Nothing | Wall | Power | Pill

    type Creature = PacMan of int | Ghost | WeakGhost

    type Sight = { 
        Up:    (TileContent * Creature list) list;
        Down:  (TileContent * Creature list) list;
        Left:  (TileContent * Creature list) list;
        Right: (TileContent * Creature list) list; }

    let rng = Random()

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
            
    let ghostDecision (current: Move) (lineOfSight: Sight) (choices: Move Set) =
        let restricted = 
            choices 
            |> Set.filter (fun c -> not (c = backwards current))
        if (restricted |> Set.count > 0)
        then randomMove restricted
        else randomMove choices

    let pacmanDecision (current: Move) (power: int) (lineOfSight: Sight) (choices: Move Set) =
        let restricted = 
            choices 
            |> Set.filter (fun c -> not (c = backwards current))
        if (restricted |> Set.count > 0)
        then randomMove restricted
        else randomMove choices
