using Microsoft.AspNetCore.Mvc;
using Services;
using Web.ViewModels;

namespace Web.Controllers
{
    public class BlogController : Controller
    {
        private readonly BlogService _blogService;

        public BlogController(BlogService blogService)
        {
            _blogService = blogService;
        }

        public async Task<IActionResult> BlogDetails(int? id)
        {
            if(id == null)return NotFound();
            BlogVM vm = new()
            {
                Blog=await _blogService.GetById(id.Value),
            };
            return View(vm);
        }
    }
}
