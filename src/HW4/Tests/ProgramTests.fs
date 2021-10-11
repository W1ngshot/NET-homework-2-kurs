module Tests.ProgramTests

open Microsoft.VisualStudio.TestPlatform.TestHost
open Xunit
open FSharpCalculator

[<Theory>]
[<InlineData("14", "+", "3", 0)>]
[<InlineData("8", "-", "5", 0)>]
[<InlineData("a", "*", "2", 2)>]
[<InlineData("12", "+", "t", 2)>]
[<InlineData("14", "2", "2", 3)>]
[<InlineData("14", "a", "2", 3)>]
[<InlineData("1", "/", "0", 4)>]
let ``InputTests`` (arg1, operation, arg2, expectedResult) =
    let args = [|arg1; operation; arg2|]
    let actualResult = Program.main(args)
    Assert.Equal(actualResult, expectedResult)


[<Fact>]
let ``NotEnoughArgs`` () =
    let args = [|"1";"+"|]
    let actualResult = Program.main(args)
    let expectedResult = 1
    Assert.Equal(actualResult, expectedResult)
    