using System.ComponentModel.DataAnnotations;

namespace VideoGamesApi.Models
{
    public class Studio
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please specify a name for the studio")]
        public string Name { get; set; }
        [UseSorting]
        public ICollection<Game> Games { get; set; }
    }
}
