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
    public class BlogsController : Controller
    {
        private readonly BlogService _blogService;
        private readonly IWebHostEnvironment _webHost;
        public BlogsController(BlogService blogService, IWebHostEnvironment webHost)
        {
            _blogService = blogService;
            _webHost = webHost;
        }

        // GET: TumYemAdmin/Blogs
        public async Task<IActionResult> Index()
        {
            return View(await _blogService.GetBlogsAdmin());
        }

        // GET: TumYemAdmin/Blogs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var blog = await _blogService.GetById(id.Value);
            if (blog == null)
                return NotFound();
            return View(blog);
        }

        // GET: TumYemAdmin/Blogs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TumYemAdmin/Blogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BlogPhoto,PublishDate,HeaderText,Description,IsDeleted,ID")] Blog blog,IFormFile BlogPhoto)
        {
            if (ModelState.IsValid)
            {
                if (BlogPhoto != null)
                {
                    string fileName = Guid.NewGuid() + BlogPhoto.FileName;
                    string rootFile = Path.Combine(_webHost.WebRootPath, "uploads");
                    string mainFile = Path.Combine(rootFile, fileName);
                    using FileStream stream = new(mainFile, FileMode.Create);
                    BlogPhoto.CopyTo(stream);
                    blog.BlogPhoto = "/uploads/" + fileName;
                    blog.PublishDate = DateTime.Now;
                    await _blogService.Add(blog);
                    return RedirectToAction(nameof(Index));
                }
                return RedirectToAction(nameof(Index));
            }
            return View(blog);
        }

        // GET: TumYemAdmin/Blogs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();
            var blog = await _blogService.GetById(id.Value);
            if (blog == null)
                return NotFound();
            return View(blog);
        }

        // POST: TumYemAdmin/Blogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BlogPhoto,PublishDate,HeaderText,Description,IsDeleted,ID")] Blog blog,IFormFile NewBlogPhoto)
        {
            if (id != blog.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (NewBlogPhoto != null)
                    {
                        string fileName = Guid.NewGuid() + NewBlogPhoto.FileName;
                        string rootFile = Path.Combine(_webHost.WebRootPath, "uploads");
                        string mainFile = Path.Combine(rootFile, fileName);
                        using FileStream str = new(mainFile, FileMode.Create);
                        NewBlogPhoto.CopyTo(str);
                        blog.BlogPhoto = "/uploads/" + fileName;
                    }
                    await _blogService.Update(blog);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_blogService.BlogExists(blog.ID))
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
            return View(blog);
        }

        // GET: TumYemAdmin/Blogs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            var blog = await _blogService.GetById(id.Value);
            if (blog == null)
                return NotFound();
            return View(blog);
        }

        // POST: TumYemAdmin/Blogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blog = await _blogService.GetById(id);
            if(blog == null)return NotFound();
            await _blogService.Delete(blog);
            return RedirectToAction(nameof(Index));
        }

     
    }
}
