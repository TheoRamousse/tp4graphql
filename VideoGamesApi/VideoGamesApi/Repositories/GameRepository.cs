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
            var resAsEntity = await _appDbContext.AddAsync(game);
            return resAsEntity.Entity;
        }

        public Game? GetById(int id)
        {
            return _appDbContext.Game.Where(el => el.Id == id).FirstOrDefault();
        }
    }
}
