using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VideoGamesApi.Models;

namespace VideoGamesApi.Entities
{
    public class GameEntity
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please specify a name for the game")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please specify genres for the game")]
        public string Genres { get; set; }
        public DateTime PublicationDate { get; set; }

        [Required(ErrorMessage = "Please specify editors for the game")]
        [UseSorting]
        public ICollection<EditorEntity> Editors { get; set; }

        [Required(ErrorMessage = "Please specify studios for the game")]
        [UseSorting]
        public ICollection<StudioEntity> Studios { get; set; }

        [Required(ErrorMessage = "Please specify platforms for the game")]
        public string Platforms { get; set; }

    }
}
