﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechWebsite.Models;

namespace TechWebsite.ViewComponents
{
    [ViewComponent(Name = "SlideShow")]
    public class SlideShowViewComponent : ViewComponent
    {
        private DatabaseContext db;
        public SlideShowViewComponent(DatabaseContext _db)
        {
            db = _db;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<SlideShow> slideshow = db.SlideShows.Where(s => s.Status).ToList();
            return View("Index", slideshow);
        }
    }
}
