module Clock

let hoursInDay = 24
let minsInHour = 60
let minsInDay = hoursInDay * minsInHour

let rec realHour hour = if hour >= 0 then hour % hoursInDay else realHour (hoursInDay + hour) % hoursInDay

let rec realClock clock = if clock >= 0 then clock % minsInDay else realClock (minsInDay + clock) % minsInDay

let create hours minutes = realClock ((realHour hours) * 60 + minutes)

let add minutes clock = realClock (clock + minutes)

let subtract minutes clock = realClock (clock - minutes)

let hoursFromMin minutes = minutes / 60

let display clock = 
    let hours = realHour (hoursFromMin clock)
    let mins = clock % 60
    $"{hours:D2}:{mins:D2}"
