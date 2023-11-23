module OcrNumbers

let numMap = Map.empty
                .Add([[0;1;0];
                      [1;0;1];
                      [1;1;1]], "0")
                .Add([[0;0;0];
                      [0;0;1];
                      [0;0;1]], "1")
                .Add([[0;1;0];
                      [0;1;1];
                      [1;1;0]], "2")
                .Add([[0;1;0];
                      [0;1;1];
                      [0;1;1]], "3")
                .Add([[0;0;0];
                      [1;1;1];
                      [0;0;1]], "4")
                .Add([[0;1;0];
                      [1;1;0];
                      [0;1;1]], "5")
                .Add([[0;1;0];
                      [1;1;0];
                      [1;1;1]], "6")
                .Add([[0;1;0];
                      [0;0;1];
                      [0;0;1]], "7")
                .Add([[0;1;0];
                      [1;1;1];
                      [1;1;1]], "8")
                .Add([[0;1;0];
                      [1;1;1];
                      [0;1;1]], "9")

let serialize input = [for line in input |> List.take 3 -> 
                        [for c in line ->
                            if c = ' '
                                then 0
                                else 1]]

let convertSingle input = 
    //printf $"{input} - "
    let code = serialize input
    //printf $"{code}\n"
    match numMap.TryGetValue code with
    | true, value -> Some value
    | _ when code.Length = 3 &&
             code.[0].Length = 3 && 
             code.[1].Length = 3 && 
             code.[2].Length = 3 -> Some "?"
    | _ -> None

let display (resultList:option<string> list) = resultList |> 
                                                List.map (fun (item:option<string>) -> if item.IsSome then item.Value else "") |>
                                                String.concat ""

let convertRow (input:string list) = 
    let rec loop (x:string) (y:string) (z:string) result =
        printf $"{result}\n"
        if x = "" then result
            else loop x.[3..] y.[3..] z.[3..] ((convertSingle [x.[..3]; y.[..3]; z.[..3]])::result)
    match loop input.[0] input.[1] input.[2] [] with 
    | row when row |> List.contains None -> None
    | row -> row |> List.rev |> Some

let convert (input:string list) =
    if input.Length % 4 > 0 || input.[0].Length % 3 > 0 then None
    else
        let rec loop rows result =
            if List.isEmpty(rows) then result
               else loop (rows |> List.skip 4) ((convertRow (rows |> List.take 4))::result)
        match loop input [] with
            | rows when rows |> List.contains None -> None
            | rows -> rows |>
                        List.rev |>
                        List.map (fun row -> row.Value) |>
                        List.map display |>
                        String.concat "," |>
                        Some