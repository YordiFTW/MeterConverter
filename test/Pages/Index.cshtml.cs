using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using test.Data;
using test.DbContexts;
using test.Enums;
using test.Model;

namespace test.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IHomeDataService homeDataService;
        private readonly MeterDbContext _context;

        public IndexModel(IHomeDataService homeDataService, MeterDbContext context)
        {
            this.homeDataService = homeDataService;
            _context = context;
        }

        

        [BindProperty]
       
        public Calculation Calculation { get; set; }

        public string CheckPointer { get; set; }

        [ViewData]
        public bool showvalue { get; set; }


        public void OnGet()
        {
            _context.Calculations.ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            CheckPointer = Calculation.Waarde1.ToString();
            if (!ModelState.IsValid || Calculation.Waarde1 >= 9999999999999)
            {
                Convert.ToDouble(Calculation.Waarde2);
                Calculation.Error = "Ongeldig Nummer!";
                Calculation.Datum = DateTime.Now;
                _context.Calculations.Add(Calculation);
                await _context.SaveChangesAsync();
                return Page();
            }
            else
            {

                switch (Calculation.KeuzeMenu)
                {
                    case KeuzeMenu.MeternaarCentimeter:
                        Calculation.Waarde2 = homeDataService.WaardeInvullen(Calculation.Waarde1, 100, "keer");
                        break;
                    case KeuzeMenu.CentimeternaarMeter:
                        Calculation.Waarde2 = homeDataService.WaardeInvullen(Calculation.Waarde1, 100, "keer");
                        break;
                    case KeuzeMenu.Centimeternaarmillimeter:
                        Calculation.Waarde2 = homeDataService.WaardeInvullen(Calculation.Waarde1, 10, "delen");
                        break;
                    case KeuzeMenu.MillimeternaarCentimeter:
                        Calculation.Waarde2 = homeDataService.WaardeInvullen(Calculation.Waarde1, 10, "keer");
                        break;
                    case KeuzeMenu.MeternaarInch:
                        Calculation.Waarde2 = homeDataService.WaardeInvullen(Calculation.Waarde1, 39.037007874, "keer");
                        break;
                    case KeuzeMenu.InchnaarMeter:
                        Calculation.Waarde2 = homeDataService.WaardeInvullen(Calculation.Waarde1, 39.037007874, "delen");
                        break;
                    default:
                        break;
                }
            }

            Calculation.Datum = DateTime.Now;
            _context.Calculations.Add(Calculation);
            await _context.SaveChangesAsync();

            return Page();
            //Calculation.Waarde2 = homeDataService.WaardeInvullen(Calculation.Waarde1, "delen");
        }


       
    }
}
