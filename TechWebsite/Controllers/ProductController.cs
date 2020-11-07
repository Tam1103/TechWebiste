using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechWebsite.Models;

namespace TechWebsite.Controllers
{
    [Route("product")]
    public class ProductController : Controller
    {
        private readonly DatabaseContext db;
        public ProductController(DatabaseContext _db)
        {
            db = _db;
        }
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("productdisplay/{id}")]
        public IActionResult ProductDisplay(int id)
        {
            var category = db.Categories.Find(id);
            ViewBag.nameCategory = category.Name;
            var product = category.Products.Where(s => s.Status).ToList();
            if (!product.Any())
            {
                ViewBag.notification = "Sorry we are updating, Thanks";
            }
            return View("ProductDisplay", product);
        }
        
        [HttpGet]
        [Route("details/{id}")]
        public IActionResult Details(int id)
        {
            var product = db.Products.Find(id);
            return View("Details", product);
        }
    }
}