using GraphQL;
using VideoGamesApi.Models;
using VideoGamesApi.Repositories;

namespace VideoGamesApi.Mutations
{
    public class AppMutation
    {
        [GraphQLMetadata("addGame")]
        public async Task<Game> AddGameAsync(Game gameToAdd, [Service] IGameRepository repos)
        {
            return await repos.AddGame(gameToAdd);
        }
    }
}
