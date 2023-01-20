using DJValeting.Models.Entities;
using DJValeting.Models.ViewModels;
using DJValeting.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DJValeting.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class BookingsController : Controller
    {
        private readonly IBookingService _bookingService;
        public BookingsController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        public async Task<ActionResult<IEnumerable<BookingViewModel>>> Index()
        {
            var bookingViewModels = await _bookingService.GetAll();
            return View(bookingViewModels);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [IgnoreAntiforgeryToken]
        public async Task<ActionResult> Create(BookingEntity model)
        {
            try
            {
                await _bookingService.Create(model);
                ModelState.AddModelError("errorKey", "Operation successfully completed!");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("errorKey", $"Error occurred:{ex.Message}");
                return View(model);
            }

            return RedirectToAction("Index", "Bookings");
        }

        public async Task<ActionResult> Edit(int id)
        {
            var result = await _bookingService.GetById(id);
            return View(result);
        }

        [HttpPost]
        [IgnoreAntiforgeryToken]
        public async Task<ActionResult> Edit(BookingEntity model)
        {
            try
            {
                await _bookingService.Update(model);
                ModelState.AddModelError("errorKey", "Operation successfully completed!");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("errorKey", $"Error occurred:{ex.Message}");
                return View(model);
            }

            return RedirectToAction("Index", "Bookings");
        }

        public async Task<ActionResult> Delete(int id)
        {
            await _bookingService.DeleteById(id);
            return RedirectToAction("Index", "Bookings");
        }

        public async Task<ActionResult> Approve(int id)
        {
            await _bookingService.ApproveById(id);
            return RedirectToAction("Index", "Bookings");
        }
    }
}
