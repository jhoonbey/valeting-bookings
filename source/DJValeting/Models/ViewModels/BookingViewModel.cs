using DJValeting.Models.Enums;
using System;

namespace DJValeting.Models.ViewModels
{
    public class BookingViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BookingDate { get; set; }
        public int Flexibility { get; set; }
        public VehicleSize VehicleSize { get; set; }
        public string ContactNumber { get; set; }
        public string EmailAddress { get; set; }
        public bool Status { get; set; }
    }
}
