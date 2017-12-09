open System
open System.IO
open System.Linq

let result = File.ReadLines(__SOURCE_DIRECTORY__ + "\4.txt")
                |> Seq.map (fun line ->
                    let initialArray = line.Split(' ') 
                    let newArray = initialArray |> Array.distinct
                    initialArray.Length = newArray.Length)
                |> Seq.countBy (fun result -> result)
printfn "%A" result
//-----------------------------------

let isLineValid (line: string) = 
    let initialArray = line.Split(' ')
                        |> Array.map (fun elem -> String(elem.ToCharArray() |> Array.sort) )
    let newArray = initialArray |> Array.distinct
    initialArray.Length = newArray.Length

let result2 = File.ReadLines(__SOURCE_DIRECTORY__ + "\4.txt")
                |> Seq.map (fun line -> isLineValid line)
                |> Seq.countBy (fun result -> result)
printfn "%A" result2