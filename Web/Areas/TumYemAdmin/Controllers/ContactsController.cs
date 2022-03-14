#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Entities;
using Services;
using Microsoft.AspNetCore.Authorization;

namespace Web.Areas.TumYemAdmin.Controllers
{
    [Area("TumYemAdmin")]
    [Authorize(Roles = "admin")]
    public class ContactsController : Controller
    {
        private readonly ContactService _contactService;

        public ContactsController(ContactService contactService)
        {
            _contactService = contactService;
        }

        // GET: TumYemAdmin/Contacts
        public async Task<IActionResult> Index()
        {
            return View(await _contactService.GetAllAdmin());
        }

        // GET: TumYemAdmin/Contacts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();
            

            var contact = await _contactService.GetById(id.Value);
            if (contact == null)
                return NotFound();
            return View(contact);
        }

        // GET: TumYemAdmin/Contacts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TumYemAdmin/Contacts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WeAddress,PhoneNumber,Email,IsDeleted,ID")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                await _contactService.Add(contact);
                return RedirectToAction(nameof(Index));
            }
            return View(contact);
        }

        // GET: TumYemAdmin/Contacts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();
            var contact = await _contactService.GetById(id.Value);
            if (contact == null)
                return NotFound();
            return View(contact);
        }

        // POST: TumYemAdmin/Contacts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WeAddress,PhoneNumber,Email,IsDeleted,ID")] Contact contact)
        {
            if (id != contact.ID)
                return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    await _contactService.Update(contact);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_contactService.ContactExists(contact.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(contact);
        }

        // GET: TumYemAdmin/Contacts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            var contact = await _contactService.GetById(id.Value);
            if (contact == null)
                return NotFound();
            return View(contact);
        }

        // POST: TumYemAdmin/Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contact = await _contactService.GetById(id);
           if(contact == null)return NotFound();
            await _contactService.Delete(contact);
            return RedirectToAction(nameof(Index));
        }

       
    }
}
