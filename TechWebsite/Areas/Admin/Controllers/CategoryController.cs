using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechWebsite.Models;

namespace TechWebsite.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("admin")]
    [Route("admin/category")]
    public class CategoryController : Controller
    {
        private DatabaseContext db = new DatabaseContext();
        public CategoryController(DatabaseContext _db)
        {
            db = _db;
        }

        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            ViewBag.categories = db.Categories.Where(c => c.Parent == null).ToList();
            return View();
        }

        [Route("add")]
        [HttpGet]
        public IActionResult Add()
        {
            var category = new Category();
            return View("Add", category);
        }


        [Route("add")]
        [HttpPost]
        public IActionResult Add(Category category)
        {
            category.Parent = null;
            db.Categories.Add(category);
            db.SaveChanges();
            return RedirectToAction("index", "category", new { area = "admin" });
        }

        [HttpGet]
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var categories = db.Categories.Find(id);
            db.Categories.Remove(categories);
            db.SaveChanges();
            return RedirectToAction("index", "category", new { area = "admin" });
        }

        [HttpGet]
        [Route("edit/{id}")]
        public IActionResult Edit(int id)
        {
            var categories = db.Categories.Find(id);
            return View("Edit", categories);
        }

        [HttpPost]
        [Route("edit/{id}")]
        public IActionResult Edit(int id,Category category)
        {
            var currentCategory = db.Categories.Find(id);
            category.Name = category.Name;
            category.Status = category.Status;
            db.SaveChanges();
            return RedirectToAction("index", "category", new { area = "admin" });
        }
    }
}