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

    let pacManVisible options lineOfSight =
        let creaturesInDirection directionVector = directionVector |> List.collect snd
        let isVulerablePacman creature = match creature with
                                               | PacMan(power) -> power < 1
                                               | _ -> false
        let containsPacMan creatures = List.exists isVulerablePacman creatures

        if(Set.contains Up options && lineOfSight.Up |> creaturesInDirection |> containsPacMan) then Some Up
        else if(Set.contains Left options && lineOfSight.Left |> creaturesInDirection |> containsPacMan) then Some Left
        else if(Set.contains Down options && lineOfSight.Down |> creaturesInDirection |> containsPacMan) then Some Down
        else if(Set.contains Right options && lineOfSight.Right |> creaturesInDirection |> containsPacMan) then Some Right
        else None

    let ghostDecision (current: Move) (lineOfSight: Sight) (choices: Move Set) =
        let restricted =
            choices
            |> Set.filter (fun c -> not (c = backwards current))
        let options = if (restricted |> Set.count > 0)
                      then restricted
                      else choices
        let pacDirection = pacManVisible choices lineOfSight
        match pacDirection with
              | Some move -> move
              | None -> randomMove options

    let pacmanDecision (current: Move) (power: int) (lineOfSight: Sight) (choices: Move Set) =
        let restricted = 
            choices 
            |> Set.filter (fun c -> not (c = backwards current))
        if (restricted |> Set.count > 0)
        then randomMove restricted
        else randomMove choices
