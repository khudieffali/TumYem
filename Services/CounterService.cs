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
    public class CounterService
    {
        private readonly ApplicationDbContext _context;

        public CounterService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Counter>> Get()
        {
            return _context.Counters.Take(4).ToList();
        }
        public async Task<Counter> GetById(int id)
        {
            var counter = await _context.Counters.FirstOrDefaultAsync(x => x.ID == id);
            if (counter == null) return null;
            return counter;
        }
        public async Task Update(Counter counter)
        {
            _context.Counters.Update(counter);
            await _context.SaveChangesAsync();
        }
        public bool CounterExists(int id)
        {
            return _context.Counters.Any(e => e.ID == id);
        }
    }
}
