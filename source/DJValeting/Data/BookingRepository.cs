using DJValeting.Data.Interfaces;
using DJValeting.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DJValeting.Data
{
    public class BookingRepository : IBookingRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public BookingRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Insert(BookingEntity entity)
        {
            _dbContext.Bookings.Add(entity);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task Update(BookingEntity entity)
        {
            _dbContext.Bookings.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<BookingEntity>> GetAll()
        {
            var result = await _dbContext.Bookings.ToListAsync();
            return result;
        }

        public async Task<BookingEntity> GetById(int id)
        {
            var result = await _dbContext.Bookings.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public async Task Delete(BookingEntity entity)
        {
            _dbContext.Bookings.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
