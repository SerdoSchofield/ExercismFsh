module QueenAttack

let isBetween (x: int) (minVal: int) (maxVal: int) =
    x >= minVal && x < maxVal

let create (position: int * int) = 
    match position with
    | (x, y) when (isBetween x 0 8) && x >= 0 &&
                  (isBetween y 0 8) && y >= 0 -> true
    | _ -> false

let isDiag (pos1: int * int) (pos2: int * int) =
    match pos1, pos2 with
    | (x, y), (x2, y2) when abs (x2 - x) = abs (y2 - y) -> true
    | _ -> false

let isHoriz (pos1: int * int) (pos2: int * int) =
    match pos1, pos2 with
    | (x, _), (x2, _) when x = x2 -> true
    | _ -> false

let isVert (pos1: int * int) (pos2: int * int) =
    match pos1, pos2 with
    | (_, y), (_, y2) when y = y2 -> true
    | _ -> false

let canAttack (queen1: int * int) (queen2: int * int) = 
    if (create queen1) && (create queen2) 
        then
            match queen1, queen2 with
            | _ when isDiag queen1 queen2 -> true
            | _ when isHoriz queen1 queen2 -> true
            | _ when isVert queen1 queen2 -> true
            | _ -> false
        else false