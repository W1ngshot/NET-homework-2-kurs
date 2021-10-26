module Tests.ParserTests

open FSharpCalculator
open Xunit

[<Theory>]
[<InlineData("2",'+',"3", 2, '+', 3)>]
[<InlineData("7", "-", "2", 7, '-', 2)>]
[<InlineData("10", "/", "5", 10, '/', 5)>]
[<InlineData("5", "*", "3", 5, '*', 3)>]
let ``InputIsCorrect`` (val1, op, val2, expVal1, expOp, expVal2) =
    let arg = [|val1; op; val2|]
    let actualResult = Parser.Parse(arg)
    let expectedResult = Ok(decimal expVal1, expOp, decimal expVal2)
    Assert.Equal(actualResult, expectedResult)

[<Theory>]    
[<InlineData("10", "/")>]
[<InlineData("5", "*")>]
let ``WrongArgsCount`` (val1, op) =
    let arg = [|val1; op|]
    let actualResult = Parser.Parse(arg)
    let expectedResult = Error("Wrong Arguments Count")
    Assert.Equal(actualResult, expectedResult)
    
[<Theory>]    
[<InlineData("10", "a", "3")>]
[<InlineData("5", "^", "1")>]
let ``WrongOperation`` (val1, op, val2) =
    let arg = [|val1; op; val2|]
    let actualResult = Parser.Parse(arg)
    let expectedResult = Error("Wrong Operation")
    Assert.Equal(actualResult, expectedResult)
    
[<Theory>]    
[<InlineData("10", "/", "0")>]
[<InlineData("5", "/", "0")>]
let ``DividingByZero`` (val1, op, val2) =
    let arg = [|val1; op; val2|]
    let actualResult = Parser.Parse(arg)
    let expectedResult = Error("Dividing By Zero")
    Assert.Equal(actualResult, expectedResult)
    
[<Theory>]    
[<InlineData("c", "+", "2")>]
[<InlineData("5", "+", "*")>]
let ``WrongArgument`` (val1, op, val2) =
    let arg = [|val1; op; val2|]
    let actualResult = Parser.Parse(arg)
    let expectedResult = Error("Wrong Argument")
    Assert.Equal(actualResult, expectedResult)