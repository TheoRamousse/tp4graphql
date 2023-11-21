using Microsoft.EntityFrameworkCore;

namespace VideoGamesApi.Entities
{
    [PrimaryKey(nameof(EditorId), nameof(GameId))]
    public class EditorGameRelation
    {
        public int EditorId { get; set; }
        public int GameId { get; set; }

        public GameEntity Game { get; set; }
        public EditorEntity Editor { get; set; }

    }
}
