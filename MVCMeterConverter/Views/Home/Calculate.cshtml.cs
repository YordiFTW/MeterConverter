using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MVCMeterConverter.DbContexts;

namespace MVCMeterConverter.Views.Home
{
    public class CalculateModel : PageModel
    {
        private readonly MeterDbContext _context;

        public CalculateModel(MeterDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
