using System.ComponentModel.DataAnnotations;
using InterviewApi.Enums;

namespace InterviewApi.Models
{
    /// <summary>
    /// Represents a camera with details such as name, model, type, and year released.
    /// </summary>
    public class Camera
    {
        /// <summary>
        /// The unique identifier for the camera.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The name of the camera.
        /// </summary>
        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string Name { get; set; }

        /// <summary>
        /// The model of the camera.
        /// </summary>
        [Required(ErrorMessage = "CameraModel is required.")]
        [MaxLength(50, ErrorMessage = "CameraModel cannot exceed 50 characters.")]
        public string CameraModel { get; set; }

        /// <summary>
        /// The type of the camera.
        /// </summary>
        [Required(ErrorMessage = "Camera type is required.")]
        public CameraType CameraType { get; set; }

        /// <summary>
        /// The year the camera was released. Must be 1984 or later.
        /// </summary>
        [Range(1984, int.MaxValue, ErrorMessage = "Year must be greater than or equal to 1984.")]
        public int YearReleased { get; set; }
    }
}
