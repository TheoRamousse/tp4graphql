using GraphQL;
using GraphQL.Types;
using System.ComponentModel;
using VideoGamesApi.Models;
using VideoGamesApi.Repositories;
using VideoGamesApi.Types;

namespace VideoGamesApi.Mutations
{
    public class AppMutation
    {
        public async Task<Game> AddGame([Description("The TODO description")] string description, [Service] IGameRepository repos)
        {
            var res = await repos.AddGame(new Game
            {
                Name = "toto",
                PublicationDate = DateTime.Now,
                Editors = new List<Editor>(),
                Studios = new List<Studio>(),
                Id = repos.GetMaxId() + 1,
                Genres = new List<StringEntity>(),
                Platforms = new List<StringEntity>(),
            });

            return res;
        }
    }
}
