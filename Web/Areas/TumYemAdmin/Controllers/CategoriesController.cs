using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services;

namespace Web.Areas.AlzzoniAdmin.Controllers
{
    [Area("TumYemAdmin")]
    [Authorize(Roles = "admin")]
    public class CategoriesController : Controller
    {
        private readonly CategoryService _categoryService;
        private readonly IWebHostEnvironment _webHost;
        public CategoriesController(CategoryService categoryService, IWebHostEnvironment webHost)
        {
            _categoryService = categoryService;
            _webHost = webHost;
        }

        public async Task<IActionResult> Index()
        {
            var selectedCategory =await _categoryService.GetAllCategories();
            return View(selectedCategory);
        }
        public async Task<IActionResult> DetailsAsync(int? id)
        {
            if(id == null) return NotFound();
            var selectedCategory=await _categoryService.GetById(id.Value);
            if(selectedCategory == null) return NotFound();
            return View(selectedCategory);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name,IconUrl,ID")] Category category, IFormFile IconUrl)
        {
            if (ModelState.IsValid)
            {
                if (IconUrl != null)
                {
                    string fileName = Guid.NewGuid() + IconUrl.FileName;
                    string rootFile = Path.Combine(_webHost.WebRootPath, "uploads");
                    string mainFile = Path.Combine(rootFile, fileName);
                    using FileStream stream = new(mainFile, FileMode.Create);
                    IconUrl.CopyTo(stream);
                    category.IconUrl = "/uploads/" + fileName;
                    await _categoryService.Add(category);
                    return RedirectToAction(nameof(Index));
                }
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }
        public async Task<IActionResult> EditAsync(int? id)
        {
            if(id==null) return NotFound();
            var selectedCategory =await _categoryService.GetById(id.Value);
            if(selectedCategory==null) return NotFound();   
            return View(selectedCategory);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Name,IconUrl,NewIcon,ID")] Category category, IFormFile? NewIcon)
        {
            if (id != category.ID)
                return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    if (NewIcon != null)
                    {
                        string fileName = Guid.NewGuid() + NewIcon.FileName;
                        string rootFile = Path.Combine(_webHost.WebRootPath, "uploads");
                        string mainFile = Path.Combine(rootFile, fileName);
                        using FileStream str = new(mainFile, FileMode.Create);
                        NewIcon.CopyTo(str);
                        category.IconUrl = "/uploads/" + fileName;
                    }
                    await _categoryService.Update(category);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_categoryService.CategoryExists(category.ID))
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
            return View(category);
        }
        public async Task<IActionResult> DeleteAsync(int? id)
        {
            if (id == null) return NotFound();
            var selectedCategory =await _categoryService.GetById(id.Value);
            if(selectedCategory == null) return NotFound();
            return View(selectedCategory);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var selectedCategory=await _categoryService.GetById(id);
            await _categoryService.Delete(selectedCategory);
            return RedirectToAction("Index");
        }

    }
}
