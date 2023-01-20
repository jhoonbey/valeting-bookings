using DJValeting.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace DJValeting.Models.Entities
{
    public class BookingEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime BookingDate { get; set; }
        [Required]
        public int Flexibility { get; set; }
        [Required]
        public VehicleSize VehicleSize { get; set; }
        [Required]
        public string ContactNumber { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        public bool Status { get; set; }
    }
}
