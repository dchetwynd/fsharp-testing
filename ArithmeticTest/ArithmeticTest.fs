namespace ArithmeticTest

open NUnit.Framework
open Arithmetic

[<TestFixture>]
type ArithmeticTests() = 
    [<Test>]
    member x.ZeroIsAdditionIdentity() =
        let result = add 4 0
        Assert.That(result, Is.EqualTo 4)

    [<Test>]
    member x.CanAddTwoNumbers() =
        let result = add 2 5
        Assert.That(result, Is.EqualTo 7)

    [<Test>]
    member x.OneIsMultiplicationIdentity() =
        let result = multiply 1 3
        Assert.That(result, Is.EqualTo 3)

    [<Test>]
    member x.CanMultiplyTwoNumbers() =
        let result = multiply 4 5
        Assert.That(result, Is.EqualTo 20)