using GraphQL;
using GraphQL.Types;
using System.ComponentModel;
using VideoGamesApi.Inputs;
using VideoGamesApi.Models;
using VideoGamesApi.Repositories;
using VideoGamesApi.Types;

namespace VideoGamesApi.Mutations
{
    public class AppMutation
    {
        public async Task<Game> AddGame(GameInput game, [Service] IGameRepository repos, [Service] IEditorRepository reposEditors, [Service] IStudioRepository reposStudios)
        {
            Game res = null;
            try
            {
                res = await repos.AddGame(new Game
                {
                    Name = game.Name,
                    PublicationDate = game.PublicationDate,
                    Editors = game.EditorsId.Select(el => reposEditors.GetById(el)).ToList(),
                    Studios = game.StudiosId.Select(el => reposStudios.GetById(el)).ToList(),
                    Id = repos.GetMaxId() + 1,
                    Genres = game.Genres,
                    Platforms = game.Platforms,
                });
            }catch (Exception ex)
            {
                return res;
            }

            return res;
        }
    }
}
