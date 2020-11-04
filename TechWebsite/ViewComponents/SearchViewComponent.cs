using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechWebsite.Models;

namespace TechWebsite.ViewComponents
{
    [ViewComponent(Name = "Search")]
    public class SearchViewComponent : ViewComponent
    {
        private DatabaseContext db;
        public SearchViewComponent(DatabaseContext _db)
        {
            db = _db;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Category> categories = db.Categories.Where(c => c.Parent == null && c.Status).ToList();
            return View("Index",categories);
        } 
    }
}
