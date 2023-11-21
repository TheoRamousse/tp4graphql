using VideoGamesApi.Data;
using VideoGamesApi.Entities;
using VideoGamesApi.Models;

namespace VideoGamesApi.Repositories
{
    public class StudioRepository: IStudioRepository
    {
        private readonly ApplicationDbContext _appDbContext;

        public StudioRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Studio? GetById(int id)
        {
            var res = _appDbContext.Studio.Where(el => el.Id == id).FirstOrDefault();

            if(res == null)
                return null;
            return EntityModelMapper.ToModel(res);
        }

        public async Task<Studio> AddStudio(Studio editor)
        {
            var entity = EntityModelMapper.ToEntity(editor);

            if (entity.Games != null)
            {
                foreach (var relation in entity.Games.ToList())
                {
                    if (editor.Games.Where(el => el.Id == relation.GameId).Count() == 0)
                        entity.Games.Remove(relation);
                }
            }

            if(editor.Games != null)
            {
                editor.Games.ToList().ForEach(async x =>
                {
                    if (entity.Games.Where(el => el.GameId == x.Id).Count() == 0)
                    {
                        entity.Games.Add(new Entities.StudioGameRelation()
                        {
                            GameId = (int)x.Id,
                            Studio = entity,
                        });
                    }
                });
            }


            var resAsEntity = await _appDbContext.AddAsync(entity);
            _appDbContext.SaveChanges();
            return EntityModelMapper.ToModel(resAsEntity.Entity);
        }

        public int GetMaxId()
        {
            if (!_appDbContext.Studio.Any())
                return -1;
            return _appDbContext.Studio.Max(el => el.Id);
        }

        public void Delete(int id)
        {
            _appDbContext.Remove(new StudioEntity
            {
                Id = id
            });

            _appDbContext.SaveChanges();
        }
    }
}
