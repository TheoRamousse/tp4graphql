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
                Games = editor.Games.Select(x => EntityModelMapper.ToEntity(x)).ToList(),
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
                Studios = game.Studios.Select(el => EntityModelMapper.ToEntity(el)).ToList(),
                PublicationDate = game.PublicationDate,
                Editors = game.Editors.Select(el => EntityModelMapper.ToEntity(el)).ToList()
            };
        }

        public static StudioEntity ToEntity(Studio studio)
        {
            return new StudioEntity
            {
                Id = studio.Id,
                Name = studio.Name,
                Games = studio.Games.Select(x => EntityModelMapper.ToEntity(x)).ToList()
            };
        }

        public static Editor ToModel(EditorEntity entity)
        {
            return new Editor
            {
                Id = entity.Id,
                Name = entity.Name,
                Games = entity.Games.Select(el => EntityModelMapper.ToModel(el)).ToList()
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
                PublicationDate = game.PublicationDate,
            };

            if (game.Studios != null)
                res.Studios = game.Studios.Select(el => EntityModelMapper.ToModel(el)).ToList();
            if (game.Editors != null)
                res.Editors = game.Editors.Select(el => EntityModelMapper.ToModel(el)).ToList();

            return res;
        }


        public static Studio ToModel(StudioEntity entity)
        {
            return new Studio
            {
                Id = entity.Id,
                Name = entity.Name,
                Games = entity.Games.Select(el => EntityModelMapper.ToModel(el)).ToList(),
            };
        }
    }
}
