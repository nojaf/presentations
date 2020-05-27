/// Warning: generated code at 5/25/2020 9:01:43 PM 😅🙈🙉
module MyApp.Database

open DustyTables

let connectionString =
    "Server=localhost;Database=twitter;User Id=sa;Password=Password1!;"

type User = { Id: int; Name: string }

let getUsers (): Result<list<User>, exn> =
    connectionString
    |> Sql.connect
    |> Sql.query "SELECT * FROM [dbo].users"
    |> Sql.execute (fun reader ->
        { Id = reader.int "id"
          Name = reader.string "name" })

type Tweet =
    { Content: string
      Id: int
      UserId: int }

let getTweets (): Result<list<Tweet>, exn> =
    connectionString
    |> Sql.connect
    |> Sql.query "SELECT * FROM [dbo].tweets"
    |> Sql.execute (fun reader ->
        { Content = reader.string "content"
          Id = reader.int "id"
          UserId = reader.int "user_id" })
