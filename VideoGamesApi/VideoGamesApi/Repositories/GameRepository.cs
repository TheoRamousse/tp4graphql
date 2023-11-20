using VideoGamesApi.Data;
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
            var resAsEntity = await _appDbContext.AddAsync(EntityModelMapper.ToEntity(game));
            _appDbContext.SaveChanges();
            return EntityModelMapper.ToModel(resAsEntity.Entity);
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
