open Library

printfn "%d" <| fibs 1
printfn "%d" <| fibs 2
printfn "%d" <| fibs 3
printfn "%d" <| fibs 4
printfn "%d" <| fibs 5

printfn "%A" <| rev [1;2;3;4;5;6]
printfn "%A" <| rev [1;2;3;6;5;4]

printfn "%A" <| mergeSort [6;5;4;3;2;1]
printfn "%A" <| mergeSort [1;2;3;6;5;4;3]

printfn "%i" <| calc (Plus ((Val 1), (Val 2)))

printfn "%A" <| Seq.take 10 primes
