using System.ComponentModel.DataAnnotations;

namespace VideoGamesApi.Models
{
    public class Editor
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please specify a name for the editor")]
        public string Name { get; set; }
        [UseSorting]
        public ICollection<Game> Games { get; set; }
    }
}
