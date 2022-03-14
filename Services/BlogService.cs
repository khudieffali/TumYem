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
    public class BlogService
    {
        private readonly ApplicationDbContext _context;

        public BlogService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Blog>> GetBlogs()
        {
            return _context.Blogs.Where(x=>!x.IsDeleted).OrderByDescending(x=>x.PublishDate).Take(3).ToList();
        }
        public async Task<List<Blog>> GetBlogsAdmin()
        {
            return await _context.Blogs.Where(x => !x.IsDeleted).OrderByDescending(x => x.PublishDate).ToListAsync();
        }

        public async Task<Blog> GetById(int id)
        {
            return _context.Blogs.Where(x=>!x.IsDeleted).FirstOrDefault(x=>x.ID==id);
        }
        public async Task Add(Blog blog)
        {
            await _context.Blogs.AddAsync(blog);
            blog.PublishDate = DateTime.Now;
            await _context.SaveChangesAsync();
        }
        public async Task Update(Blog blog)
        {
            _context.Blogs.Update(blog);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(Blog blog)
        {
            blog.IsDeleted = true;
            await _context.SaveChangesAsync();
        }
        public bool BlogExists(int id)
        {
            return _context.Blogs.Any(e => e.ID == id);
        }
    }
}
