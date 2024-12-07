using InterviewApi.Models;

namespace InterviewApi.Services
{
    /// <summary>
    /// Defines operations for managing cameras.
    /// </summary>
    public interface ICameraService
    {
        /// <summary>
        /// Retrieves all cameras asynchronously.
        /// </summary>
        Task<IEnumerable<Camera>> GetAllAsync();

        /// <summary>
        /// Retrieves a camera by its ID.
        /// </summary>
        Task<Camera> GetByIdAsync(Guid id);

        /// <summary>
        /// Adds a new camera.
        /// </summary>
        Task AddAsync(Camera camera);

        /// <summary>
        /// Updates an existing camera.
        /// </summary>
        Task UpdateAsync(Camera camera);

        /// <summary>
        /// Deletes a camera by its ID.
        /// </summary>
        Task DeleteAsync(Guid id);
    }
}

