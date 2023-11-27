module SumOfMultiples

let sum (numbers: int list) (upperBound: int): int =
    let lowerBound = match numbers.IsEmpty with | true -> 0 | false -> numbers |> List.sort |> List.head
    let rec loop x res =
        match x < upperBound with
        | true -> (match (numbers 
                            |> List.map (fun y -> y > 0 && x % y = 0) 
                            |> List.contains true) with
                    | true -> loop (x + 1) (res |> Set.add x)
                    | _ -> loop (x + 1) res)
        | _ -> res
    (loop lowerBound Set.empty) |> Set.toList |> List.sum
   
let result = sum [] 20