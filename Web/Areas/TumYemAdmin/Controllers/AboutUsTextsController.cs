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
    public class AboutUsTextsController : Controller
    {
        private readonly AboutUsTextService _aboutUsTextService;

        public AboutUsTextsController(AboutUsTextService aboutUsTextService)
        {
            _aboutUsTextService = aboutUsTextService;
        }


        // GET: TumYemAdmin/AboutUsTexts
        public async Task<IActionResult> Index()
        {
            return View(await _aboutUsTextService.GetAdmin());
        }

        // GET: TumYemAdmin/AboutUsTexts/Details/5

        // GET: TumYemAdmin/AboutUsTexts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TumYemAdmin/AboutUsTexts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OneMain,OneText,IsDeleted,ID")] AboutUsText aboutUsText)
        {
            if (ModelState.IsValid)
            {
               await _aboutUsTextService.Add(aboutUsText);
                return RedirectToAction(nameof(Index));
            }
            return View(aboutUsText);
        }

        // GET: TumYemAdmin/AboutUsTexts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();
            var aboutUsText = await _aboutUsTextService.GetById(id.Value);
            if (aboutUsText == null)
                return NotFound();
            return View(aboutUsText);
        }

        // POST: TumYemAdmin/AboutUsTexts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OneMain,OneText,IsDeleted,ID")] AboutUsText aboutUsText)
        {
            if (id != aboutUsText.ID)
                return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    await _aboutUsTextService.Update(aboutUsText);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_aboutUsTextService.AboutUsTextExists(aboutUsText.ID))
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
            return View(aboutUsText);
        }

        // GET: TumYemAdmin/AboutUsTexts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            var aboutUsText = await _aboutUsTextService.GetById(id);
            if (aboutUsText == null)
                return NotFound();
            return View(aboutUsText);
        }

        // POST: TumYemAdmin/AboutUsTexts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aboutUsText = await _aboutUsTextService.GetById(id);
            await _aboutUsTextService.Delete(aboutUsText);
            return RedirectToAction(nameof(Index));
        }

       
    }
}
