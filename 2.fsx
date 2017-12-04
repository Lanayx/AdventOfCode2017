open System.IO
open System

File.ReadAllLines "2.txt"
    |> Array.map (fun str -> str.Split([|' ';'\t'|], StringSplitOptions.RemoveEmptyEntries))
    |> Array.map (fun arr -> Array.map Int32.Parse arr)
    |> Array.map (fun arr -> (Array.max arr) - (Array.min arr))
    |> Array.sum

//----------------------------------------
let rec canDivide number list =
    match list with
    | [] -> 0
    | h::_ when number % h = 0 -> number / h
    | _::tail -> canDivide number tail

let rec getDivisionResult (sortedList: int list) =
    let x = sortedList.Head
    let result = canDivide x sortedList.Tail
    match result with
    | 0 -> getDivisionResult sortedList.Tail
    | number -> number


File.ReadAllLines "2.txt"
    |> Array.map (fun str -> str.Split([|' ';'\t'|], StringSplitOptions.RemoveEmptyEntries))
    |> Array.map (Array.map Int32.Parse)
    |> Array.map (Array.sortDescending)
    |> Array.map (Array.toList)
    |> Array.map (fun list -> getDivisionResult list)
    |> Array.sum