using System.ComponentModel.DataAnnotations;

namespace InterviewApi.Models
{
    public class User
    {
        /// <summary>
        /// The username of the user. This field is required.
        /// </summary>
        [Required(ErrorMessage = "Username is required.")]
        public required string Username { get; set; }

        /// <summary>
        /// The password of the user. This field is required.
        /// </summary>
        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public required string Password { get; set; }

        /// <summary>
        /// The role of the user. This field is optional.
        /// </summary>
        public string? Role { get; set; }
    }
}
