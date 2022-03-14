using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AboutUsTextService
    {
        private readonly ApplicationDbContext _context;

        public AboutUsTextService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<AboutUsText>> Get()
        {
            return  _context.AboutUsTexts.Where(x=>!x.IsDeleted).Take(6).ToList();  
        }
        public async Task<List<AboutUsText>> GetAdmin()
        {
            return _context.AboutUsTexts.Where(x=>!x.IsDeleted).ToList();
        }
        public async Task<AboutUsText> GetById(int? id)
        {
            var aboutUsText = _context.AboutUsTexts.Where(x => !x.IsDeleted).FirstOrDefault(x => x.ID == id.Value);
            if (aboutUsText == null) return null;
            return aboutUsText;

        }
        public async Task Add(AboutUsText about)
        {
            await _context.AboutUsTexts.AddAsync(about);
            await _context.SaveChangesAsync();
        }
        public async Task Update(AboutUsText about)
        {
            _context.AboutUsTexts.Update(about);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(AboutUsText about)
        {
            about.IsDeleted = true;
            await _context.SaveChangesAsync();
        }
        public bool AboutUsTextExists(int id)
        {
            return _context.AboutUsTexts.Any(e => e.ID == id);
        }
    }
}
