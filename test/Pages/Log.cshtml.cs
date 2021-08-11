using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using test.DbContexts;
using test.Model;

namespace test.Pages
{
    public class LogModel : PageModel
    {
        private readonly MeterDbContext _context;

        public LogModel(MeterDbContext context)
        {
            _context = context;
        }

        public IList<Calculation> Calculation { get; set; }

        public async Task OnGetAsync()
        {
            Calculation = await _context.Calculations.ToListAsync();
        }
    }
}
