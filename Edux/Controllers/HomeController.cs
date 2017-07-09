using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Edux.Data;
using Microsoft.AspNetCore.Mvc;
using Edux.Models.PageViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Edux.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string slug)
        {
            if (slug == null)
            {
                return RedirectToAction("Index", "Pages");
            }
            else
            {
                var model = new DisplayViewModel();

                // Getting the page with the slug that user entered
                var page = await _context.Pages
                    .Include(p => p.ParentPage)
                    .Include(p => p.PageComponents)
                        .ThenInclude(pc => pc.Component)
                            .ThenInclude(x => x.ParameterValues)
                                .ThenInclude(x => x.Parameter)
                    .SingleOrDefaultAsync(m => m.Slug.Equals(slug.ToLower()) && m.IsPublished == true);
                model.IsFromHome = true;

                if (page == null)
                {
                    return Content($"'{slug}' Isimli Sayfa Bulunamadi!");
                }
                else
                {
                    // Incrementing the ViewCount
                    page.ViewCount++;
                    _context.SaveChanges();
                    model.Page = page;
                    ViewData["ComponentTypeId"] = new SelectList(_context.ComponentTypes, "Id", "DisplayName");
                    ViewData["ParentComponentId"] = new SelectList(_context.Components, "Id", "DisplayName");
                    return View("/Views/Shared/BaseView.cshtml", model);
                }
            }
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
