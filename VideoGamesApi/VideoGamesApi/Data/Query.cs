using VideoGamesApi.Models;
using HotChocolate;
using HotChocolate.Data;
using GraphQL;
using VideoGamesApi.Repositories;

namespace VideoGamesApi.Data
{
    public class Query
    {
        [UsePaging(MaxPageSize = 10)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Game> GetGames([Service] ApplicationDbContext context) =>
            context.Game.Select(el => EntityModelMapper.ToModel(el));

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Editor> GetEditors([Service] ApplicationDbContext context) =>
            context.Editor.Select(el => EntityModelMapper.ToModel(el));

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Studio> GetStudios([Service] ApplicationDbContext context) =>
            context.Studio.Select(el => EntityModelMapper.ToModel(el));

        [GraphQLMetadata("game")]
        public Game? GetGame(int id, [Service] IGameRepository repos)
        {
            return repos.GetById(id);
        }

        [GraphQLMetadata("studio")]
        public Studio? GetStudio(int id, [Service] IStudioRepository repos)
        {
            return repos.GetById(id);
        }

        [GraphQLMetadata("editor")]
        public Editor? GetEditor(int id, [Service] IEditorRepository repos)
        {
            return repos.GetById(id);
        }

    }
}
