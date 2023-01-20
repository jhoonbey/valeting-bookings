using AutoMapper;
using DJValeting.Models.Entities;
using DJValeting.Models.ViewModels;

namespace DJValeting.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BookingEntity, BookingViewModel>().ReverseMap();
        }
    }
}
