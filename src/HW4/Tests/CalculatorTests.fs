module Tests.CalculatorTests

open Xunit
open FSharpCalculator

[<Theory>]
[<InlineData(12, '+', 5, 17)>]
[<InlineData(14, '-', 10, 4)>]
[<InlineData(10, '*', 2, 20)>]
[<InlineData(15, '/', 3, 5)>]
let ``CalculateTestsWithValidInput`` (arg1, operation, arg2, expectedValue) =
    let actualValue = Calculator.calculate arg1 operation arg2
    Assert.Equal(actualValue, expectedValue)