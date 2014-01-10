module FsCheckTest

open NUnit.Framework
open FsCheck
open Arithmetic
open System

let sortList xs =
    List.sort xs

let reverseList xs =
    List.rev xs

let nonEmptyList xs =
    match xs with
    | [] -> false
    | [x] -> true
    | x::xs -> true

let rec allValidNumbers xs =
    match xs with
    | [] -> true
    | [x] -> not (Double.IsNaN(x))
    | x::xs -> not (Double.IsNaN(x)) && allValidNumbers xs

[<TestFixture>]
type FsCheckTests() =

    [<Test>]
    member x.ReversingAListTwiceGivesOriginalList() =
        let reversingTwiceGivesOriginal (xs:list<int>) = reverseList(reverseList xs) = xs
        Check.QuickThrowOnFailure reversingTwiceGivesOriginal

    [<Test>]
    member x.SquareOfANumberIsAlwaysPositive() =
        let squareCheck (x:float) = square x >= 0.0
        Check.QuickThrowOnFailure squareCheck

    [<Test>]
    member x.SortingListGivesMinimumElementFirst() =
        let sortingListGivesMinimumElementFirst (xs:list<double>) =
            (nonEmptyList xs && allValidNumbers xs) ==>
            lazy(List.min xs = List.head (sortList xs))
        Check.QuickThrowOnFailure sortingListGivesMinimumElementFirst