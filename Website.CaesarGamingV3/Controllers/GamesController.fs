namespace Website.CaesarGaming.Controllers

open System
open System.Diagnostics
open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging
open Website.CaesarGaming.Models

[<Route("Games")>] // Route prefix for the controller
type GamesController(logger: ILogger<GamesController>) =
    inherit Controller()


    // Maps to /Games/Games
    [<HttpGet("Games")>]
    member this.Games() =
        this.View()

    // Error handling method
    [<ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)>]
    member this.Error() =
        let reqId =
            match Activity.Current with
            | null -> this.HttpContext.TraceIdentifier
            | current -> current.Id

        this.View({ RequestId = reqId })
