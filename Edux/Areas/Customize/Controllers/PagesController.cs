using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Edux.Data;
using Edux.Models;

namespace Edux.Areas.Customize.Controllers
{
    [Area("Customize")]
    public class PagesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PagesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Customize/Pages
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Pages.Include(p => p.ParentPage);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Customize/Pages/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var page = await _context.Pages
                .Include(p => p.ParentPage)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (page == null)
            {
                return NotFound();
            }

            return View(page);
        }

        // GET: Customize/Pages/Create
        public IActionResult Create()
        {
            var page = new Page();
            ViewData["ParentPageId"] = new SelectList(_context.Pages, "Id", "Title");
            return View(page);
        }

        // POST: Customize/Pages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Slug,View,LayoutView,ParentPageId,MetaTitle,MetaDescription,MetaKeywords,IsPublished,ViewCount,Position,AllowedRoles,Id,CreateDate,CreatedBy,UpdateDate,UpdatedBy,AppTenantId")] Page page)
        {
            if (ModelState.IsValid)
            {
                _context.Add(page);
                await _context.SaveChangesAsync();
                return RedirectToAction("Edit", new { id = page.Id });
            }
            ViewData["ParentPageId"] = new SelectList(_context.Pages, "Id", "Title", page.ParentPageId);
            return View(page);
        }

        // GET: Customize/Pages/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var page = await _context.Pages.SingleOrDefaultAsync(m => m.Id == id);
            if (page == null)
            {
                return NotFound();
            }
            ViewData["Title"] = page.Title;
            ViewData["ParentPageId"] = new SelectList(_context.Pages, "Id", "Id", page.ParentPageId);
            return View(page);
        }

        // POST: Customize/Pages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Title,Slug,View,LayoutView,ParentPageId,MetaTitle,MetaDescription,MetaKeywords,IsPublished,ViewCount,Position,AllowedRoles,Id,CreateDate,CreatedBy,UpdateDate,UpdatedBy,AppTenantId")] Page page)
        {
            if (id != page.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(page);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PageExists(page.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["ParentPageId"] = new SelectList(_context.Pages, "Id", "Id", page.ParentPageId);
            return View(page);
        }

        // GET: Customize/Pages/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var page = await _context.Pages
                .Include(p => p.ParentPage)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (page == null)
            {
                return NotFound();
            }

            return View(page);
        }

        // POST: Customize/Pages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var page = await _context.Pages.SingleOrDefaultAsync(m => m.Id == id);
            _context.Pages.Remove(page);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool PageExists(long id)
        {
            return _context.Pages.Any(e => e.Id == id);
        }
    }
}
