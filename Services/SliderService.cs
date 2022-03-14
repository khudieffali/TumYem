using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class SliderService
    {
        private readonly ApplicationDbContext _context;

        public SliderService(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Slider> GetAllSliders(Func<Slider, bool> filter=null)
        {
            return _context.Sliders.Where(x=>!x.IsDeleted).Where(filter).Take(2).ToList();
        }
        public List<Slider> GetAllSlidersAdmin(Func<Slider, bool> filter = null)
        {
            return _context.Sliders.Where(x => !x.IsDeleted).Where(filter).ToList();
        }
        public async Task<Slider> GetById(int? id)
        {
            var selectedSlider = _context.Sliders.Where(x => !x.IsDeleted).FirstOrDefault(x => x.ID == id.Value);
            if (selectedSlider == null)return null;
            return selectedSlider;  

        }
        public async Task Add(Slider slider)
        {
            await _context.Sliders.AddAsync(slider);
            await _context.SaveChangesAsync();
        }
        public async Task Update(Slider slider)
        {
            _context.Sliders.Update(slider);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(Slider slider)
        {
            slider.IsDeleted = true;
            await _context.SaveChangesAsync();
        }
        public bool SliderExists(int id)
        {
            return _context.Sliders.Any(e => e.ID == id);
        }
    }
}
