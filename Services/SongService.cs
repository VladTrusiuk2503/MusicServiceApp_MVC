using Microsoft.EntityFrameworkCore;
using StartDialog.Data;
using StartDialog.Models;

namespace StartDialog.Services
{
    public class SongService : ISongService
    {
        private readonly SongDbContext _context;

        public SongService(SongDbContext context)
        {
            _context = context;
        }

        public async Task<Song> GetSongByIdAsync(int id)
        {
            return await _context.Songs.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<Song>> GetAllSongsAsync()
        {
            return await _context.Songs.ToListAsync();
        }

        public async Task AddSongAsync(Song song)
        {
            _context.Songs.Add(song);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSongAsync(int id)
        {
            var song = await _context.Songs.FirstOrDefaultAsync(s => s.Id == id);

            if (song != null)
            {
                _context.Songs.Remove(song);
                await _context.SaveChangesAsync();
            }
        }
    }

}
