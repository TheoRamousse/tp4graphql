﻿using VideoGamesApi.Models;

namespace VideoGamesApi.Repositories
{
    public interface IStudioRepository
    {
        Studio? GetById(int id);
    }
}
