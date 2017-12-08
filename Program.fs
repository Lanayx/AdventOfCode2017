// Learn more about F# at http://fsharp.org

open System
open System.IO

[<EntryPoint>]
let main argv =
    let number = 347991
     

    let getSecondNumber firstPrev secondPrev (prevBucket: int[]) =
        firstPrev + secondPrev + prevBucket.[0] + prevBucket.[1]

    let getNextNumber prev (prevBucket: int[]) index =
        let mutable sum = prev + prevBucket.[index-2]
        if prevBucket.Length > index-1
        then
            sum <- sum + prevBucket.[index-1]
            if prevBucket.Length > index
            then
                sum <- sum + prevBucket.[index]       
        sum

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
        let fistArray = Array.zeroCreate(currentBucketSize)
        buckets.[0].Add(fistArray)
        let previousBucket = buckets.[0].[previousLevel]
        let secondNumber = getSecondNumber 0 0 previousBucket
        fistArray.[1] <- secondNumber
        for i in [2 .. (currentBucketSize-1)] do
            fistArray.[i] <- getNextNumber fistArray.[i-1] previousBucket i
        
        let sortedFirstArray = Array.sort fistArray
        match Array.tryFind(fun el -> el > number) sortedFirstArray with
        | Some a -> 
            currentElement <- a
            Console.WriteLine(a)
        | _ -> ()

        for j in [1..3] do
            let currentArray = Array.zeroCreate(currentBucketSize)
            buckets.[j].Add(currentArray)
            let previousBucket = buckets.[j].[previousLevel]
            let previousArray = buckets.[j-1].[currentLevel]
            currentArray.[0] <- previousArray.[previousArray.Length-1]
            currentArray.[1] <- getSecondNumber previousArray.[previousArray.Length-1] previousArray.[previousArray.Length-2] previousBucket
            for i in [2 .. (currentBucketSize-1)] do
                currentArray.[i] <- getNextNumber currentArray.[i-1] previousBucket i
            
            let sortedCurrentArray = Array.sort currentArray
            match Array.tryFind(fun el -> el > number) sortedCurrentArray with
            | Some a -> 
                currentElement <- a
                Console.WriteLine(a)
            | _ -> ()

        //Fill extra values
        buckets.[3].[currentLevel].[currentBucketSize-2] <- buckets.[3].[currentLevel].[currentBucketSize-2] + secondNumber
        if (buckets.[3].[currentLevel].[currentBucketSize-2] > number)
        then currentElement <- buckets.[3].[currentLevel].[currentBucketSize-2];  Console.WriteLine(buckets.[3].[currentLevel].[currentBucketSize-2]);

        buckets.[3].[currentLevel].[currentBucketSize-1] <- buckets.[3].[currentLevel].[currentBucketSize-1] + secondNumber*2
        fistArray.[0] <- buckets.[3].[currentLevel].[currentBucketSize-1]
        if (buckets.[3].[currentLevel].[currentBucketSize-1] > number)
        then currentElement <- buckets.[3].[currentLevel].[currentBucketSize-1];  Console.WriteLine(buckets.[3].[currentLevel].[currentBucketSize-1]);
 
            

        currentLevel <-currentLevel + 1
        currentBucketSize <- currentBucketSize + 2
        printfn "%A" buckets
        printfn "%A" (currentLevel-1)


    0
