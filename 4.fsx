open System
open System.IO

let result = File.ReadLines(__SOURCE_DIRECTORY__ + "\4.txt")
                |> Seq.map (fun line ->
                    let initialArray = line.Split(' ') 
                    let newArray = initialArray |> Array.distinct
                    initialArray.Length = newArray.Length)
                |> Seq.countBy (fun result -> result)
printfn "%A" result
