using Microsoft.EntityFrameworkCore;
using StartDialog.Models;

namespace StartDialog.Data
{
    public class SongDbContext : DbContext
    {
        public SongDbContext(DbContextOptions<SongDbContext> options) : base(options)
        {
        }

        public DbSet<Song> Songs { get; set; }

    }

}
