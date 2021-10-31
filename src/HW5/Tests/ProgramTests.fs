module Tests.ProgramTests

open Xunit
open FSharpCalculator

[<Theory>]
[<InlineData(1, '+', 3)>]
[<InlineData(7,  '-', 6)>]
[<InlineData(3, '*', 2)>]
[<InlineData(8, '/', 2)>]
let ``MainWithValidArgs`` (arg1, op, arg2) =
    let args = [|arg1; op; arg2|]
    let expectedResult = 0
    let actualResult = Program.main args
    Assert.Equal(expectedResult, actualResult)

[<Theory>]
[<InlineData(1, '0', 3)>]
[<InlineData("a",  '-', 6)>]
[<InlineData(3, '*', "b")>]
[<InlineData(8, '/', 0)>]
let ``MainWithInvalidArgs`` (arg1, op, arg2) =
    let args = [|arg1; op; arg2|]
    let expectedResult = 1
    let actualResult = Program.main args
    Assert.Equal(expectedResult, actualResult)