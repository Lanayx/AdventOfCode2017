// Learn more about F# at http://fsharp.org

open System
open System.IO

[<EntryPoint>]
let main argv =
    let number = 120
    let resultList = ResizeArray<int>()


    let getCornerSum i (numbersInRow: int) =
        let step = numbersInRow - 1
        let start = (numbersInRow - 2)*(numbersInRow - 2)
        let stepsFromStartCirlce = (i - start) / step
        let stepsOnPreviousCircle = 4 - stepsFromStartCirlce
        let previousCircleStart = (numbersInRow - 4)*(numbersInRow - 4)
        let previousCornerIndex = previousCircleStart + stepsOnPreviousCircle*(step/2)
        let isCornerLastCorner = i = numbersInRow*numbersInRow

        let result = resultList.[i-2]+ resultList.[previousCornerIndex-1]
        if (not isCornerLastCorner)
        then result
        else result + resultList.[previousCornerIndex]

    let isCorner (i: int) (numbersInRow: int) =
        let lastCorner = numbersInRow*numbersInRow
        let step = numbersInRow - 1
        i = lastCorner || i = lastCorner-step || i = lastCorner-step*2 || i = lastCorner-step*3

    let calc2 (i: int) lastSum =
        let root = (int) (Math.Ceiling(Math.Sqrt((float)i)))
        let numbersInRow =  if root%2 = 0 then (root+ 1) else root

        match i with
        | x when isCorner x numbersInRow -> getCornerSum x numbersInRow
        | x -> getRegularSum x numbersInRow


    let rec loop i sum= 
      if sum < number then 
        let currentSum = match i with
                          | x when x = 0 -> 1
                          | x when x <= 6 -> calc1 x
                          | x -> calc2 x currentSum
        resultList.Add(currentSum)
        loop (i + 1) currentSum
      else sum

    loop 1 1    
    

    0
