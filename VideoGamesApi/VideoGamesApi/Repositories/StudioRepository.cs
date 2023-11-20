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
            var res = _appDbContext.Studio.Where(el => el.Id == id).FirstOrDefault();

            if(res == null)
                return null;
            return EntityModelMapper.ToModel(res);
        }

        public async Task<Studio> AddStudio(Studio editor)
        {
            var resAsEntity = await _appDbContext.AddAsync(EntityModelMapper.ToEntity(editor));
            _appDbContext.SaveChanges();
            return EntityModelMapper.ToModel(resAsEntity.Entity);
        }
    }
}
