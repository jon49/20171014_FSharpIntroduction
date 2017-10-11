#I @"..\packages\FSharp.Data.SqlClient.1.8.2\lib\net40"
#r "FSharp.Data.SqlClient.dll"

#I @"..\packages\FSharpx.Async.1.13.2\lib\net45\"
#r "FSharpx.Async.dll"

open System
open FSharp.Data
open FSharpx.Control

[<Literal>]
let Connection = "Server=JON;Database=AdventureWorks2016CTP3;Trusted_Connection=True;MultipleActiveResultSets=true;"

type DB = SqlProgrammabilityProvider<Connection>

let test (conn : Data.SqlClient.SqlConnection) =
    use cmd = new DB.HumanResources.sp_GetEmployee_Person_Info_AsOf(conn)
    cmd.AsyncExecute(DateTime.Now)
    |> Async.map (fun xs ->
        xs
        |> Seq.map (fun x -> sprintf "%s %s" x.FirstName x.LastName)
        |> String.concat "\n"
    )

do
    use conn = new System.Data.SqlClient.SqlConnection(Connection) 
    conn.Open ()
    test conn
    |> Async.RunSynchronously
    |> printfn "%s"




