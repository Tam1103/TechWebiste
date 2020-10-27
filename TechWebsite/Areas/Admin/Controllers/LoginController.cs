using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TechWebsite.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/login")]
    public class LoginController : Controller
    {
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }


        [Route("")]
        [Route("signout")]
        public IActionResult SignOut()
        {
            return View();
        }


        [Route("")]
        [Route("accessdenied")]
        public IActionResult Accessdenied()
        {
            return View();
        }
    }
}