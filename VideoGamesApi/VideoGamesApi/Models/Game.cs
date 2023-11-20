using System.ComponentModel.DataAnnotations;

namespace VideoGamesApi.Models
{
    public class Game
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please specify a name for the game")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please specify genres for the game")]
        [UseSorting]
        public ICollection<StringEntity> Genres { get; set; }
        public DateTime PublicationDate { get; set; }

        [Required(ErrorMessage = "Please specify editors for the game")]
        [UseSorting]
        public ICollection<Editor> Editors { get; set; }

        [Required(ErrorMessage = "Please specify studios for the game")]
        [UseSorting]
        public ICollection<Studio> Studios { get; set; }

        [Required(ErrorMessage = "Please specify platforms for the game")]
        [UseSorting]
        public ICollection<StringEntity> Platforms { get; set; }
    }
}
