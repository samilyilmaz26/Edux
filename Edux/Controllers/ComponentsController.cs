using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Edux.Data;
using Edux.Models;

namespace Edux.Controllers
{
    public class ComponentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ComponentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Components
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Components.Include(c => c.ComponentType).Include(c => c.ParentComponent);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Components/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var component = await _context.Components
                .Include(c => c.ComponentType)
                .Include(c => c.ParentComponent)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (component == null)
            {
                return NotFound();
            }

            return View(component);
        }

        // GET: Components/Create
        public IActionResult Create()
        {
            ViewData["ComponentTypeId"] = new SelectList(_context.ComponentTypes, "Id", "DisplayName");
            ViewData["ParentComponentId"] = new SelectList(_context.Components, "Id", "DisplayName");
            return View();
        }

        // POST: Components/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("Name,DisplayName,ComponentTypeId,View,ParentComponentId,Id,CreateDate,CreatedBy,UpdateDate,UpdatedBy,AppTenantId")] Component component,
            long? pageID)
        {
            long pageId = 0;
            if (pageID != null)
            {
                pageId = (long)pageID;
            }
            component.CreateDate = DateTime.Now;
            component.CreatedBy = "username";
            if (ModelState.IsValid)
            {
                using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        _context.Add(component);
                        await _context.SaveChangesAsync();
                        var page = _context.Pages.FirstOrDefault(x => x.Id == pageId);
                        var pageComponent = new PageComponent
                        {
                            Page = page,
                            Component = component
                        };
                        _context.PageComponents.Add(pageComponent);
                        await _context.SaveChangesAsync();
                        transaction.Commit();
                        return RedirectToAction("Index");
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
            ViewData["ComponentTypeId"] = new SelectList(_context.ComponentTypes, "Id", "DisplayName", component.ComponentTypeId);
            ViewData["ParentComponentId"] = new SelectList(_context.Components, "Id", "DisplayName", component.ParentComponentId);
            return View(component);
        }

        // An Action for Creating Component Via Ajax Request
        [HttpPost]
        public async Task<IActionResult> CreateService(
            [Bind("Name,DisplayName,ComponentTypeId,View,ParentComponentId,Id,CreateDate,CreatedBy,UpdateDate,UpdatedBy,AppTenantId")] Component component,
            long? pageID)
        {
            long pageId = 0;
            if (pageID != null)
            {
                pageId = (long)pageID;
            }
            component.CreateDate = DateTime.Now;
            component.CreatedBy = "username";
            if (ModelState.IsValid)
            {
                using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        _context.Add(component);
                        await _context.SaveChangesAsync();
                        var page = _context.Pages.FirstOrDefault(x => x.Id == pageId);
                        var pageComponent = new PageComponent
                        {
                            Page = page,
                            Component = component
                        };
                        _context.PageComponents.Add(pageComponent);
                        await _context.SaveChangesAsync();
                        transaction.Commit();
                        return Json(component.Id);
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
            return Json("false");
        }

        // Validates users inputs and returns validate result
        public IActionResult ValidateComponent(Component component)
        {
            ValidationResult validationResult = new ValidationResult();
            component.CreateDate = DateTime.Now;
            component.CreatedBy = "username";
            if (ModelState.IsValid)
            {
                validationResult.code = 200;
                validationResult.message = "OK";
            }
            else
            {
                validationResult.code = 400;
                validationResult.message = "Problem";
            }
            return Json(validationResult);
        }


        // GET: Components/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var component = await _context.Components.SingleOrDefaultAsync(m => m.Id == id);
            if (component == null)
            {
                return NotFound();
            }
            ViewData["ComponentTypeId"] = new SelectList(_context.ComponentTypes, "Id", "DisplayName", component.ComponentTypeId);
            ViewData["ParentComponentId"] = new SelectList(_context.Components, "Id", "DisplayName", component.ParentComponentId);
            return View(component);
        }

        // POST: Components/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Name,DisplayName,ComponentTypeId,View,ParentComponentId,Id,CreateDate,CreatedBy,UpdateDate,UpdatedBy,AppTenantId")] Component component)
        {
            if (id != component.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    component.UpdatedBy = "username";
                    _context.Update(component);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComponentExists(component.Id))
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
            ViewData["ComponentTypeId"] = new SelectList(_context.ComponentTypes, "Id", "Id", component.ComponentTypeId);
            ViewData["ParentComponentId"] = new SelectList(_context.Components, "Id", "Id", component.ParentComponentId);
            return View(component);
        }

        // GET: Components/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var component = await _context.Components
                .Include(c => c.ComponentType)
                .Include(c => c.ParentComponent)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (component == null)
            {
                return NotFound();
            }

            return View(component);
        }

        // POST: Components/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var component = await _context.Components
                .Include(x => x.ParameterValues)
                .Include(x => x.PageComponents)
                .SingleOrDefaultAsync(m => m.Id == id);
            // Deleting the related ParameterValues
            foreach (var pv in component.ParameterValues)
            {
                _context.ParameterValues.Remove(pv);
            }
            _context.Components.Remove(component);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteService(long id)
        {
            try
            {
                var component = await _context.Components
                .Include(x => x.ParameterValues)
                .Include(x => x.PageComponents)
                .SingleOrDefaultAsync(m => m.Id == id);
                // Deleting the related ParameterValues
                foreach (var pv in component.ParameterValues)
                {
                    _context.ParameterValues.Remove(pv);
                }
                _context.Components.Remove(component);
                await _context.SaveChangesAsync();
                return Json("true");
            }
            catch (Exception ex)
            {
                return Json("false");
            }
        }

        // Generates Modal Body for ParameterValues
        public async Task<IActionResult> GetHtmlForParamValues(long componentID, long pageID)
        {
            var component = _context.Components.FirstOrDefault(x => x.Id == componentID);
            var parameters = await _context.Parameters
                .Where(x => x.ComponentTypeId == component.ComponentTypeId)
                .ToListAsync();
            parameters.Sort((x, y) => x.Position.CompareTo(y.Position));

            var model = new ComponentViewModel
            {
                PageID = pageID,
                Parameters = parameters
            };
            return View(model);
        }

        private bool ComponentExists(long id)
        {
            return _context.Components.Any(e => e.Id == id);
        }
    }
}
