using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MeterConverter.DbContexts;
using MeterConverter.Enums;

namespace MeterConverter.Data
{
    public class HomeDataService : IHomeDataService
    {
        private readonly MeterDbContext db;

        public HomeDataService (MeterDbContext db)
        {
            this.db = db;
        }

        public HomeDataService()
        {
        }

        public double WaardeInvullen(double waarde1, double waarde2, Operator operation)
        {
            string waarde1text;

            NumberStyles style;
            CultureInfo culture;

            waarde1text = waarde1.ToString();

            //Console.WriteLine("Vul waarde in");
            try
            {

                //waarde1 = Convert.ToDouble(Console.ReadLine());
                //waarde1text = Console.ReadLine();

                //waarde1text = waarde1text.Replace(".", ",");

                style = NumberStyles.AllowDecimalPoint;
                culture = CultureInfo.CreateSpecificCulture("nl-NL");
                if (Double.TryParse(waarde1text, style, culture, out waarde1))
                {
                    //Console.WriteLine("Converted '{0}' to {1}.", waarde1text, waarde1);
                }
                else
                {
                    //Clear();
                    WaardeInvullen(waarde1, waarde2, operation);
                }
            }

            catch (FormatException e)
            {
                //Console.WriteLine(e.Message);
                //using (StreamWriter w = File.AppendText("log.txt"))
                //{
                //    Log(e.Message, w);
                //}
            }

            if (operation == Operator.Devides)
            {
                waarde1 = waarde1 / waarde2;
            }

            else
            {
                waarde1 = waarde1 * waarde2;
            }

            //Console.WriteLine(waarde1.ToString());

            using (StreamWriter w = File.AppendText("log.txt"))
            {
                Log(waarde1.ToString(), w);
            }

            //using (StreamReader r = File.OpenText("log.txt"))
            //{
            //    DumpLog(r);
            //}

            //caseSwitch = MenuContinueed(waarde2, operation);

            return waarde1;

        }

        //private static void Clear()
        //{
        //    Console.Clear();
        //}

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
