namespace Website.CaesarGaming.Controllers

open System
open System.IO
open System.Diagnostics
open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging
open Website.CaesarGaming.Models
open System.Collections.Generic

type MusicController(logger: ILogger<MusicController>) =
    inherit Controller()

    let _logger = logger

    member this.Music() =
        // Path to the music directory relative to wwwroot
        let musicFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "media", "music")

        // Enumerate all music files in the directory
        let musicFiles =
            if Directory.Exists(musicFolderPath) then
                Directory.GetFiles(musicFolderPath, "*.mp3")
            else
                [||] // Empty array if folder doesn't exist

        // Map files to a list of MusicModel
        let music =
            musicFiles
            |> Array.mapi (fun i filePath ->
                let fileName = Path.GetFileName(filePath)
                {
                    Id = i + 1
                    Title = Path.GetFileNameWithoutExtension(fileName)
                    Description = $"This is song {i + 1}" // Replace with actual description if available
                    Url = $"/media/music/{fileName}"
                }
            )
        // Pass the music list to the view
        this.View(music);




    // Error handling method
    [<ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)>]
    member this.Error() =
        let reqId = 
            match Activity.Current with
            | null -> this.HttpContext.TraceIdentifier
            | current -> current.Id

        this.View({ RequestId = reqId })
