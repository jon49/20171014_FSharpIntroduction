#I @"..\packages\FSharp.Data.2.3.3\lib\net40"
#r @"FSharp.Data.dll"

open FSharp.Data

type SimpleJson = JsonProvider<""" {"a": 1, "b": "x", "c": "2017-01-01", "d": 1.23} """>

let simple = SimpleJson.GetSample ()

do
    printfn "%i - %s - %A - %f" simple.A simple.B simple.C simple.D
