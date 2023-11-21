using VideoGamesApi.Entities;

namespace VideoGamesApi.Models
{
    public static class EntityModelMapper
    {
        public static EditorEntity ToEntity(Editor editor)
        {
            return new EditorEntity
            {
                Id = editor.Id,
                Name = editor.Name,
            };
        }


        public static GameEntity ToEntity(Game game)
        {
            return new GameEntity
            {
                Id = game.Id,
                Name = game.Name,
                Genres = string.Join(",", game.Genres),
                Platforms = string.Join(",", game.Platforms),
                PublicationDate = DateTime.Parse(game.PublicationDate),
                Studios = new List<StudioGameRelation>(),
                Editors = new List<EditorGameRelation>(),
            };
        }

        public static StudioEntity ToEntity(Studio studio)
        {
            return new StudioEntity
            {
                Id = studio.Id,
                Name = studio.Name,
            };
        }

        public static Editor ToModel(EditorEntity entity)
        {
            return new Editor
            {
                Id = entity.Id,
                Name = entity.Name,
                Games = entity.Games != null ? entity.Games.Select(el => EntityModelMapper.ToModel(el.Game)).ToList() : new List<Game>()
            };
        }


        public static Game ToModel(GameEntity game)
        {
            var res = new Game
            {
                Id = game.Id,
                Name = game.Name,
                Genres = game.Genres.Split(",").ToList(),
                Platforms = game.Platforms.Split(",").ToList(),
                PublicationDate = game.PublicationDate.ToString("yyyy-MM-dd"),
            };

            return res;
        }


        public static Studio ToModel(StudioEntity entity)
        {
            return new Studio
            {
                Id = entity.Id,
                Name = entity.Name,
                Games = entity.Games != null ? entity.Games.Select(el => EntityModelMapper.ToModel(el.Game)).ToList() : new List<Game>(),
            };
        }
    }
}
