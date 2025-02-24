using Microsoft.AspNetCore.Mvc;

namespace RealEstate_2_UI.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
