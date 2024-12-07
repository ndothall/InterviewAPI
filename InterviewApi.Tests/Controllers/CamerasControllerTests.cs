using InterviewApi.Controllers;
using InterviewApi.Enums;
using InterviewApi.Models;
using InterviewApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Moq;

namespace InterviewApi.Tests.Controllers
{
    public class CamerasControllerTests
    {
        private readonly Mock<ICameraService> _mockService;
        private readonly IMemoryCache _cache;
        private readonly CamerasController _controller;

        public CamerasControllerTests()
        {
            _mockService = new Mock<ICameraService>();
            _cache = new MemoryCache(new MemoryCacheOptions());
            _controller = new CamerasController(_mockService.Object, _cache);
        }

        #region GetAll Tests

        [Fact]
        public async Task GetAll_ReturnsOkResult_WithListOfCameras()
        {
            // Arrange
            var cameras = new List<Camera>
            {
                new Camera { Id = Guid.NewGuid(), Name = "Canon EOS R5", CameraModel = "R5", CameraType = CameraType.Mirrorless, YearReleased = 2020 },
                new Camera { Id = Guid.NewGuid(), Name = "Nikon D850", CameraModel = "D850", CameraType = CameraType.DSLR, YearReleased = 2017 }
            };

            _mockService.Setup(service => service.GetAllAsync()).ReturnsAsync(cameras);

            // Act
            var result = await _controller.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedCameras = Assert.IsType<List<Camera>>(okResult.Value);
            Assert.Equal(2, returnedCameras.Count);
        }

        #endregion

        #region GetById Tests

        [Fact]
        public async Task GetById_ReturnsOkResult_WhenCameraExists()
        {
            // Arrange
            var cameraId = Guid.NewGuid();
            var camera = new Camera
            {
                Id = cameraId,
                Name = "Sony A7 IV",
                CameraModel = "A7 IV",
                CameraType = CameraType.Mirrorless,
                YearReleased = 2021
            };

            _mockService.Setup(service => service.GetByIdAsync(cameraId)).ReturnsAsync(camera);

            // Act
            var result = await _controller.GetById(cameraId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedCamera = Assert.IsType<Camera>(okResult.Value);
            Assert.Equal(cameraId, returnedCamera.Id);
        }

      
        #endregion
    }
}
