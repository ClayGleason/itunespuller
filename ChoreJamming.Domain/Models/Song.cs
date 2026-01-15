namespace ChoreJamming.Domain.Models;

public class Song
{
    public string Title { get; set; } = string.Empty;
    public string Artist { get; set; } = string.Empty;
    public string Album { get; set; } = string.Empty; 
    
    public string VideoUrl { get; set; } = string.Empty; 
    
    public string ThumbnailUrl { get; set; } = string.Empty;
    
    // extra data from api
    public string Genre { get; set; } = string.Empty;
    public DateTime ReleaseDate { get; set; } = DateTime.Now;
    public string Explicit { get; set; } = string.Empty;
}