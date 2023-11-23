module RobotSimulator

type Direction = North=0 | East=1 | South=2 | West=3
type Position = int * int
type Robot = { direction: Direction; position: Position }

let create (direction:Direction) (position:Position) = { direction=direction; position=position }

let rec realDirection direction = if direction >= 0 then enum<Direction>(direction % 4) else realDirection ((4 + direction) % 4)

let changeDirection (direction:Direction) amount = realDirection (int direction + amount)

let advance {direction=direction; position=(x, y);} =
    match direction with
    | Direction.North -> (x, y + 1)
    | Direction.South -> (x, y - 1)
    | Direction.East -> (x + 1, y)
    | Direction.West -> (x - 1, y)
    | _ -> (x, y)
        

let rec move (instructions:string) (robot:Robot) = 
    let {direction=direction; position=position} = robot
    if (instructions = "")
        then
            robot
        else
            match instructions.[0] with 
            | 'R' -> move (instructions.Substring 1) (create (changeDirection direction 1) position)
            | 'L' -> move (instructions.Substring 1) (create (changeDirection direction -1) position)
            | 'A' -> move (instructions.Substring 1) (create direction (advance robot))
            | _ -> move (instructions.Substring 1) robot