module SpaceAge

let standardYear = 1.0
let standardYearInDays = 365.25
let standardYearInSecs = 31557600L

let yearToDays y = y * standardYearInDays / standardYear
let yearToSecs y = y * (float standardYearInSecs) / standardYear

type Planet(years) = 
    member this.Years = years
    member this.Days = yearToDays years
    member this.Secs = yearToSecs years


let Mercury = new Planet(0.2408467)
let Venus = new Planet(0.61519726)
let Earth = new Planet(1.0)
let Mars = new Planet(1.8808158)
let Jupiter = new Planet(11.862615)
let Saturn = new Planet(29.447498)
let Uranus = new Planet(84.016846)
let Neptune = new Planet(164.79132)


let age (planet: Planet) (seconds: int64): float = (float seconds) / planet.Secs