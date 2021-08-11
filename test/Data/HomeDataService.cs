using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using test.DbContexts;

namespace test.Data
{
    public class HomeDataService : IHomeDataService
    {
        private readonly MeterDbContext db;

        public HomeDataService (MeterDbContext db)
        {
            this.db = db;
        }

        public double WaardeInvullen(double waarde1, double waarde2, string operation)
        {
            string waarde1text;

            NumberStyles style;
            CultureInfo culture;

            waarde1text = waarde1.ToString();

            try
            {
                style = NumberStyles.AllowDecimalPoint;
                culture = CultureInfo.CreateSpecificCulture("nl-NL");
                if (Double.TryParse(waarde1text, style, culture, out waarde1))
                {

                }
                else
                {
                    WaardeInvullen(waarde1, waarde2, operation);
                }
            }

            catch (FormatException e)
            {
            }

            if (operation == "delen")
            {
                waarde1 = waarde1 / waarde2;
            }

            else
            {
                waarde1 = waarde1 * waarde2;
            }

            using (StreamWriter w = File.AppendText("log.txt"))
            {
                Log(waarde1.ToString(), w);
            }

            return waarde1;

        }

        private static void DumpLog(StreamReader r)
        {
            throw new NotImplementedException();
        }

        private void Log(string logMessage, StreamWriter w)
        {
            w.Write("\r\nLog Entry : ");
            w.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
            w.WriteLine("  :");
            w.WriteLine($"  :{logMessage}");
            w.WriteLine("-------------------------------");
        }

        
    }
}
