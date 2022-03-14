using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services;

namespace Web.Areas.TumYemAdmin.Controllers
{
    [Area("TumYemAdmin")]
    [Authorize(Roles = "admin")]
    public class WhatWeDoController : Controller
    {
        private readonly WhatWeDoService _whatWeDoService;

        public WhatWeDoController(WhatWeDoService whatWeDoService)
        {
            _whatWeDoService = whatWeDoService;
        }

        public async Task<IActionResult> Index()
        {
            var WhatWeDo =await _whatWeDoService.Get();
            return View(WhatWeDo);
        }
     
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();
            var whatwedo = await _whatWeDoService.GetById(id.Value);
            if (whatwedo == null)
                return NotFound();
            return View(whatwedo);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LeftText,Description,ID")] WhatWeDo whatwedo)
        {
            if (id !=whatwedo.ID) return NotFound();
            if (ModelState.IsValid)
            {

                try
                {
                   await _whatWeDoService.Update(whatwedo);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_whatWeDoService.WhatWeDoExists(whatwedo.ID))
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
            return View(whatwedo);
        }

    }
}
