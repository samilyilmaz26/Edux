using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Edux.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore;
using Edux.Models;

namespace Edux.ViewComponents
{
    public class DataGridViewComponent : ViewComponent
    {
        private ApplicationDbContext context;
        public DataGridViewComponent(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(List<ParameterValue> parameterValues)
        {
            await context.Pages.ToListAsync();
            return View(parameterValues);
        }
    }
}
