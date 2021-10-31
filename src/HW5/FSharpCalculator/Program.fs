namespace FSharpCalculator

open FSharpCalculator.MaybeBuilder

module Program =
    [<EntryPoint>]
    let main argv =
        let maybe = MaybeBuilder()
        let result = maybe {
            let! parsedArgs = Parser.Parse argv
            let res = Calculator.calculate parsedArgs
            return res
        }
        match result with
        | Ok answer ->
            printfn $"{answer}"
            0
        | Error error ->
            printf $"{error}"
            1