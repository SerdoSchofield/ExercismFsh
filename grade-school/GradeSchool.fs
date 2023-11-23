module GradeSchool

type School = Map<int, string list>

let empty: School = Map.empty

let add (student: string) (grade: int) (school: School): School = 
    school |> Map.change grade (fun kids -> match kids with | Some ks -> Some (student :: ks) | None -> Some [student]);;


let roster (school: School): string list = school |> Map.toList |>  List.collect (fun (_, v) -> v |> List.sort)

let grade (number: int) (school: School): string list = 
    match school.TryGetValue number with
    | true, students -> students |> List.sort
    | _ -> []
