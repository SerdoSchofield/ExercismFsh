module Raindrops

let convert (number: int): string = 
    //let mutable res = ""
    let retVal = 
        (if number % 3 = 0 then "Pling" else "") //res <- res + "Pling"
        +
        (if number % 5 = 0 then "Plang" else "") //res <- res + "Plang"
        +
        (if number % 7 = 0 then "Plong" else "") //res <- res + "Plong"
    if retVal = "" then string number else retVal //res <- string number 
    //res
    