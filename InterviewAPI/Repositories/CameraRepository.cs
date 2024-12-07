using InterviewApi.Data;
using InterviewApi.Models;
using Microsoft.EntityFrameworkCore;

namespace InterviewApi.Repositories
{
    public class CameraRepository : ICameraRepository
    {
        private readonly AppDbContext _context;

        public CameraRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Camera>> GetAllAsync()
        {
            return await _context.Cameras.ToListAsync();
        }

        public async Task<Camera> GetByIdAsync(Guid id)
        {
            return await _context.Cameras.FindAsync(id);
        }

        public async Task AddAsync(Camera camera)
        {
            await _context.Cameras.AddAsync(camera);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Camera camera)
        {
            _context.Cameras.Update(camera);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var camera = await _context.Cameras.FindAsync(id);
            if (camera != null)
            {
                _context.Cameras.Remove(camera);
                await _context.SaveChangesAsync();
            }
        }
    }
}
