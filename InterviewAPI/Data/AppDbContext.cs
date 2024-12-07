using Microsoft.EntityFrameworkCore;
using InterviewApi.Models;

namespace InterviewApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Camera> Cameras { get; set; }
    }
}
