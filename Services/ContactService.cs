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
    public class ContactService
    {
        private readonly ApplicationDbContext _context;

        public ContactService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Contact>> GetAll()
        {
            return await _context.Contacts.Where(x=>!x.IsDeleted).Take(3).ToListAsync();
        }
        public async Task<List<Contact>> GetAllAdmin()
        {
            return await _context.Contacts.Where(x => !x.IsDeleted).ToListAsync();
        }

        public async Task<Contact> GetById(int id)
        {
            return _context.Contacts.Where(x => !x.IsDeleted).FirstOrDefault(x => x.ID == id);
        }
        public async Task Add(Contact contact)
        {
            await _context.Contacts.AddAsync(contact);
            await _context.SaveChangesAsync();
        }
        public async Task Update(Contact contact)
        {
            _context.Contacts.Update(contact);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(Contact contact)
        {
            contact.IsDeleted = true;
            await _context.SaveChangesAsync();
        }
        public bool ContactExists(int id)
        {
            return _context.Contacts.Any(e => e.ID == id);
        }
    }
}
