// Learn more about F# at http://fsharp.org

open System
open System.IO

[<EntryPoint>]
let main argv =
    let number = 120
     

    let buckets = [| ResizeArray<int[]>();  ResizeArray<int[]>();  ResizeArray<int[]>();  ResizeArray<int[]>(); |]
    buckets.[0].Add([|25;1;2|]);
    buckets.[1].Add([|2;4;5|]);
    buckets.[2].Add([|5;10;11|]);
    buckets.[3].Add([|11;23;25|]);
    let mutable currentElement = 0;
    let mutable currentBucketSize = 5;
    let mutable currentLevel = 1;
    while currentElement < number do
        let previousLevel = currentLevel - 1
        //FIll first bucket        
        buckets.[0].Add([|0;
                          buckets.[0].[previousLevel].[0] + buckets.[0].[previousLevel].[0];
                          x4 / not 2 from end
                           |])

        currentElement <-2


    0
