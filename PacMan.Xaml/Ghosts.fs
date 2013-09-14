namespace PacMan

module Ghosts =
    
    open System
    open Board
    open Brains

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

    let pacManVisible options lineOfSight =
        let creaturesInDirection directionVector = directionVector |> List.collect snd
        let containsPacMan creatures = match List.tryFind (fun c -> match c with
                                                                    | int -> true
                                                                    | _ -> false) creatures with
                                       | Some value -> true
                                       | None -> false

        if(Set.contains Up options && lineOfSight.Up |> creaturesInDirection |> containsPacMan) then Some Up
        else if(Set.contains Left options && lineOfSight.Left |> creaturesInDirection |> containsPacMan) then Some Left
        else if(Set.contains Down options && lineOfSight.Down |> creaturesInDirection |> containsPacMan) then Some Down
        else if(Set.contains Right options && lineOfSight.Right |> creaturesInDirection |> containsPacMan) then Some Right
        else None

        let restricted =
            choices
        let options = if (restricted |> Set.count > 0)
                      then restricted
                      else choices
        let pacDirection = pacManVisible options lineOfSight
        match pacDirection with
              | Some move -> move
              | None -> randomMove options
