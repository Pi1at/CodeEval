// OUTPUT SAMPLE
// 100 250 150
// 13 25 70 44
// 100 200 300 400 500
module ``208-FindTheHighestScore``

open System
open System.IO

let participants (s : string) = s.Split([| " | " |], StringSplitOptions.RemoveEmptyEntries)
let scores (s : string) = s.Split([| ' ' |], StringSplitOptions.RemoveEmptyEntries) |> Array.map int
let findmax (m : 'a [] []) = Array.fold (Array.map2 max) m.[0] m

let solve filename = 
    let testCases = File.ReadLines(filename)
    for test in testCases do
        if test |> String.IsNullOrEmpty then ()
        else 
            test
            |> participants
            |> Array.map scores
            |> findmax
            |> Array.iter (printf "%i ")
            printfn ""
    0
#if INTERACTIVE

solve (sprintf "%s\%s" __SOURCE_DIRECTORY__ "208.txt")
#else
[<EntryPoint>]
let main (args) =
    solve args.[0]
#endif
