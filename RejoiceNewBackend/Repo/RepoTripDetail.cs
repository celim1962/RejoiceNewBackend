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

        public async Task<bool> UpdateAsync(Model.TripDetail existing, Model.TripDetail incoming)
        {
            // 將 incoming 的值複製到 existing（EF 已追蹤 existing → 不會衝突）
            existing.TripCategoryId = incoming.TripCategoryId;
            existing.Title = incoming.Title;
            existing.Location = incoming.Location;
            existing.Description = incoming.Description;
            existing.HomePageImgUrl = incoming.HomePageImgUrl;
            existing.DetailImgUrl = incoming.DetailImgUrl;
            existing.MaxOrderPeople = incoming.MaxOrderPeople;

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
