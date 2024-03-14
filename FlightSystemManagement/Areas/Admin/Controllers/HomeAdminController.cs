using Microsoft.AspNetCore.Mvc;

namespace FlightSystemManagement.Areas.Admin.Controllers
{
    public class HomeAdminController : Controller
    {
        [Area("admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
