using System.ComponentModel.DataAnnotations;
using VideoGamesApi.Entities;

namespace VideoGamesApi.Models
{
    public class StudioInput
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<int> GamesId { get; set; }

    }
}
