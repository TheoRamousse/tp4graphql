﻿using VideoGamesApi.Models;

namespace VideoGamesApi.Repositories
{
    public interface IEditorRepository
    {
        Editor? GetById(int id);

        Task<Editor> AddEditor(Editor editor);

        int GetMaxId();

        void Delete(int id);
    }
}
