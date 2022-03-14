#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Entities;
using DataAccess;
using Services;
using Microsoft.AspNetCore.Authorization;

namespace Web.Areas.TumYemAdmin.Controllers
{
    [Area("TumYemAdmin")]
    [Authorize(Roles = "admin")]
    public class ProductsController : Controller
    {
        private readonly ProductService _productService;
        private readonly CategoryService _categoryService;
        private readonly IWebHostEnvironment _webHost;
        public ProductsController(ProductService productService, CategoryService categoryService, IWebHostEnvironment webHost)
        {
            _productService = productService;
            _categoryService = categoryService;
            _webHost = webHost;
        }



        // GET: TumYemAdmin/Products
        public IActionResult Index()
        {
            ViewBag.categoryList=_categoryService.GetAllCategories();
            var selectedProduct = _productService.GetAllAdmin(x=>!x.IsDeleted);
            return View(selectedProduct);
        }

        // GET: TumYemAdmin/Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            ViewBag.categoryList = _categoryService.GetAllCategories();

            if (id == null)
                return NotFound();
            var product = await _productService.GetById(id.Value);
            if (product == null)
                return NotFound();
            return View(product);
        }

        // GET: TumYemAdmin/Products/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.categoryList =await _categoryService.GetAllCategories();
            return View();
        }

        // POST: TumYemAdmin/Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product,IFormFile PhotoUrl)
        {
            ViewBag.categoryList =await _categoryService.GetAllCategories();
            if (ModelState.IsValid)
            {
                if (PhotoUrl != null)
                {
                    string fileName = Guid.NewGuid() + PhotoUrl.FileName;
                    string rootFile = Path.Combine(_webHost.WebRootPath, "uploads");
                    string mainFile = Path.Combine(rootFile, fileName);
                    using FileStream stream = new(mainFile, FileMode.Create);
                    PhotoUrl.CopyTo(stream);
                    product.PhotoUrl = "/uploads/" + fileName;
                    product.PublishDate = DateTime.Now;
                    await _productService.Add(product);
                    return RedirectToAction(nameof(Index));
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: TumYemAdmin/Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.categoryList =await _categoryService.GetAllCategories();
            if (id == null)
                return NotFound();
            var product =await _productService.GetById(id.Value);
            if (product == null)
                return NotFound();
            return View(product);
        }

        // POST: TumYemAdmin/Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Description,Price,Discount,InStock,PhotoUrl,PublishDate,ModifiedOn,SKU,IsFeatured,IsDeleted,IsDay,NewPhoto,CategoryID,ID")] Product product,IFormFile NewPhoto)
        {
            ViewBag.categoryList =await _categoryService.GetAllCategories();
            if (id != product.ID)
                return NotFound();
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
                        product.PhotoUrl = "/uploads/" + fileName;
                    }
                    product.ModifiedOn = DateTime.Now;
                    await _productService.Update(product);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_productService.ProductExists(product.ID))
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
            return View(product);
        }

        // GET: TumYemAdmin/Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            ViewBag.categoryList =await _categoryService.GetAllCategories();
            if (id == null)
            {
                return NotFound();
            }

            var product = await _productService.GetById(id.Value);
            if (product == null)
                return NotFound();
            return View(product);
        }

        // POST: TumYemAdmin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var selectedProduct =await _productService.GetById(id);
            _productService.Delete(selectedProduct);
            return RedirectToAction(nameof(Index));
        }

      
    }
}
