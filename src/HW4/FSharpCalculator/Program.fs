namespace FSharpCalculator
module Program =
    [<EntryPoint>]
    let main argv =
        try
            let val1, operation, val2 = Parser.tryParse argv
            let result = Calculator.calculate val1 operation val2
            printfn $"{result}"
            0
        with
        | Exceptions.WrongArgsCount -> printfn "Wrong Arguments Count"; 1
        | Exceptions.WrongArgument  -> printfn "Wrong Argument"; 2
        | Exceptions.WrongOperation  -> printfn "Wrong Operation"; 3
        | Exceptions.DividingByZero  -> printfn "Dividing By Zero"; 4