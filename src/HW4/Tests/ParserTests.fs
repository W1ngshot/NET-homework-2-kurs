module Tests.ParserTests

open System
open Xunit
open FSharpCalculator
open Xunit
open Xunit
open Xunit

[<Fact>]
let ``WrongFirstArg`` () =
    let actualValue () =
        Parser.tryParse [|"a";"*";"1"|] |> ignore
    let action = Action actualValue
    Assert.Throws<Exceptions.WrongArgument>(action)

[<Fact>]
let ``WrongSecondArg`` () =
    let actualValue () =
        Parser.tryParse [|"41";"/";"t"|] |> ignore
    let action = Action actualValue
    Assert.Throws<Exceptions.WrongArgument>(action)

[<Fact>]
let ``WrongOperation`` () =
    let actualValue () =
        Parser.tryParse [|"3";"b";"10"|] |> ignore
    let action = Action actualValue
    Assert.Throws<Exceptions.WrongOperation>(action)

[<Fact>]
let ``Dividing by Zero`` () =
    let actualValue () =
        Parser.tryParse [|"4";"/";"0"|] |> ignore
    let action = Action actualValue
    Assert.Throws<Exceptions.DividingByZero>(action)
   
[<Fact>] 
let ``NotEnough`` () =
    let actualValue () =
        Parser.tryParse [|"4";"/"|] |> ignore
    let action = Action actualValue
    Assert.Throws<Exceptions.WrongArgsCount>(action)

[<Theory>]
[<InlineData("2",'+',"3", 2, '+', 3)>]
[<InlineData("7", "-", "2", 7, '-', 2)>]
[<InlineData("10", "/", "5", 10, '/', 5)>]
[<InlineData("20", ":", "10", 20, '/', 10)>]
[<InlineData("5", "*", "3", 5, '*', 3)>]
let ``InputIsCorrect`` (val1, op, val2, expVal1, expOp, expVal2) =
    let arg = [|val1; op; val2|]
    let arg1, operation, arg2 = Parser.tryParse(arg)
    Assert.Equal(arg1, expVal1)
    Assert.Equal(operation, expOp)
    Assert.Equal(arg2, expVal2)
    
    