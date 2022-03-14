using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AboutUsService
    {
        private readonly ApplicationDbContext _context;

        public AboutUsService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<AboutUs> Get()
        {
            return _context.AboutUss.FirstOrDefault();
        }
        public async Task<AboutUs> GetById(int id)
        {
            var about = _context.AboutUss.FirstOrDefault(x => x.ID == id);
            return about;
        }
        public bool AboutUsExists(int id)
        {
            return _context.AboutUss.Any(e => e.ID == id);
        }
        public async Task Update(AboutUs whyweus)
        {
            _context.AboutUss.Update(whyweus);
            await _context.SaveChangesAsync();
        }
    }
}
