// OUTPUT SAMPLE
// hello world
// can you
// what are you doing
module ``205-CleanUpTheWords``

open System
open System.IO

let filter (s : string) = 
    s |> String.map (fun c -> 
             if Char.IsLetter c then c
             else ' ')

let solve filename = 
    let testCases = File.ReadLines(filename)
    for test in testCases do
        if test |> String.IsNullOrEmpty then ()
        else 
            let filtered = test.ToLowerInvariant() |> filter
            filtered.Split([| ' ' |], StringSplitOptions.RemoveEmptyEntries)
            |> String.concat " "
            |> printfn "%s"
    0
#if INTERACTIVE

solve (sprintf "%s\%s" __SOURCE_DIRECTORY__ "205.txt")
#else
[<EntryPoint>]
let main (args) =
    solve args.[0]
#endif
