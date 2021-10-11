module Parser

    let tryParse (args:string[]) =
        if args.Length <> 3 then
            raise (Exceptions.WrongArgsCount 1)
        let arg1 =
            try
                args.[0] |> double
            with
                | _ -> raise (Exceptions.WrongArgument 2)
        let operation =
            match args.[1] with
            | "+" -> '+'
            | "-" -> '-'
            | "*" -> '*'
            | "/" -> '/'
            | ":" -> '/'
            | _ -> raise (Exceptions.WrongOperation 3)
        let arg2 =
            try
                args.[2] |> double
            with
                | _ -> raise (Exceptions.WrongArgument 2)
        if operation = '/' && arg2 = 0.0 then
            raise (Exceptions.DividingByZero 4)
        arg1, operation, arg2