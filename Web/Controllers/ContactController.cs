using Microsoft.AspNetCore.Mvc;
using Services;
using Web.ViewModels;

namespace Web.Controllers
{
    public class ContactController : Controller
    {
        private readonly ContactService _contactService;

        public ContactController(ContactService contactService)
        {
            _contactService = contactService;
        }

        public async Task<IActionResult> Contact()
        {
            ContactVM vm = new()
            {
                Contacts=await _contactService.GetAll()
            };
            return View(vm);
        }
    }
}
