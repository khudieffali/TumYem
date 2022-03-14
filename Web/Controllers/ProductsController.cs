using Microsoft.AspNetCore.Mvc;
using Services;
using Web.Helpers;
using Web.ViewModels;

namespace Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductService _productService;
        private readonly CategoryService _categoryService;
        public ProductsController(ProductService productService, CategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Details(int id)
        {
            if (id == null) return NotFound();
            ProductDetailsVM vm = new()
            {
                Product =await _productService.GetById(id),
            };
            return View(vm);
        }
        public async Task<IActionResult> ShopList(string? q,int? categoryId,int? pageNo, int? recordSize)
        {
            pageNo ??= 1;
            recordSize ??= 4;
            ProductSearchVM vm = new()
            {
                CategoryList =await _categoryService.GetAllCategories(),
                SearchProduct = _productService.SearchProduct(q, categoryId,pageNo,recordSize),
                Products=_productService.GetAll(x=>!x.IsDeleted),

            };
            int count= _productService.GetCountProducts();
            vm.PageNo = pageNo.Value;
            vm.Pager = new Pager(count, pageNo, recordSize.Value);
            return View(vm);

        }
    }
}
