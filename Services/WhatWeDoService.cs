using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class WhatWeDoService
    {
        private readonly ApplicationDbContext _context;

        public WhatWeDoService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<WhatWeDo> Get()
        {
            return _context.WhatWeDos.FirstOrDefault();
        }
        public async Task<WhatWeDo> GetById(int id)
        {
            return _context.WhatWeDos.FirstOrDefault(x=>x.ID==id);
        }
        public bool WhatWeDoExists(int id)
        {
            return _context.WhatWeDos.Any(e => e.ID == id);
        }
        public async Task Update(WhatWeDo whatwedo)
        {
             _context.WhatWeDos.Update(whatwedo);
            await _context.SaveChangesAsync();
        }
    }
}
