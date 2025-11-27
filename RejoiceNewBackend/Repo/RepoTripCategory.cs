using Microsoft.EntityFrameworkCore;
using RejoiceNewBackend.Data;

namespace RejoiceNewBackend.Repo
{
    public class RepoTripCategory
    {
        private readonly TestDBContext _context;
        public RepoTripCategory(TestDBContext context)
        {
            _context = context;
        }

        public async Task<List<Model.TripCategory>> GetAllAsync() =>
           await _context.TripCategories.AsNoTracking().ToListAsync();

        public async Task<Model.TripCategory?> GetByIdAsync(int id) =>
            await _context.TripCategories.FindAsync(id);

        public async Task<Model.TripCategory> AddAsync(Model.TripCategory tripCategory)
        {
            _context.TripCategories.Add(tripCategory);
            await _context.SaveChangesAsync();
            return tripCategory;
        }

        public async Task<bool> UpdateAsync(Model.TripCategory tripCategory)
        {
            _context.TripCategories.Update(tripCategory);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var tc = await _context.TripCategories.FindAsync(id);
            if (tc == null) return false;
            _context.TripCategories.Remove(tc);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
