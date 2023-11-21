using VideoGamesApi.Models;

namespace VideoGamesApi.Repositories
{
    public interface IStudioRepository
    {
        Studio? GetById(int id);

        Task<Studio> AddStudio(Studio studio);

        int GetMaxId();

        void Delete(int id);
    }
}
