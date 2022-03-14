using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services;

namespace Web.Areas.TumYemAdmin.Controllers
{
    [Area("TumYemAdmin")]
    [Authorize(Roles = "admin")]
    public class CounterController : Controller
    {
        private readonly CounterService _counterService;

        public CounterController(CounterService counterService)
        {
            _counterService = counterService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _counterService.Get());
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();
            var count = await _counterService.GetById(id.Value);
            if (count == null)
                return NotFound();
            return View(count);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Count,CountText,ID")] Counter counter)
        {
            if (id != counter.ID) return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    await _counterService.Update(counter);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_counterService.CounterExists(counter.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(counter);
        }
    }
}
