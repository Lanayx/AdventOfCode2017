open System
let number = 347991.0

let root = (int) (Math.Ceiling(Math.Sqrt(number)))
let numbersInRow =  if root%2 = 0 then (root+ 1) else root
let circle = (numbersInRow - 1)/2

let shortStep = circle * 2
let start = (numbersInRow-2)*(numbersInRow-2)
let firstShortPath = start+shortStep/2
let shortPaths = [firstShortPath ; firstShortPath+shortStep; firstShortPath+shortStep*2;  firstShortPath+shortStep*3]
let distances = shortPaths |> List.map (fun num -> Math.Abs(num - (int)number))
let result = circle + List.min distances
result

//----------------------------

