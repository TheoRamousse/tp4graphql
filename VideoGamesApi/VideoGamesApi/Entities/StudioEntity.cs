using VideoGamesApi.Models;

namespace VideoGamesApi.Entities
{
    public class StudioEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<GameEntity> Games { get; set; }
    }
}
