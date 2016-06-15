// OUTPUT SAMPLE
// 14:44:45 09:53:27 02:26:31
// 21:25:41 05:33:44
module ``214-TimeToEat``

open System
open System.IO

let toTime (d : DateTime) = d.ToLongTimeString()
let timestamps (s : string) = s.Split([| ' ' |], StringSplitOptions.RemoveEmptyEntries) |> Array.map DateTime.Parse

let solve filename = 
    let testCases = File.ReadLines(filename)
    for test in testCases do
        if test |> String.IsNullOrEmpty then ()
        else 
            test
            |> timestamps
            |> Array.sortDescending
            |> Array.map toTime
            |> Array.iter (printf "%s ")
            printfn ""
    0
#if INTERACTIVE

solve (sprintf "%s\%s" __SOURCE_DIRECTORY__ "214.txt")
#else
[<EntryPoint>]
let main (args) =
    solve args.[0]
#endif
