using VideoGamesApi.Data;
using VideoGamesApi.Entities;
using VideoGamesApi.Models;

namespace VideoGamesApi.Repositories
{
    public class EditorRepository: IEditorRepository
    {
        private readonly ApplicationDbContext _appDbContext;

        public EditorRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Editor? GetById(int id)
        {
            var res = _appDbContext.Editor.Where(el => el.Id == id).FirstOrDefault();

            if(res == null)
                return null;
            return EntityModelMapper.ToModel(res);
        }

        public async Task<Editor> AddEditor(Editor editor)
        {
            var entity = EntityModelMapper.ToEntity(editor);

            foreach (var relation in entity.Games.ToList())
            {
                if (editor.Games.Where(el => el.Id == relation.GameId).Count() == 0)
                    entity.Games.Remove(relation);
            }

            editor.Games.ToList().ForEach(async x =>
            {
                if (entity.Games.Where(el => el.GameId == x.Id).Count() == 0)
                {
                    entity.Games.Add(new Entities.EditorGameRelation()
                    {
                        GameId = (int)x.Id,
                        Editor = entity,
                    });
                }
            });

            var resAsEntity = await _appDbContext.AddAsync(entity);
            _appDbContext.SaveChanges();
            return EntityModelMapper.ToModel(resAsEntity.Entity);
        }

        public int GetMaxId()
        {
            if (!_appDbContext.Editor.Any())
                return -1;
            return _appDbContext.Editor.Max(el => el.Id);
        }

        public void Delete(int id)
        {
            _appDbContext.Remove(new EditorEntity
            {
                Id = id
            });

            _appDbContext.SaveChanges();
        }
    }
}
