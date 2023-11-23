module KindergartenGarden

// TODO: define the Plant type
type Plant = Radishes='R' | Clover='C' | Violets='V' | Grass='G'

let plants (diagram: string) (student: string) = 
    [for row in diagram.Split("\n".ToCharArray()) ->
        row.Substring((int student.[0] - int 'A') * 2, 2).ToCharArray()] |>
    Array.concat |>
    Array.map (fun c -> Microsoft.FSharp.Core.LanguagePrimitives.EnumOfValue<char, Plant>(c)) |>
    Array.toList
