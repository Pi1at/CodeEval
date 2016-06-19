module ``4-SumOfPrimes``

let findNextPrime ps = 
    let lastprime = 
        match List.tryHead ps with
        | Some n -> n
        | None -> 1
    
    let isPrime candidate = ps |> List.forall (fun x -> candidate % x <> 0)
    
    let rec loop nc = 
        if isPrime nc then nc
        else loop (nc + 2)
    loop (lastprime + 2)

let primes n = 
    assert (n >= 0)
    let rec build (pr : int list) = 
        if pr.Length >= n then pr
        else build ((findNextPrime pr) :: pr)
    if n > 2 then build [ 3; 2 ]
    else List.skip (2 - n) [ 3; 2 ]

let solve() = 
    primes 1000
    |> List.sum
    |> printfn "%i"
    0
#if INTERACTIVE

solve()
#else
[<EntryPoint>]
let main (args) =
    solve ()
#endif
