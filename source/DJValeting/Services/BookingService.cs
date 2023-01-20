using AutoMapper;
using DJValeting.Data.Interfaces;
using DJValeting.Models.Entities;
using DJValeting.Models.ViewModels;
using DJValeting.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DJValeting.Services
{
    public class BookingService : IBookingService
    {
        private readonly IMapper _mapper;
        private readonly IBookingRepository _bookingRepository;

        public BookingService(IMapper mapper, IBookingRepository bookingRepository)
        {
            _mapper = mapper;
            _bookingRepository = bookingRepository;
        }

        public async Task<int> Create(BookingEntity bookingEntity)
        {
            bookingEntity.BookingDate = DateTime.Now;
            return await _bookingRepository.Insert(bookingEntity);
        }

        public async Task Update(BookingEntity entity)
        {
            await _bookingRepository.Update(entity);
        }

        public async Task<IEnumerable<BookingViewModel>> GetAll()
        {
            var bookingEntities = await _bookingRepository.GetAll();
            return _mapper.Map<List<BookingViewModel>>(bookingEntities);
        }

        public async Task<BookingEntity> GetById(int id)
        {
            return await _bookingRepository.GetById(id);
        }

        public async Task DeleteById(int id)
        {
            var booking = await _bookingRepository.GetById(id);
            if (booking != null)
            {
                await _bookingRepository.Delete(booking);
            }
        }

        public async Task ApproveById(int id)
        {
            var booking = await _bookingRepository.GetById(id);
            if (booking != null)
            {
                booking.Status = true;
                await _bookingRepository.Update(booking);
                
                //Send mail here ????????????????????

            }
        }
    }
}
