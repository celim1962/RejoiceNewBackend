using Microsoft.EntityFrameworkCore;
using RejoiceNewBackend.Data;

namespace RejoiceNewBackend.Repo
{
    public class RepoTripDetailPrice
    {
        private readonly TestDBContext _context;
        public RepoTripDetailPrice(TestDBContext context)
        {
            _context = context;
        }

        public async Task<List<Model.TripDetailPrice>> GetAllAsync() =>
           await _context.TripDetailPrice.AsNoTracking().ToListAsync();

        public async Task<Model.TripDetailPrice?> GetByIdAsync(int id) =>
            await _context.TripDetailPrice.FindAsync(id);

        public async Task<Model.TripDetailPrice> AddAsync(Model.TripDetailPrice tripDetailPrice)
        {
            _context.TripDetailPrice.Add(tripDetailPrice);
            await _context.SaveChangesAsync();
            return tripDetailPrice;
        }

        public async Task<bool> UpdateAsync(Model.TripDetailPrice tripDetailPrice)
        {
            _context.TripDetailPrice.Update(tripDetailPrice);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var tdp = await _context.TripDetailPrice.FindAsync(id);
            if (tdp == null) return false;
            _context.TripDetailPrice.Remove(tdp);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
