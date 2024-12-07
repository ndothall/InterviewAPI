using System.ComponentModel.DataAnnotations;
using InterviewApi.Enums;

namespace InterviewApi.Models
{
    /// <summary>
    /// Represents the data required to create a new camera.
    /// </summary>
    public class CameraDto
    {
        /// <summary>
        /// The name of the camera.
        /// </summary>
        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public required string Name { get; set; }

        /// <summary>
        /// The model of the camera.
        /// </summary>
        [Required(ErrorMessage = "Model is required.")]
        [MaxLength(50, ErrorMessage = "Model cannot exceed 50 characters.")]
        public required string CameraModel { get; set; }

        /// <summary>
        /// The type of the camera.
        /// </summary>
        [Required(ErrorMessage = "Camera type is required.")]
        public CameraType CameraType { get; set; }

        /// <summary>
        /// The year the camera was released.
        /// </summary>
        [Range(1984, int.MaxValue, ErrorMessage = "Year must be greater than or equal to 1984.")]
        public int YearReleased { get; set; }
    }
}
