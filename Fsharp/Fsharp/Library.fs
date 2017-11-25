module Library

let fibs = 
    let rec helper a b n =
        match n with
        | 0 -> b
        | _ when n > 0 -> helper b <| a + b <| n - 1
    helper 1 0 
    
let rev l =
    let rec helper l x =
        match x with
        | a::ax -> helper <| a::l <| ax
        | [] -> l
    helper [] l
    
let rec mergeSort l =
    let rec merge l1 l2 acc =
        match (l1, l2) with
        | (a::ax, b::bx) when a < b ->  merge ax l2 <| a :: acc
        | (a::ax, b::bx) -> merge l1 bx <| b :: acc
        | ([], _) -> rev acc @ l2
        | (_, []) -> rev acc @ l1 
        | (_, _) -> rev acc
    match l with
    | [] -> []
    | [a] -> [a]
    | _ -> 
        let a, b = List.splitAt <| List.length l / 2 <| l
        merge <| mergeSort a <| mergeSort b <| []
        
type Oper =
    | Val of int
    | Plus of Oper * Oper
    | Subt of Oper * Oper
    | Mult of Oper * Oper
    | Divi of Oper * Oper
    
let rec calc o =
    match o with
    | Val a -> a
    | Plus (a, b) -> calc a |> (+) <| calc b
    | Subt (a, b) -> calc a |> (-) <| calc b
    | Mult (a, b) -> calc a |> (*) <| calc b
    | Divi (a, b) -> calc a |> (/) <| calc b
    
let primes = Seq.initInfinite id |> Seq.filter (fun x -> x > 1 && 0 = (Seq.length <| Seq.filter (fun y -> x % y = 0) [2..x-1]))