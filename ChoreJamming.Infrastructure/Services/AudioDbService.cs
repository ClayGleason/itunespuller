using System.Globalization;
using ChoreJamming.Domain;
using ChoreJamming.Domain.Models;
using Newtonsoft.Json.Linq;

namespace ChoreJamming.Infrastructure.Services;

public class AudioDbService : IMusicProvider
{
    private readonly HttpClient _http;

    public AudioDbService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<Song>> GetSongAsync(string query)
    {
        var url = $"https://itunes.apple.com/search?term={query}&entity=song&limit=10";

        try 
        {
            var response = await _http.GetAsync(url);
            if (!response.IsSuccessStatusCode) return null;

            var jsonString = await response.Content.ReadAsStringAsync();
            
            if (string.IsNullOrWhiteSpace(jsonString)) return [];

            var json = JObject.Parse(jsonString);
            var results = json["results"];
            Console.WriteLine(results);

            if (results == null || !results.HasValues) return [];

            return results.Select(result => new Song
                {
                    Title = result["trackName"]?.ToString() ?? "Unknown",
                    Artist = result["artistName"]?.ToString() ?? "Unknown",
                    Album = result["collectionName"]?.ToString() ?? "Single",
                    VideoUrl = result["previewUrl"]?.ToString() ?? "",
                    ThumbnailUrl = result["artworkUrl100"]?.ToString().Replace("100x100", "600x600") ?? "",
                    Genre = result["primaryGenreName"]?.ToString() ?? "Unknown",
                    ReleaseDate = DateTime.Parse(result["releaseDate"]?.ToString() ?? ""),
                    Explicit = result["trackExplicitness"]?.ToString() ?? ""
                })
                .ToList();

        }
        catch
        {
            return null;
        }
    }
}