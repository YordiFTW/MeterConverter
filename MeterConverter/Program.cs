using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeterConverter.Data;
using MeterConverter.Enums;
using test.Model;

namespace MeterConverter
{


    class Program
    {
        static void Main(string[] args)
        {
            KeuzeMenuStart();
        }

        private static void KeuzeMenuStart()
        {
            Calculation calculation = new Calculation();

            int keuze;

            Console.WriteLine("1. Meter naar centimeter");
            Console.WriteLine("2. Centimeter naar meter");
            Console.WriteLine("3. Centimeter naar millimeter");
            Console.WriteLine("4. Millimeter naar centimeter");
            Console.WriteLine("5. Meter naar inch");
            Console.WriteLine("6. Inch naar meter");
            Console.WriteLine("7. Afsluiten");

            try
            {
                keuze = Convert.ToInt32(Console.ReadLine());

                Clear();

                KeuzeMenu foo = (KeuzeMenu)keuze;

                calculation.KeuzeMenu = foo;

                KeuzeMenuSwitch(calculation, foo);
            }

            catch
            {
                Clear();
                KeuzeMenuStart();
            }
        }

        public static void KeuzeMenuSwitch(Calculation calculation, KeuzeMenu keuze)
        {
            Console.WriteLine("Vul uw waarde in");
            calculation.Waarde1 = Convert.ToDouble(Console.ReadLine());

            HomeDataService homeDataService = new HomeDataService();
            switch (keuze)
            {
                case KeuzeMenu.MeternaarCentimeter:
                    calculation.Operator = Operator.Times;
                    calculation.Waarde2 = homeDataService.WaardeInvullen(calculation.Waarde1, 100, calculation.Operator);
                    break;
                case KeuzeMenu.CentimeternaarMeter:
                    calculation.Operator = Operator.Devides;
                    calculation.Waarde2 = homeDataService.WaardeInvullen(calculation.Waarde1, 100, calculation.Operator);
                    break;
                case KeuzeMenu.Centimeternaarmillimeter:
                    calculation.Operator = Operator.Times;
                    calculation.Waarde2 = homeDataService.WaardeInvullen(calculation.Waarde1, 10, calculation.Operator);
                    break;
                case KeuzeMenu.MillimeternaarCentimeter:
                    calculation.Operator = Operator.Devides;
                    calculation.Waarde2 = homeDataService.WaardeInvullen(calculation.Waarde1, 10, calculation.Operator);
                    break;
                case KeuzeMenu.MeternaarInch:
                    calculation.Operator = Operator.Times;
                    calculation.Waarde2 = homeDataService.WaardeInvullen(calculation.Waarde1, 39.3700787, calculation.Operator);
                    break;
                case KeuzeMenu.InchnaarMeter:
                    calculation.Operator = Operator.Devides;
                    calculation.Waarde2 = homeDataService.WaardeInvullen(calculation.Waarde1, 39.3700787, calculation.Operator);
                    break;
                case KeuzeMenu.Afsluiten:
                    Console.WriteLine("Case 7");
                    Clear();
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Graag een juist nummer invullen");
                    Clear();
                    KeuzeMenuStart();
                    break;
            }

            Console.WriteLine(calculation.Waarde2.ToString());
            using (StreamWriter w = File.AppendText("log.txt"))
            {
                Log(calculation.Waarde1.ToString(), w);
            }

            using (StreamReader r = File.OpenText("log.txt"))
            {
                DumpLog(r);
            }
            Console.WriteLine();
            Console.WriteLine("press enter to continue");
            Console.ReadLine();
            Clear();

            MenuContinueed(calculation);

            Console.ReadKey();
        }


        

        public static void Log(string logMessage, TextWriter w)
        {
            w.Write("\r\nLog Entry : ");
            w.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
            w.WriteLine("  :");
            w.WriteLine($"  :{logMessage}");
            w.WriteLine("-------------------------------");
        }

        public static void DumpLog(StreamReader r)
        {

        }

        public static void Clear()
        {
            Console.Clear();
        }

        public static void MenuContinueed(Calculation calculation)
        {
            HomeDataService homeDataService = new HomeDataService();

            string caseSwitch;
            Console.WriteLine("1. Opnieuw berekenen");
            Console.WriteLine("2. Terug");
            Console.WriteLine("3. Afsluiten");
            caseSwitch = Console.ReadLine();

            switch (caseSwitch)
            {
                case "1":
                    Console.WriteLine("Case 1");
                    Clear();
                    KeuzeMenuSwitch(calculation, calculation.KeuzeMenu);
                    break;
                case "2":
                    Console.WriteLine("Case 2");
                    Clear();
                    KeuzeMenuStart();
                    break;
                case "3":
                    Console.WriteLine("Case 3");
                    Clear();
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Graag een juist nummer invullen");
                    Clear();
                    MenuContinueed(calculation);
                    break;
            }
        }
    }
    
}
