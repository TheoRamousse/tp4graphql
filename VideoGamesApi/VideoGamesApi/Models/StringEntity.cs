using System.ComponentModel.DataAnnotations;

namespace VideoGamesApi.Models
{
    public class StringEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string String { get; set; }
    }
}
