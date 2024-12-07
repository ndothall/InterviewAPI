using InterviewApi.Models;

namespace InterviewApi.Repositories
{
    public interface ICameraRepository
    {
        Task<IEnumerable<Camera>> GetAllAsync();
        Task<Camera> GetByIdAsync(Guid id);
        Task AddAsync(Camera camera);
        Task UpdateAsync(Camera camera);
        Task DeleteAsync(Guid id);
    }
}
