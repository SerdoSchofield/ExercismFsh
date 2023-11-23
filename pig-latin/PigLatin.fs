module PigLatin

open System

let vowels = ['a';'e';'i';'o';'u']

let translate (input:string) = 
    let rec loop (words:string list) res =
        match words with
        | head::tail when vowels |> List.contains head.[0] -> loop tail ((head + "ay")::res)
        | head::tail when head.[..1] = "qu" -> loop tail ((head.[2..] + head.[..1] + "ay")::res)
        | head::tail -> loop tail ((head.[1..] + string head.[0] + "ay")::res)
        | _ -> res
    loop (input.Split(' ') |> Array.toList) [] |> String.concat " "