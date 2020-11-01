using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TechWebsite.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("admin")]
    [Route("admin/dashboard")]

    public class DashBoardController : Controller
    {

        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}