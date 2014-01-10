module FsUnitAssertions

open NUnit.Framework
open FsUnit

[<TestFixture>]
type TestAssertionsWithShould() =
    [<Test>]
    member x.Equality() =
        1 |> should equal 1

    [<Test>]
    member x.Inequality() =
        2 |> should not' (equal 3)

    [<Test>]
    member x.ListMembership() =
        [1; 2; 3] |> should contain 2

    [<Test>]
    member x.StringStartsWith() =
        "JavaScript" |> should startWith "Java"

    [<Test>]
    member x.stringEndsWith() =
        "IronPython" |> should endWith "Python"

    [<Test>]
    member x.GreaterThan() =
        11 |> should be (greaterThan 10)

    [<Test>]
    member x.LessThan() =
        9 |> should be (lessThan 10)
