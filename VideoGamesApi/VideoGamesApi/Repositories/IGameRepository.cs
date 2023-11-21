﻿using VideoGamesApi.Models;

namespace VideoGamesApi.Repositories
{
    public interface IGameRepository
    {
        Game? GetById(int id);

        Task<Game> AddGame(Game game);

        int GetMaxId();
        void Delete(int id);
    }
}
