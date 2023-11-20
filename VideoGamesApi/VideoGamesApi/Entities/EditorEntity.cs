using System.ComponentModel.DataAnnotations;
using VideoGamesApi.Models;

namespace VideoGamesApi.Entities
{
    public class EditorEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public ICollection<GameEntity> Games { get; set; }
    }
}
