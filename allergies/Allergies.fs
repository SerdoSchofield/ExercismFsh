module Allergies

open System

// TODO: define the Allergen type
type Allergen = | Eggs          =1   //0x00000001
                | Peanuts       =2   //0x00000010
                | Shellfish     =4   //0x00000100
                | Strawberries  =8   //0x00001000
                | Tomatoes      =16  //0x00010000
                | Chocolate     =32  //0x00100000
                | Pollen        =64  //0x01000000
                | Cats          =128 //0x10000000


let allergicTo codedAllergies (allergen:Allergen) = codedAllergies &&& int allergen = int allergen

let list codedAllergies =
    let rec loop (i:int) (result:Allergen list) =
        printf $"{i} - {result}\n"
        if i = 0 then result
            else
            if codedAllergies &&& i = i
                then loop (i >>> 1) (enum<Allergen>(i) :: result)
                else loop (i >>> 1) result
    loop 128 []
