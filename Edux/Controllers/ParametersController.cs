using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Edux.Data;
using Edux.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Edux.Controllers
{
    public class ParametersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ParametersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Parameters
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Parameters.Include(p => p.ComponentType);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Parameters/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parameter = await _context.Parameters
                .Include(p => p.ComponentType)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (parameter == null)
            {
                return NotFound();
            }

            return View(parameter);
        }

        // GET: Parameters/Create
        public IActionResult Create()
        {
            ViewData["ComponentTypeId"] = new SelectList(_context.ComponentTypes, "Id", "DisplayName");
            return View();
        }

        // POST: Parameters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,DisplayName,IsRequired,ComponentTypeId,Position,Id,CreateDate,CreatedBy,UpdateDate,UpdatedBy,AppTenantId")] Parameter parameter)
        {
            parameter.CreateDate = DateTime.Now;
            parameter.CreatedBy = "username";
            if (ModelState.IsValid)
            {
                _context.Add(parameter);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["ComponentTypeId"] = new SelectList(_context.ComponentTypes, "Id", "DisplayName", parameter.ComponentTypeId);
            return View(parameter);
        }

        // GET: Parameters/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parameter = await _context.Parameters.SingleOrDefaultAsync(m => m.Id == id);
            if (parameter == null)
            {
                return NotFound();
            }
            ViewData["ComponentTypeId"] = new SelectList(_context.ComponentTypes, "Id", "DisplayName", parameter.ComponentTypeId);
            return View(parameter);
        }

        // POST: Parameters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Name,DisplayName,IsRequired,ComponentTypeId,Position,Id,CreateDate,CreatedBy,UpdateDate,UpdatedBy,AppTenantId")] Parameter parameter)
        {
            if (id != parameter.Id)
            {
                return NotFound();
            }

            parameter.UpdatedBy = "username";
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parameter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParameterExists(parameter.Id))
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
            ViewData["ComponentTypeId"] = new SelectList(_context.ComponentTypes, "Id", "DisplayName", parameter.ComponentTypeId);
            return View(parameter);
        }

        // GET: Parameters/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parameter = await _context.Parameters
                .Include(p => p.ComponentType)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (parameter == null)
            {
                return NotFound();
            }

            return View(parameter);
        }

        // POST: Parameters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var parameter = await _context.Parameters.SingleOrDefaultAsync(m => m.Id == id);
            _context.Parameters.Remove(parameter);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> CreateParameterValue(ParameterValue parameterValue)
        {
            if (ModelState.IsValid)
            {
                _context.Add(parameterValue);
                await _context.SaveChangesAsync();
                return Json("true");
            }
            return Json("false");
        }

        private bool ParameterExists(long id)
        {
            return _context.Parameters.Any(e => e.Id == id);
        }
    }
}
