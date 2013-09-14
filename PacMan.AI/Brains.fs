namespace PacMan.AI

open PacMan
open PacMan.Core

type DefaultPacManAI () =
    
    interface IPacManAI with
        
        member this.Decide (current: Move) (power: int) (lineOfSight: Sight) (choices: Move Set) =
            let restricted = 
                choices 
                |> Set.filter (fun c -> not (c = backwards current))
            if (restricted |> Set.count > 0)
            then randomMove restricted
            else randomMove choices

        member this.Name () = "Default PacMan"
        
type DefaultGhostAI () =

    interface IGhostAI with
        // Decision is based on current move, line of sight and possible moves
        member this.Decide (current: Move) (lineOfSight: Sight) (choices: Move Set) =
            let restricted = 
                choices 
                |> Set.filter (fun c -> not (c = backwards current))
            if (restricted |> Set.count > 0)
            then randomMove restricted
            else randomMove choices

        member this.Name () = "Default Ghost"