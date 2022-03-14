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
    public class StaticFooterService
    {
        private readonly ApplicationDbContext _context;

        public StaticFooterService(ApplicationDbContext context)
        {
            _context = context;
        }
        public StaticFooter Get()
        {
            return _context.StaticFooters.FirstOrDefault();
        }
        public async Task<StaticFooter> GetById(int id)
        {
            return await _context.StaticFooters.FirstOrDefaultAsync(x => x.ID == id);
        }
        public bool StaticFooterExists(int id)
        {
            return _context.StaticFooters.Any(e => e.ID == id);
        }
        public async Task Update(StaticFooter staticFooter)
        {
            _context.StaticFooters.Update(staticFooter);
            await _context.SaveChangesAsync();
        }
    }
}
