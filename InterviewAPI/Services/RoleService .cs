namespace InterviewApi.Services
{
 
    public class RoleService : IRoleService
    {
        private static readonly string[] Roles = { "Admin", "User" };

        /// <inheritdoc />
        public string GenerateRandomRole()
        {
            var random = new Random();
            return Roles[random.Next(Roles.Length)];
        }
    }

}
