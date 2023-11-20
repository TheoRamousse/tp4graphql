using VideoGamesApi.Models;

namespace VideoGamesApi.Repositories
{
    public interface IGameRepository
    {
        Game? GetById(int id);

        Task<Game> AddGame(Game game);
    }
}
