using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class WhyWeUsService
    {
        private readonly ApplicationDbContext _context;

        public WhyWeUsService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<WhyWeUs> Get()
        {
            return _context.WhyWeUss.FirstOrDefault();
        }
        public async Task<WhyWeUs> GetById(int id)
        {
            var whyweus=_context.WhyWeUss.FirstOrDefault(x=>x.ID==id);
            return whyweus;
        }
        public bool WhyWeUsExists(int id)
        {
            return _context.WhyWeUss.Any(e => e.ID == id);
        }
        public async Task Update(WhyWeUs whyweus)
        {
            _context.WhyWeUss.Update(whyweus);
            await _context.SaveChangesAsync();
        }
    }
}
