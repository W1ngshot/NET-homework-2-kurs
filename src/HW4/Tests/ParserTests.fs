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
        let a = Parser.tryParse [|"a";"*";"1"|]
        printf $"{a.ToString()}"
    let action = Action actualValue
    Assert.Throws<Exceptions.WrongArgument>(action)

[<Fact>]
let ``WrongSecondArg`` () =
    let actualValue () =
        let a = Parser.tryParse [|"41";"/";"t"|]
        printf $"{a.ToString()}"
    let action = Action actualValue
    Assert.Throws<Exceptions.WrongArgument>(action)

[<Fact>]
let ``WrongOperation`` () =
    let actualValue () =
        let a = Parser.tryParse [|"3";"b";"10"|]
        printf $"{a.ToString()}"
    let action = Action actualValue
    Assert.Throws<Exceptions.WrongOperation>(action)

[<Fact>]
let ``Dividing by Zero`` () =
    let actualValue () =
        let a = Parser.tryParse [|"4";"/";"0"|]
        printf $"{a.ToString()}"
    let action = Action actualValue
    Assert.Throws<Exceptions.DividingByZero>(action)
   
[<Fact>] 
let ``NotEnough`` () =
    let actualValue () =
        let a = Parser.tryParse [|"4";"/"|]
        printf $"{a.ToString()}"
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
    
    