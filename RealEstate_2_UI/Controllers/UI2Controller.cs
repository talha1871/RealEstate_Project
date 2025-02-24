using Microsoft.AspNetCore.Mvc;

namespace RealEstate_2_UI.Controllers
{
    public class UI2Controller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
