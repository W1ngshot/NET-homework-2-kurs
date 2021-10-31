module Tests.CalculatorTests

open Xunit
open FSharpCalculator

[<Theory>]
[<InlineData(1, '+', 3, 4)>]
[<InlineData(7,  '-', 6, 1)>]
[<InlineData(3, '*', 2, 6)>]
[<InlineData(8, '/', 2, 4)>]
let ``intTests`` (val1:decimal, op, val2:decimal, expectedResult) =
    let actual = Calculator.calculate (val1, op, val2)
    Assert.Equal(expectedResult, actual)

[<Theory>]
[<InlineData(5, '+', 4, 9)>]
[<InlineData(5,  '-', 4, 1)>]
[<InlineData(5, '*', 4, 20)>]
[<InlineData(10, '/', 2, 5)>]
let ``floatTests`` (val1, op, val2, expectedResult) =
    let actual = Calculator.calculate (val1, op, val2)
    Assert.Equal(expectedResult, actual)

[<Theory>]
[<InlineData(5, '+', 4, 9)>]
[<InlineData(5,  '-', 4, 1)>]
[<InlineData(5, '*', 4, 20)>]
[<InlineData(10, '/', 2, 5)>]
let ``doubleTests`` (val1, op, val2, expectedResult) =
    let actual = Calculator.calculate (val1, op, val2)
    Assert.Equal(expectedResult, actual)