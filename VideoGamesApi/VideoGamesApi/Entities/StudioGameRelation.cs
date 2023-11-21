using Microsoft.EntityFrameworkCore;

namespace VideoGamesApi.Entities
{
    [PrimaryKey(nameof(StudioId), nameof(GameId))]
    public class StudioGameRelation
    {
        public int StudioId { get; set; }
        public int GameId { get; set; }

        public GameEntity Game { get; set; }
        public StudioEntity Studio { get; set; }
    }
}
