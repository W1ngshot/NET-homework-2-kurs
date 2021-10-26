open HW6
open Microsoft.Extensions.Logging
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Hosting
open Giraffe
open MaybeBuilder
open Arguments

let calcHttpHandler : HttpHandler =
    fun next ctx ->
        let maybe = MaybeBuilder()
        let result = maybe {
            let! args = ctx.TryBindQueryString<Arguments>()
            let result = Calculator.calculate (args.v1, args.op, args.v2)
            return result
        }
        match result with
        | Ok answer ->
            (setStatusCode 200 >=> text (answer.ToString())) next ctx
        | Error error ->
            (setStatusCode 400 >=> text error) next ctx

let webApp =
    choose [
        GET >=>
            choose [ route "/" >=> text "The command is /calculate"]
            choose [ route "/calculate" >=> calcHttpHandler ]
        setStatusCode 404 >=> text "Not Found"
        ]

type Startup() =
    member _.ConfigureServices (services : IServiceCollection) =
        services.AddGiraffe() |> ignore

    member _.Configure (app : IApplicationBuilder)
                        (_ : IHostEnvironment)
                        (_ : ILoggerFactory) =
        app.UseGiraffe webApp

[<EntryPoint>]
let main _ =
    Host.CreateDefaultBuilder()
        .ConfigureWebHostDefaults(
            fun webHostBuilder ->
                webHostBuilder.UseStartup<Startup>() |> ignore)
        .Build()
        .Run()
    0