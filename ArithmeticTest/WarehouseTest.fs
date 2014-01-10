module ``Warehouse example``

type  Product = string
type  Quantity = int

type Warehouse =
    abstract member HasInventory: Product * Quantity -> bool
    abstract member Remove : Product * Quantity -> unit

type Order(product, quantity) =
    let mutable filled = false
    member order.Fill(warehouse:Warehouse) =
        if warehouse.HasInventory(product, quantity) then 
            warehouse.Remove(product, quantity)
            filled <- true
    member order.IsFilled = filled

open NUnit.Framework
open FsUnit
open Foq

let [<Test>] ``filling removes inventory if in stock`` () =
    let product, quantity = "TALISKER", 50
    let order = Order(product, quantity)
    let warehouse =
        Mock<Warehouse>.With(fun mock -> 
            <@ mock.HasInventory(product, quantity) --> true @>
        )
    order.Fill(warehouse)
    verify <@ warehouse.HasInventory(product,quantity) @> once
    verify <@ warehouse.Remove(product, quantity) @> once
    order.IsFilled |> should be True

let [<Test>] ``filling does not remove if not enough in stock`` () =
    let product, quantity = "TALISKER", 51
    let order = Order(product, quantity)
    let warehouse =
        Mock<Warehouse>.With(fun mock -> 
            <@ mock.HasInventory(product, quantity) --> false @>
        )
    order.Fill(warehouse)
    verify <@ warehouse.Remove(product, quantity) @> never
    order.IsFilled |> should be False