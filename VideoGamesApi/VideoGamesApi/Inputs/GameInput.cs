using GraphQL.Types;
using VideoGamesApi.Models;

namespace VideoGamesApi.Inputs
{
    public class GameInput
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Genres { get; set; }
        public DateTime PublicationDate { get; set; }
        public List<int> EditorsId { get; set; }
        public List<int> StudiosId { get; set; }
        public List<string> Platforms { get; set; }
    }
}
