using ChoreJamming.Domain;
using ChoreJamming.Domain.Models;

public class ChoreService
{
    private readonly IMusicProvider _music;
    private readonly IRepository<ChoreHistory> _repo;

    public ChoreService(IMusicProvider music, IRepository<ChoreHistory> repo)
    {
        _music = music;
        _repo = repo;
    }

    public async Task<List<Song?>> ProcessChoreAsync(string choreName)
    {
        return await _music.GetSongAsync(choreName);
    }
    
    public async Task<List<ChoreHistory>> GetHistoryAsync()
    {
        var choreSongs =  await _repo.GetAllAsync();
        
        choreSongs = choreSongs.OrderByDescending(c => c.Date).ToList();
        
        return choreSongs;
    }

    public async Task<Song?> SelectRandomSongFromListOfSongsAsync(List<Song?> songs, string choreName)
    {
        var random = new Random();
        var randomNumber = random.Next(songs.Count);
        
        var songTitle = songs[randomNumber]?.Title;
        if (songTitle != null)
        {
            var history = new ChoreHistory 
            { 
                ChoreName = choreName, 
                SongTitle = songTitle,
                Date = DateTime.Now,
            };
        
            Console.WriteLine("ChoreService: ProcessingChoreAsync");
            Console.WriteLine(history.ChoreName);
            Console.WriteLine(history.SongTitle);
            Console.WriteLine(history.Date);
        
            await _repo.AddAsync(history);
        }

        await _repo.SaveChangesAsync();
        return songs[randomNumber];
    }

    public async Task AddRatingToChoreHistory(int id, int rating)
    {
        var choreHistory = await _repo.GetByIdAsync(id);

        if (choreHistory != null)
        {
            choreHistory.Rating = rating;
            await _repo.SaveChangesAsync();
        }
    }
}
