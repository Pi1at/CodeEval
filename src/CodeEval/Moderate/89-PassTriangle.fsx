﻿// MAX SUM FOR ALL PATH !!!!  NOT GREEDY
module ``89-PassTriangle``

open System
open System.IO

let parse (s : string) = s.Split([| ' ' |], StringSplitOptions.RemoveEmptyEntries) |> Array.map int

let maxSum triangle = 
    triangle
    |> Array.rev
    |> Array.tail
    |> Array.fold (fun state row -> row |> Array.mapi (fun idx v -> v + max (state.[idx]) (state.[idx + 1]))) 
           (triangle |> Array.last)
    |> Array.head

let solve filename = 
    let triangle = 
        filename
        |> File.ReadLines
        |> Seq.map parse
        |> Array.ofSeq
    printfn "%i" <| maxSum triangle
    0
#if INTERACTIVE

solve (sprintf "%s\%s" __SOURCE_DIRECTORY__ "89.txt")
#else
[<EntryPoint>]
let main (args) =
    solve args.[0]
#endif