module Library

let fibs = 
    let rec helper a b n =
        match n with
        | 0 -> b
        | n when n > 0 -> helper b <| a + b <| n - 1
        | _ -> invalidArg "n" "should be nonnegative"
    helper (bigint 1) (bigint 0) 
    
let rev l = 
    let rec helper l x =
        match x with
        | a::ax -> helper <| a::l <| ax
        | [] -> l
    helper [] l
    
let rec mergeSort l =
    let rec merge l1 l2 acc =
          if (List.isEmpty l1) 
          then (rev acc @ l2)
          else if (List.isEmpty l2)
          then (rev acc @ l1)
          else if (List.head l1 < List.head l2)
          then (merge (List.tail l1) l2 <| (List.head l1) :: acc)
          else (merge l1 (List.tail l2) <| (List.head l2) :: acc)
    match l with
    | [] -> []
    | [a] -> [a]
    | _ -> 
        let a, b = List.splitAt <| List.length l / 2 <| l
        merge <| mergeSort a <| mergeSort b <| []
        
type Oper<'a> =
    | Val of 'a
    | Plus of Oper<'a> * Oper<'a>
    | Subt of Oper<'a> * Oper<'a>
    | Mult of Oper<'a> * Oper<'a>
    | Divi of Oper<'a> * Oper<'a>
    
let rec calc o =
    match o with
    | Val a -> a
    | Plus (a, b) -> calc a |> (+) <| calc b
    | Subt (a, b) -> calc a |> (-) <| calc b
    | Mult (a, b) -> calc a |> (*) <| calc b
    | Divi (a, b) -> calc a |> (/) <| calc b
    
let primes = Seq.initInfinite id |> Seq.filter (fun x -> x > 1 && 0 = (Seq.length <| Seq.filter (fun y -> x % y = 0) (seq [2..(float x |> sqrt |> int)])))
