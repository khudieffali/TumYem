using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services;

namespace Web.Areas.TumYemAdmin.Controllers
{
    [Area("TumYemAdmin")]
    [Authorize(Roles = "admin")]
    public class StaticFooterController : Controller
    {
        private readonly StaticFooterService _staticFooterService;

        public StaticFooterController(StaticFooterService staticFooterService)
        {
            _staticFooterService = staticFooterService;
        }

        public IActionResult Index()
        {
            var staticFooter =  _staticFooterService.Get();
            return View(staticFooter);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();
            var staticFooter = await _staticFooterService.GetById(id.Value);
            if (staticFooter == null)
                return NotFound();
            return View(staticFooter);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LeftDescription,Address,Email,PhoneNumber,PhoneNumberLink,InstagramLink,TwitterLink,EmailLink,FacebookLink,ID")] StaticFooter foot)
        {
            if (id != foot.ID) return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    await _staticFooterService.Update(foot);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_staticFooterService.StaticFooterExists(foot.ID))
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
            return View(foot);
        }
    }
}
