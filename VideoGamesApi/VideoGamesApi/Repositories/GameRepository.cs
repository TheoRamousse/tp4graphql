using VideoGamesApi.Data;
using VideoGamesApi.Entities;
using VideoGamesApi.Models;

namespace VideoGamesApi.Repositories
{
    public class GameRepository: IGameRepository
    {
        private readonly ApplicationDbContext _appDbContext;

        public GameRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Game> AddGame(Game game)
        {
            var entity = EntityModelMapper.ToEntity(game);

            if (entity.Studios != null)
            {
                foreach (var relation in entity.Studios.ToList())
                {
                    if (game.Studios.Where(el => el.Id == relation.StudioId).Count() == 0)
                        entity.Studios.Remove(relation);
                }
            }

            if (game.Studios != null)
            {
                game.Studios.ToList().ForEach(async x =>
                {
                    if (entity.Studios.Where(el => el.StudioId == x.Id).Count() == 0)
                    {
                        entity.Studios.Add(new Entities.StudioGameRelation()
                        {
                            StudioId = (int)x.Id,
                            Game = entity,
                        });
                    }
                });
            }

            if (entity.Editors != null)
            {
                foreach (var relation in entity.Editors.ToList())
                {
                    if (game.Editors.Where(el => el.Id == relation.EditorId).Count() == 0)
                        entity.Editors.Remove(relation);
                }
            }


            if (entity.Editors != null)
            {
                game.Editors.ToList().ForEach(async x =>
                {
                    if (entity.Editors.Where(el => el.EditorId == x.Id).Count() == 0)
                    {
                        entity.Editors.Add(new Entities.EditorGameRelation()
                        {
                            EditorId = (int)x.Id,
                            Game = entity,
                        });
                    }
                });
            }




            var resAsEntity = await _appDbContext.AddAsync(entity);
            _appDbContext.SaveChanges();
            return EntityModelMapper.ToModel(resAsEntity.Entity);
        }

        public void Delete(int id)
        {
            _appDbContext.Remove(new GameEntity
            {
                Id = id
            });

            _appDbContext.SaveChanges();
        }

        public Game? GetById(int id)
        {
            var result = _appDbContext.Game.Where(el => el.Id == id).FirstOrDefault();

            if(result == null)
                return null;

            return EntityModelMapper.ToModel(result);
        }

        public int GetMaxId()
        {
            if (!_appDbContext.Game.Any())
                return -1;
            return _appDbContext.Game.Max(el => el.Id);
        }
    }
}
