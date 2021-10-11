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
        | Exceptions.WrongArgsCount exceptionNumber -> printfn "Wrong Arguments Count"; exceptionNumber
        | Exceptions.WrongArgument exceptionNumber -> printfn "Wrong Argument"; exceptionNumber
        | Exceptions.WrongOperation exceptionNumber -> printfn "Wrong Operation"; exceptionNumber
        | Exceptions.DividingByZero exceptionNumber -> printfn "Dividing By Zero"; exceptionNumber