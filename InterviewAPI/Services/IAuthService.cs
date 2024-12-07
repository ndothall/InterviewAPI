using InterviewApi.Models;

namespace InterviewApi.Services
{   
     /// <summary>
     /// Service for handling authentication and token generation.
     /// </summary>
    public interface IAuthService
    {

        /// <summary>
        /// Generates a JWT token for the provided user.
        /// </summary>
        /// <param name="user">The user who the token is being generated.</param>
        /// <returns>A signed JWT token as a string.</returns>
        string GenerateJwtToken(User user);    
    }
}