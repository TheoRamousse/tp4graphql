using VideoGamesApi.Data;
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
            return _appDbContext.Studio.Where(el => el.Id == id).FirstOrDefault();
        }
    }
}
