using Entities;
using Web.Helpers;

namespace Web.ViewModels
{
    public class ProductSearchVM
    {
        public List<Category> CategoryList { get; set; }
        public List<Product>? SearchProduct { get; set; }
        public List<Product> Products { get; set; }
        public Pager Pager { get; set; }
        public int? PageNo { get; set; }
        public int? PageSize { get; set; }
    }
}
