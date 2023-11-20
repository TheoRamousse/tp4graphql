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
            return _appDbContext.Editor.Where(el => el.Id == id).FirstOrDefault();
        }
    }
}
