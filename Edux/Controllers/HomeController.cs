using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Edux.Data;
using Microsoft.AspNetCore.Mvc;

namespace Edux.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string slug)
        {
            if (slug == null)
            {
                return View();
            }
            else
            {
                string slugLower = slug.ToLower();
                var page = _context.Pages.FirstOrDefault(x => x.Slug.ToLower().Equals(slugLower));
                if (page == null)
                {
                    return Content($"'{slug}' isimli sayfa bulunamadi!");
                }
                else
                {
                    return View(page.View);
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
