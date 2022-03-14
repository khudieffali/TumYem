#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Entities;
using Services;
using Microsoft.AspNetCore.Authorization;

namespace Web.Areas.TumYemAdmin.Controllers
{
    [Area("TumYemAdmin")]
    [Authorize(Roles = "admin")]
    public class SlidersController : Controller
    {
        private readonly SliderService _sliderService;
        private readonly IWebHostEnvironment _webHost;

        public SlidersController(SliderService sliderService, IWebHostEnvironment webHost)
        {
            _sliderService = sliderService;
            _webHost = webHost;
        }

        // GET: TumYemAdmin/Sliders
        public IActionResult Index()
        {
            var selectedSlider=_sliderService.GetAllSlidersAdmin(x=>!x.IsDeleted);
            return View(selectedSlider);
        }

        // GET: TumYemAdmin/Sliders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();
            var slider =await _sliderService.GetById(id);
            if (slider == null)
                return NotFound();
            return View(slider);
        }

        // GET: TumYemAdmin/Sliders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TumYemAdmin/Sliders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HeaderLeft,HeaderRight,Summary,IsDeleted,IsShow,ID")] Slider slider,IFormFile BackgroundPhotos)
        {
            if (ModelState.IsValid)
            {
                if (BackgroundPhotos != null)
                {
                    string fileName = Guid.NewGuid() + BackgroundPhotos.FileName;
                    string rootFile = Path.Combine(_webHost.WebRootPath, "uploads");
                    string mainFile = Path.Combine(rootFile, fileName);
                    using FileStream stream = new(mainFile, FileMode.Create);
                    BackgroundPhotos.CopyTo(stream);
                    slider.BackgroundPhoto = "/uploads/" + fileName;
                    await _sliderService.Add(slider);
                    return RedirectToAction(nameof(Index));
                }
                return RedirectToAction(nameof(Index));
            }
            return View(slider);
        }

        // GET: TumYemAdmin/Sliders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var slider = await _sliderService.GetById(id);
            if (slider == null)
                return NotFound();
            return View(slider);
        }

        // POST: TumYemAdmin/Sliders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HeaderLeft,HeaderRight,Summary,BackgroundPhoto,IsDeleted,IsShow,ID")] Slider slider,IFormFile newBackgroundPhoto)
        {
            if (id != slider.ID)
                return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    if (newBackgroundPhoto != null)
                    {
                        string fileName = Guid.NewGuid() + newBackgroundPhoto.FileName;
                        string rootFile = Path.Combine(_webHost.WebRootPath, "uploads");
                        string mainFile = Path.Combine(rootFile, fileName);
                        using FileStream str = new(mainFile, FileMode.Create);
                        newBackgroundPhoto.CopyTo(str);
                        slider.BackgroundPhoto = "/uploads/" + fileName;
                    }
                    await _sliderService.Update(slider);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_sliderService.SliderExists(slider.ID))
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
            return View(slider);
        }

        // GET: TumYemAdmin/Sliders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            var slider = await _sliderService.GetById(id);
            if (slider == null)
                return NotFound();
            return View(slider);
        }

        // POST: TumYemAdmin/Sliders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var slider = await _sliderService.GetById(id);
            if(slider == null) return NotFound();
           await _sliderService.Delete(slider);
            return RedirectToAction(nameof(Index));
        }

        
    }
}
