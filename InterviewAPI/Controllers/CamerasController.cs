using InterviewApi.Models;
using InterviewApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace InterviewApi.Controllers
{
    /// <summary>
    /// API Controller for managing cameras.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class CamerasController : ControllerBase
    {
        private readonly ICameraService _service;
        private readonly IMemoryCache _cache;

        /// <summary>
        /// Constructor to inject services and caching.
        /// </summary>
        /// <param name="service">Camera service to handle business logic.</param>
        /// <param name="cache">In-memory cache for optimizing data retrieval.</param>
        public CamerasController(ICameraService service, IMemoryCache cache)
        {
            _service = service;
            _cache = cache;
        }

        /// <summary>
        /// Retrieves all cameras. Caches results for 15 seconds.
        /// </summary>
        /// <returns>A list of cameras.</returns>
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            const string cacheKey = "CameraList";

            if (!_cache.TryGetValue(cacheKey, out IEnumerable<Camera> cameras))
            {
                cameras = await _service.GetAllAsync();

                _cache.Set(cacheKey, cameras, TimeSpan.FromSeconds(15));
            }

            return Ok(cameras);
        }

        /// <summary>
        /// Retrieves a camera by its ID.
        /// </summary>
        /// <param name="id">The ID of the camera.</param>
        /// <returns>The camera with the specified ID.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var camera = await _service.GetByIdAsync(id);
            if (camera == null) return NotFound(new { Message = $"Camera with ID {id} not found." });

            return Ok(camera);
        }

        /// <summary>
        /// Creates a new camera.
        /// </summary>
        /// <param name="createDto">The camera object to create.</param>
        /// <returns>The created camera.</returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CameraDto createDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var camera = new Camera
            {
                Id = Guid.NewGuid(),
                Name = createDto.Name,
                CameraModel = createDto.CameraModel,
                CameraType = createDto.CameraType,
                YearReleased = createDto.YearReleased
            };

            await _service.AddAsync(camera);
            return CreatedAtAction(nameof(GetById), new { id = camera.Id }, camera);
        }

        /// <summary>
        /// Updates an existing camera.
        /// </summary>
        /// <param name="id">The ID of the camera to update.</param>
        /// <param name="updateDto">The updated camera data.</param>
        /// <returns>No content if the update is successful.</returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(Guid id, [FromBody] CameraDto updateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingCamera = await _service.GetByIdAsync(id);
            if (existingCamera == null)
                return NotFound(new { Message = $"Camera with ID {id} not found." });

            // Map the DTO properties to the existing camera
            existingCamera.Name = updateDto.Name;
            existingCamera.CameraModel = updateDto.CameraModel;
            existingCamera.CameraType = updateDto.CameraType;
            existingCamera.YearReleased = updateDto.YearReleased;

            await _service.UpdateAsync(existingCamera);
            return NoContent();
        }

        /// <summary>
        /// Deletes a camera by its ID.
        /// </summary>
        /// <param name="id">The ID of the camera to delete.</param>
        /// <returns>No content if the deletion is successful.</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var existingCamera = await _service.GetByIdAsync(id);
            if (existingCamera == null) return NotFound(new { Message = $"Camera with ID {id} not found." });

            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
