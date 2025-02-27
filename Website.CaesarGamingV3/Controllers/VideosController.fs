namespace Website.CaesarGaming.Controllers

open System
open System.IO
open System.Diagnostics
open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging
open Website.CaesarGaming.Models
open System.Collections.Generic

type VideosController(logger: ILogger<VideosController>) =
    inherit Controller()

    let _logger = logger

    member this.Videos() =
        // Path to the videos directory relative to wwwroot
        let videosFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "media", "videos")

        // Enumerate all video files in the directory
        let videoFiles =
            if Directory.Exists(videosFolderPath) then
                Directory.GetFiles(videosFolderPath, "*.mp4")
            else
                [||] // Empty array if folder doesn't exist

        // Map files to a list of video models
        let videos =
            videoFiles
            |> Array.mapi (fun i filePath ->
                let fileName = Path.GetFileName(filePath)
                {
                    Id = i + 1
                    Title = Path.GetFileNameWithoutExtension(fileName) // Title from file name
                    Description = $"This is:  {i + 1}" // Replace with actual description if available
                    Url = $"/media/videos/{fileName}" // Relative URL for video
                }
            )

        // Pass the videos list to the view
        this.View(videos)

    // Error handling method
    [<ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)>]
    member this.Error() =
        let reqId = 
            match Activity.Current with
            | null -> this.HttpContext.TraceIdentifier
            | current -> current.Id

        this.View({ RequestId = reqId })
