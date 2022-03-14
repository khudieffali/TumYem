using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services;

namespace Web.Areas.TumYemAdmin.Controllers
{
    [Area("TumYemAdmin")]
    [Authorize(Roles = "admin")]
    public class WhyWeUsController : Controller
    {
        private readonly WhyWeUsService _whyWeUsService;
        private readonly IWebHostEnvironment _webHost;
        public WhyWeUsController(WhyWeUsService whyWeUsService, IWebHostEnvironment webHost)
        {
            _whyWeUsService = whyWeUsService;
            _webHost = webHost;
        }
        public async Task<IActionResult> Index()
        {
            var whyweus = await _whyWeUsService.Get();
            return View(whyweus);
        }
        public async Task<IActionResult> Details(int? id)
        {
            if(id ==null && id==0)return NotFound();
            var whyweus = await _whyWeUsService.GetById(id.Value);
            if(whyweus==null)return NotFound();
            return View(whyweus);

        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();
            var whatwedo = await _whyWeUsService.GetById(id.Value);
            if (whatwedo == null)
                return NotFound();
            return View(whatwedo);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PhotoUrl,Header,Description,LeftStaff,StaffBottomText,RightService,ServiceBottomText,ID")] WhyWeUs whyweus,IFormFile? NewPhoto)
        {
            if (id != whyweus.ID) return NotFound();
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
                        whyweus.PhotoUrl = "/uploads/" + fileName;
                    }
                    await _whyWeUsService.Update(whyweus);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_whyWeUsService.WhyWeUsExists(whyweus.ID))
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
            return View(whyweus);
        }
    }
}
