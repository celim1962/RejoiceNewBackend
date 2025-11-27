using Microsoft.EntityFrameworkCore;
using RejoiceNewBackend.Data;

namespace RejoiceNewBackend.Repo
{
    public class RepoTripDetail
    {
        private readonly TestDBContext _context;
        public RepoTripDetail(TestDBContext context)
        {
            _context = context;
        }

        public async Task<List<Model.TripDetail>> GetAllAsync() =>
           await _context.TripDetails.AsNoTracking().ToListAsync();

        public async Task<Model.TripDetail?> GetByIdAsync(int id) =>
            await _context.TripDetails.FindAsync(id);

        public async Task<Model.TripDetail> AddAsync(Model.TripDetail tripDetail)
        {
            _context.TripDetails.Add(tripDetail);
            await _context.SaveChangesAsync();
            return tripDetail;
        }

        public async Task<bool> UpdateAsync(Model.TripDetail tripDetail)
        {
            _context.TripDetails.Update(tripDetail);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var td = await _context.TripDetails.FindAsync(id);
            if (td == null) return false;
            _context.TripDetails.Remove(td);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
