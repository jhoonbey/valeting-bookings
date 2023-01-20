using DJValeting.Models.Entities;
using DJValeting.Models.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DJValeting.Services.Interfaces
{
    public interface IBookingService
    {
        Task<int> Create(BookingEntity bookingEntity);
        Task Update(BookingEntity entity);
        Task<IEnumerable<BookingViewModel>> GetAll();
        Task<BookingEntity> GetById(int id);
        Task DeleteById(int id);
        Task ApproveById(int id);
    }
}
