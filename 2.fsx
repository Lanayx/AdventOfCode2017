open System.IO
open System

File.ReadAllLines "2.txt"
    |> Array.map (fun str -> str.Split([|' ';'\t'|], StringSplitOptions.RemoveEmptyEntries))
    |> Array.map (fun arr -> Array.map Int32.Parse arr)
    |> Array.map (fun arr -> (Array.max arr) - (Array.min arr))
    |> Array.sum