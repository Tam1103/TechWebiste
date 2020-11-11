using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechWebsite.Models;

namespace TechWebsite.Controllers
{
    [Route("home")]
    public class HomeController : Controller
    {
        private readonly DatabaseContext db;
        public HomeController(DatabaseContext _db)
        {
            db = _db;
        }

        [Route("")]
        [Route("index")]
        [Route("~/")]
        public IActionResult Index()
        {
            var product = db.Products.OrderByDescending(p => p.Id).Where(p => p.Status).Take(4).ToList();
            return View("Index",product);
        }
        
    }
}