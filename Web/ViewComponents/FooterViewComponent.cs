using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Services;

namespace Web.ViewComponents
{
    public class FooterViewComponent:ViewComponent
    {
        private readonly StaticFooterService _staticFooterService;

        public FooterViewComponent(StaticFooterService staticFooterService)
        {
            _staticFooterService = staticFooterService;
        }
        public ViewViewComponentResult Invoke()
        {
            var selectedFooter = _staticFooterService.Get();
            return View(selectedFooter);
        }
    }
}
