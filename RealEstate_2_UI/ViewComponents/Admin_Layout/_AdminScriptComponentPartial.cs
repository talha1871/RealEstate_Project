using Microsoft.AspNetCore.Mvc;

namespace RealEstate_2_UI.ViewComponents.Admin_Layout
{
    public class _AdminScriptComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
