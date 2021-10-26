module Parser

open FSharpCalculator
open MaybeBuilder
    
let Parse (args:string[]) =
    let maybe = MaybeBuilder()
    let checkArgsLength (args: string[]) =
        match args.Length with
        | 3 -> Ok args
        | _ -> Error "Wrong Arguments Count"
  
    let parseOperation (args: string[]) =
        maybe {
            let! operation = 
                match args.[1] with
                | "+" -> Ok '+'
                | "-" -> Ok '-'
                | "*" -> Ok '*'
                | "/" -> Ok '/'
                | _ -> Error "Wrong Operation"
            return args.[0], operation, args.[2] 
        }
    
    let parseArg number =
        try Ok (number |> decimal)
        with
        | _ -> Error "Wrong Argument"
    
    let parseArguments (arg1, operation, arg2) =
        maybe {
            let! parsedArg1 = parseArg arg1
            let! parsedArg2 = parseArg arg2
            return parsedArg1, operation, parsedArg2
        }
    
    let dividingByZeroCheck (arg1, operation, arg2) =
        match (operation, arg2) with
        | ('/', 0m) -> Error "Dividing By Zero"
        | _ -> Ok (arg1, operation, arg2)
    
    maybe {
        let! arguments = checkArgsLength args
        let! argsWithOperation = parseOperation arguments
        let! parsedArgs = parseArguments argsWithOperation
        let! checkedArgs = dividingByZeroCheck parsedArgs
        return checkedArgs
    }