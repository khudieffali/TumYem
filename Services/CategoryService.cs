using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CategoryService
    {
        private readonly ApplicationDbContext _context;

        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Category>> GetAllCategories()
        {
            return _context.Categories.Where(x=>!x.IsDeleted).ToList();
        }
        public async Task<Category> GetById(int? id)
        {
            var selectedCategory =_context.Categories.Where(x => !x.IsDeleted).FirstOrDefault(x => x.ID == id);
            if (selectedCategory == null) return null;
            return selectedCategory;
        }
        public async Task Add(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }
        public async Task Update(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(Category category)
        {
            category.IsDeleted = true;
            await _context.SaveChangesAsync();
        }
        public bool CategoryExists(int id)
        {
            return _context.Categories.Any(x => x.ID == id);
        }

    }
}
