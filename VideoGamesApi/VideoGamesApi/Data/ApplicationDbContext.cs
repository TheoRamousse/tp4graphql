using Microsoft.EntityFrameworkCore;
using VideoGamesApi.Models;

namespace VideoGamesApi.Data
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Game> Game { get; set; }
        public DbSet<Editor> Editor { get; set; }
        public DbSet<Studio> Studio { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
