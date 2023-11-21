using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VideoGamesApi.Entities;
using VideoGamesApi.Models;

namespace VideoGamesApi.Data
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<GameEntity> Game { get; set; }
        public DbSet<EditorEntity> Editor { get; set; }
        public DbSet<StudioEntity> Studio { get; set; }
        public DbSet<StudioGameRelation> StudioGameRelation { get; set; }
        public DbSet<EditorGameRelation> EditorGameRelation { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
