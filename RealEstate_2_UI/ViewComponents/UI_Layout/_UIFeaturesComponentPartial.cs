using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_2_UI.Dtos.ProductDtos;

namespace RealEstate_2_UI.ViewComponents.UI_Layout
{
    public class _UIFeaturesComponentPartial: ViewComponent
    {
       public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
