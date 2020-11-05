﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TechWebsite.Areas.Admin.Models.ViewModels;
using TechWebsite.Models;
using static System.Net.Mime.MediaTypeNames;

namespace TechWebsite.Areas.Admin.Controllers
{

    [Authorize(Roles = "Admin")]
    [Area("admin")]
    [Route("admin/product")]
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
            var product = db.Products.ToList();
            return View("index", product);
        }

        [HttpGet]
        [Route("add")]
        public IActionResult Add()
        {
            var productViewModel = new ProductViewModel();
            productViewModel.Product = new Product();
            productViewModel.Categories = new List<SelectListItem>();

            var categories = db.Categories.ToList();
            foreach (var category in categories)
            {
                var group = new SelectListGroup { Name = category.Name };
                if (category.InverseParents != null && category.InverseParents.Count() != 0)
                {
                    foreach (var subCategory in category.InverseParents)
                    {
                        var selectListItem = new SelectListItem
                        {
                            Text = subCategory.Name,
                            Value = subCategory.Id.ToString(),
                            Group = group
                        };

                        productViewModel.Categories.Add(selectListItem);
                    }
                }
            }
            return View("Add", productViewModel);
        }

        [HttpPost]
        [Route("add")]
        public IActionResult Add(ProductViewModel productViewModel)
        {
            db.Products.Add(productViewModel.Product);
            db.SaveChanges();
            return RedirectToAction("index", "product", new { area = "admin" });
        }

        [HttpGet]
        [Route("edit/{id}")]
        public IActionResult Edit(int id)
        {
            var product = db.Products.Find(id);
            return View("Edit",product);
        }

        [HttpPut]
        [Route("edit")]
        public IActionResult Edit(ProductViewModel productViewModel)
        {
            return RedirectToAction("index", "product", new { area = "admin" });
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("index", "product", new { area = "admin" });
        }

    }
}