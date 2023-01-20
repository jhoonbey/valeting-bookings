using DJValeting.Models.Entities;
using DJValeting.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace DJValeting.Controllers
{
    public class BookingController : Controller
    {
        private readonly ILogger<BookingController> _logger;
        private readonly IBookingService _bookingService;

        public BookingController(ILogger<BookingController> logger, IBookingService bookingService)
        {
            _logger = logger;
            _bookingService = bookingService;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult<bool>> Create(BookingEntity model)
        {
            try
            {
                var result = await _bookingService.Create(model);
                ModelState.AddModelError("errorKey", "Operation successfully completed!");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("errorKey", $"Error occurred:{ex.Message}");
            }

            return View(model);
        }
    }
}
