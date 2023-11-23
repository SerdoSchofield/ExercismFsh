module BeerSong

open System.Text.RegularExpressions

let capitalize s = Regex.Replace(s, "^.", fun m -> m.ToString().ToUpper())

let bottles count = match count with | 1 -> "1 bottle" | 0 -> "no more bottles" | _ -> $"{count} bottles"
let pronoun count = if count = 1 then "it" else "one"

let ofBeer = "of beer"
let ofBeerOnWall = $"{ofBeer} on the wall"
let actionWithBottle count = if (count > 0) then $"Take {pronoun count} down and pass it around" else $"Go to the store and buy some more"
let verse count nextCount : string list = [$"{bottles count |> capitalize} {ofBeerOnWall}, {bottles count} {ofBeer}.";
                                           $"{actionWithBottle count}, {bottles nextCount} {ofBeerOnWall}."] 

let recite (startBottles: int) (takeDown: int) = 
            // 10                    10 - 9 = 1
    [for i = startBottles downto startBottles - takeDown + 1 do //(if startBottles - takeDown > 0 then startBottles - takeDown else 0) do 
        match i with
        | 0 -> verse i 99
        | _ -> verse i (i - 1)
        if i > startBottles - takeDown + 1 && i > 0 then [""]
    ] |> List.concat