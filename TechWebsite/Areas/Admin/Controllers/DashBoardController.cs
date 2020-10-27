using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TechWebsite.Areas.Admin.Controllers
{
    [Authorize(Roles = "")]
    [Area("admin")]
    [Route("admin/dashboard")]

    public class DashBoardController : Controller
    {

        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}