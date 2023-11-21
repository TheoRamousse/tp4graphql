using VideoGamesApi.Models;
using HotChocolate;
using HotChocolate.Data;
using GraphQL;
using VideoGamesApi.Repositories;
using VideoGamesApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace VideoGamesApi.Data
{
    public class Query
    {
        [UsePaging(MaxPageSize = 10)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<GameEntity> GetGames([Service] ApplicationDbContext context) =>
            context.Game.Include(e => e.Editors).ThenInclude(e => e.Editor).Include(e => e.Studios).ThenInclude(e=>e.Studio).AsQueryable();

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<EditorEntity> GetEditors([Service] ApplicationDbContext context) =>
            context.Editor.Include(e => e.Games).ThenInclude(e => e.Game).AsQueryable();

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<StudioEntity> GetStudios([Service] ApplicationDbContext context) =>
            context.Studio.Include(e => e.Games).ThenInclude(e => e.Game).AsQueryable();

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
