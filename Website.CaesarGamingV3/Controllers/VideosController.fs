namespace Website.CaesarGaming.Controllers

open System
open System.Diagnostics
open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging
open Website.CaesarGaming.Models

type VideosController(logger: ILogger<VideosController>) =
    inherit Controller()

    // Logger instance for use in methods
    let _logger = logger

    // Default action
    member this.Videos() =
        // Example model with a list of videos
        let videos = [
            { Id = 1; Title = "Video 1"; Description = "Description for Video 1"; Url = "/media/Videos/Video1.mp4" }
            { Id = 2; Title = "Video 2"; Description = "Description for Video 2"; Url = "/media/Videos/Video2.mp4" }
            { Id = 3; Title = "Video 3"; Description = "Description for Video 3"; Url = "/media/Videos/Video3.mp4" }
        ]
        this.View(videos)

    // Error handling method
    [<ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)>]
    member this.Error() =
        let reqId = 
            match Activity.Current with
            | null -> this.HttpContext.TraceIdentifier
            | current -> current.Id

        this.View({ RequestId = reqId })
