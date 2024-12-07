using InterviewApi.Models;
using InterviewApi.Repositories;

namespace InterviewApi.Services
{
    /// <summary>
    /// Service for managing camera-related operations.
    /// </summary>
    public class CameraService : ICameraService
    {
        private readonly ICameraRepository _repository;

        public CameraService(ICameraRepository repository)
        {
            _repository = repository;
        }

        /// <inheritdoc />
        public Task<IEnumerable<Camera>> GetAllAsync() => _repository.GetAllAsync();

        /// <inheritdoc />
        public Task<Camera> GetByIdAsync(Guid id) => _repository.GetByIdAsync(id);

        /// <inheritdoc />
        public Task AddAsync(Camera camera)
        {
            return _repository.AddAsync(camera);
        }

        /// <inheritdoc />
        public Task UpdateAsync(Camera camera)
        {
            return _repository.UpdateAsync(camera);
        }

        /// <inheritdoc />
        public Task DeleteAsync(Guid id) => _repository.DeleteAsync(id);
    }
}
