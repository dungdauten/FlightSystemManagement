using Microsoft.AspNetCore.Mvc;

namespace FlightSystemManagement.Areas.Admin.Controllers
{
    public class PlaneAdminController : Controller
    {
        [Area("admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
