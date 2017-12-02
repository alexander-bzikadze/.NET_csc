open NUnit.Framework
open FsUnit
open FsCheck
open Library

fibs 1 |> should equal 1
fibs 2 |> should equal 1
fibs 3 |> should equal 2
fibs 4 |> should equal 3
fibs 5 |> should equal 5
fibs 6 |> should equal 8
fibs 7 |> should equal 13

let rec fibinit = seq {
    yield 0
    yield 1
    yield! Seq.map2 (+) fibinit (fibinit |> Seq.skip 1)
    }
    
let listsShouldBeEqual x y = x |> should equal y
let evaluateAndIgnore = Seq.toList >> ignore

Seq.initInfinite id |> Seq.map fibs |> Seq.map2 listsShouldBeEqual <| fibinit 
|> Seq.take 30 |> evaluateAndIgnore
   
Check.Quick <| fun l -> (List.rev l) = (Library.rev l)

Seq.map  <| fun l -> (List.sort l) = (Library.mergeSort l) 
<| Seq.ofList [[]; [1]; [1;2]; [2;1]; [3;2;1]; [1;2;3]; [5;4;3;2;1]]
|> Seq.map (should be True) |> evaluateAndIgnore

calc <| Plus ((Val 1), (Val 2)) |> should equal 3
calc <| Subt ((Val 1), (Val 2)) |> should equal -1
calc <| Mult ((Val 1), (Val 2)) |> should equal 2
calc (Divi ((Val 4), (Val 2))) |> should equal 2

Seq.take 10 primes |> Seq.map2 listsShouldBeEqual <| Seq.ofList [2; 3; 5; 7; 11; 13; 17; 19; 23; 29]
|> evaluateAndIgnore
