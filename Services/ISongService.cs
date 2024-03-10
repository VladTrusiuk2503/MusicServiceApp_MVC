using StartDialog.Models;

namespace StartDialog.Services
{
    public interface ISongService
    {
        Task<Song> GetSongByIdAsync(int id);
        Task<IEnumerable<Song>> GetAllSongsAsync();
        Task AddSongAsync(Song song);
        Task DeleteSongAsync(int id);
    }


}
