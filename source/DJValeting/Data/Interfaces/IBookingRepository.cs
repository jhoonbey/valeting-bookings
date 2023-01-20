using DJValeting.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DJValeting.Data.Interfaces
{
    public interface IBookingRepository
    {
        Task<int> Insert(BookingEntity entity);
        Task Update(BookingEntity entity);
        Task<IEnumerable<BookingEntity>> GetAll();
        Task<BookingEntity> GetById(int id);
        Task Delete(BookingEntity entity);
    }
}
