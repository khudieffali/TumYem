using Microsoft.AspNetCore.Mvc;
using Services;
using System.Diagnostics;
using Web.Models;
using Web.ViewModels;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ProductService _productService;
        private readonly SliderService _sliderService;
        private readonly AboutUsService _aboutUsService;
        private readonly WhyWeUsService _whyUsService;
        private readonly WhatWeDoService _whatWeDoService;
        private readonly AboutUsTextService _aboutUsTextService;
        private readonly CounterService _counterService;
        private readonly BlogService _blogService;
        public HomeController(ILogger<HomeController> logger, ProductService productService, SliderService sliderService, AboutUsService aboutUsService, WhyWeUsService whyUsService, WhatWeDoService whatWeDoService, AboutUsTextService aboutUsTextService, CounterService counterService, BlogService blogService)
        {
            _logger = logger;
            _productService = productService;
            _sliderService = sliderService;
            _aboutUsService = aboutUsService;
            _whyUsService = whyUsService;
            _whatWeDoService = whatWeDoService;
            _aboutUsTextService = aboutUsTextService;
            _counterService = counterService;
            _blogService = blogService;
        }

        public async Task<IActionResult> Index()
        {
            HomeVM vm = new() {
                ProductList =_productService.GetAll(x=>!x.IsDeleted),
                SliderList= _sliderService.GetAllSliders(x=>x.IsShow),
                FeaturedProduct=_productService.GetAll(x=>x.IsFeatured && !x.IsDeleted),
                About=await _aboutUsService.Get(),
                WhyWeUs=await _whyUsService.Get(),
                WhatWeDo=await _whatWeDoService.Get(),
                AboutUsText=await _aboutUsTextService.Get(),
                Counters= await _counterService.Get(),
                Blogs= await _blogService.GetBlogs(),
            };

            return View(vm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}