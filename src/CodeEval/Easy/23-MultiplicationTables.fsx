// OUTPUT SAMPLE
//1   2   3   4   5   6   7   8   9  10  11  12
//2   4   6   8  10  12  14  16  18  20  22  24
//3   6   9  12  15  18  21  24  27  30  33  36
module ``23-MultiplicationTables``

open System
open System.IO

let solve() = 
    for x in 1..12 do
        for y in 1..12 do
            printf "%4i" (x * y)
        printfn ""
    0
#if INTERACTIVE

solve()
#else
[<EntryPoint>]
let main (args) =
    solve ()
#endif
