using Microsoft.AspNetCore.Mvc;

namespace RealEstate_2_UI.ViewComponents.UI_Layout
{
    public class _UIHeaderComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
             return View();
        }
    }
}
