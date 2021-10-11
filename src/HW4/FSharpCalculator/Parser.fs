module Parser

    let tryParse (args:string[]) =
        if args.Length <> 3 then
            raise (Exceptions.WrongArgsCount)
        let arg1 =
            try
                args.[0] |> double
            with
                | _ -> raise (Exceptions.WrongArgument)
        let operation =
            match args.[1] with
            | "+" -> '+'
            | "-" -> '-'
            | "*" -> '*'
            | "/" -> '/'
            | ":" -> '/'
            | _ -> raise (Exceptions.WrongOperation)
        let arg2 =
            try
                args.[2] |> double
            with
                | _ -> raise (Exceptions.WrongArgument)
        if operation = '/' && arg2 = 0.0 then
            raise (Exceptions.DividingByZero)
        arg1, operation, arg2