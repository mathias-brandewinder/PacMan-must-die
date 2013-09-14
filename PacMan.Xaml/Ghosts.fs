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