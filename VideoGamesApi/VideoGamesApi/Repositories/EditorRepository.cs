using VideoGamesApi.Data;
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
    }
}
