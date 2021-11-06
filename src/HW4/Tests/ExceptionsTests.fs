module Tests.ExceptionsTests

open Exceptions
open Xunit

[<Fact>]
let ``WrongArgumentHashCode`` () =
    let wrongArgHashCode = Exceptions.WrongArgument.GetHashCode()
    let wrongArgHashCode2 = Exceptions.WrongArgument.GetHashCode()
    Assert.Equal(wrongArgHashCode, wrongArgHashCode2)
    
[<Fact>]
let ``WrongArgsCountHashCode`` () =
    let wrongCountHashCode = Exceptions.WrongArgsCount.GetHashCode()
    let wrongCountHashCode2 = Exceptions.WrongArgsCount.GetHashCode()
    Assert.Equal(wrongCountHashCode, wrongCountHashCode2)

[<Fact>]
let ``WrongOperationHashCode`` () =
    let wrongOperationHashCode = Exceptions.WrongOperation.GetHashCode()
    let wrongOperationHashCode2 = Exceptions.WrongOperation.GetHashCode()
    Assert.Equal(wrongOperationHashCode, wrongOperationHashCode2)

[<Fact>]
let ``DividingByZeroHashCode`` () =
    let dividingByZeroHashCode = Exceptions.DividingByZero.GetHashCode()
    let dividingByZeroHashCode2 = Exceptions.DividingByZero.GetHashCode()
    Assert.Equal(dividingByZeroHashCode, dividingByZeroHashCode2)
    
[<Fact>]
let ``WrongArgumentEquals`` () =
    let result = Exceptions.WrongArgument.Equals(Exceptions.WrongArgument)
    Assert.True(result)
    
[<Fact>]
let ``WrongArgsCountEquals`` () =
    let result = Exceptions.WrongArgsCount.Equals(Exceptions.WrongArgsCount)
    Assert.True(result)
    
[<Fact>]
let ``WrongOperationEquals`` () =
    let result = Exceptions.WrongOperation.Equals(Exceptions.WrongOperation)
    Assert.True(result)

[<Fact>]
let ``DividingByZeroEquals`` () =
    let result = Exceptions.DividingByZero.Equals(Exceptions.DividingByZero)
    Assert.True(result)