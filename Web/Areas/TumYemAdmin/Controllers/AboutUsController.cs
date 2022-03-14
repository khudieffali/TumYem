using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services;

namespace Web.Areas.TumYemAdmin.Controllers
{
    [Area("TumYemAdmin")]
    [Authorize(Roles = "admin")]
    public class AboutUsController : Controller
    {
        private readonly AboutUsService _aboutUsService;
        private readonly IWebHostEnvironment _webHost;

        public AboutUsController(AboutUsService aboutUsService, IWebHostEnvironment webHost)
        {
            _aboutUsService = aboutUsService;
            _webHost = webHost;
        }


        public async Task<IActionResult> Index()
        {
            var whyweus = await _aboutUsService.Get();
            return View(whyweus);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();
            var whatwedo = await _aboutUsService.GetById(id.Value);
            if (whatwedo == null)
                return NotFound();
            return View(whatwedo);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Description,CompanyPhoto,ID")] AboutUs about, IFormFile? NewPhoto)
        {
            if (id != about.ID) return NotFound();
            if (ModelState.IsValid)
            {

                try
                {
                    if (NewPhoto != null)
                    {
                        string fileName = Guid.NewGuid() + NewPhoto.FileName;
                        string rootFile = Path.Combine(_webHost.WebRootPath, "uploads");
                        string mainFile = Path.Combine(rootFile, fileName);
                        using FileStream str = new(mainFile, FileMode.Create);
                        NewPhoto.CopyTo(str);
                        about.CompanyPhoto = "/uploads/" + fileName;
                    }
                    await _aboutUsService.Update(about);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_aboutUsService.AboutUsExists(about.ID))
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
            return View(about);
        }
    }
}
