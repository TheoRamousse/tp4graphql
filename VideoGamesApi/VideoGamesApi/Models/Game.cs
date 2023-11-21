using System.ComponentModel.DataAnnotations;
using VideoGamesApi.Entities;

namespace VideoGamesApi.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<string> Genres { get; set; }
        public string PublicationDate { get; set; }
        public ICollection<Editor> Editors { get; set; } = new List<Editor>();
        public ICollection<Studio> Studios { get; set; } = new List<Studio>();
        public ICollection<string> Platforms { get; set; }

    }
}
