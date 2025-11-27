using Microsoft.EntityFrameworkCore;
using RejoiceNewBackend.Data;

namespace RejoiceNewBackend.Repo
{
    public class RepoTripDetailSchedule
    {
        private readonly TestDBContext _context;
        public RepoTripDetailSchedule(TestDBContext context)
        {
            _context = context;
        }

        public async Task<List<Model.TripDetailSchedule>> GetAllAsync() =>
           await _context.TripDetailSchedule.AsNoTracking().ToListAsync();

        public async Task<Model.TripDetailSchedule?> GetByIdAsync(int id) =>
            await _context.TripDetailSchedule.FindAsync(id);

        public async Task<Model.TripDetailSchedule> AddAsync(Model.TripDetailSchedule tripDetailSchedule)
        {
            _context.TripDetailSchedule.Add(tripDetailSchedule);
            await _context.SaveChangesAsync();
            return tripDetailSchedule;
        }

        public async Task<bool> UpdateAsync(Model.TripDetailSchedule tripDetailSchedule)
        {
            _context.TripDetailSchedule.Update(tripDetailSchedule);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var tds = await _context.TripDetailSchedule.FindAsync(id);
            if (tds == null) return false;
            _context.TripDetailSchedule.Remove(tds);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
