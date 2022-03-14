using DataAccess;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Product> GetAll(Func<Product,bool> filter=null)
        {
            return _context.Products
                .Where(x=>!x.IsDeleted)
                .Include(x=>x.Category)
                .Where(filter)
                .OrderByDescending(x=>x.PublishDate)
                .Take(4)
                .ToList();
        }
        public int GetCountProducts()
        {
            return _context.Products.Where(x=>!x.IsDeleted).Count();
        }
        public List<Product> GetAllAdmin(Func<Product, bool> filter = null)
        {
            return _context.Products
                .Where(x => !x.IsDeleted)
                .Include(x => x.Category)
                .Where(filter)
                .OrderByDescending(x => x.PublishDate)
                .ToList();
        }

        public async Task<Product> GetById(int id)
        {
            var selectedProduct=await _context.Products
                .Where(x => !x.IsDeleted)
                .Include(x => x.Category)
                .FirstOrDefaultAsync(x=>x.ID==id); 
            if(selectedProduct==null) return null;
            return selectedProduct;
        }
        public List<Product> SearchProduct(string? q, int? categoryId, int? pageNo, int? recordSize)
        {
            int skipCount = (pageNo.Value-1) * recordSize.Value;
            var products = _context.Products
                .Where(x => !x.IsDeleted)
                .Include(x => x.Category)
                .AsQueryable();
            if(categoryId != null)
            {
                products=products.Where(x=>x.CategoryID==categoryId);
            }
            if (!string.IsNullOrWhiteSpace(q))
            {
                products = products.Where(x => x.Name.Contains(q) || x.Category.Name.ToLower().Contains(q.ToLower()));
            }
          
            return products.OrderByDescending(x=>x.PublishDate).Skip(skipCount).Take(recordSize.Value).ToList();
        }
        public async Task Add(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }
        public async Task Update(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }
        public void Delete(Product product)
        {
            product.IsDeleted = true;
            _context.SaveChanges();
        }
        public bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ID == id);
        }
    }
}
