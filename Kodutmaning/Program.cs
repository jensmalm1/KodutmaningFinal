﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Kodutmaning
{

    public class Program
    {
        public static FordonsTyp GetFordonsTyp()
        {
            int i;
            while (true)
            {
                Console.WriteLine("Ange fordonstyp: \n1.Personbil\n2.Lastbil\n3.Motorcykel");
                i = Int32.Parse(Console.ReadLine());
                if (i <= 3 && i >= 1)
                {
                    break;
                }
            }

            var input = FordonsTyp.Personbil;

            switch (i)
            {
                case 1:
                    input = FordonsTyp.Personbil;
                    break;
                case 2:
                    input = FordonsTyp.Lastbil;
                    break;
                case 3:
                    input = FordonsTyp.Motorcykel;
                    break;
            }
            Console.Clear();
            return input;
        }

        public static double GetVikt()
        {
            Console.WriteLine("Ange vikt i kg: ");
            double vikt = double.Parse(Console.ReadLine());
            Console.Clear();
            return vikt;

        }

        public static DateTime GetTid()
        {
            string input;

            while (true)
            {
                Console.WriteLine("Ange tid: (yyyy-mm-dd tt:mm)");
                input = Console.ReadLine();
                if (new Regex(@"^[12][\d]{3}[-][01][\d][-][0123][\d][\s][012][\d][:][\d]{2}").Match(input).Success)
                {
                    break;
                }

            }
            Console.Clear();
            return DateTime.Parse(input);
        }

        public static bool GetMiljöKlass()
        {
            bool svar;
            while (true)
            {
                Console.WriteLine("Är fordonet miljöklassat? (ja/nej)");
                string input = Console.ReadLine();
                if (input.ToLower() == "ja")
                {
                    svar = true;
                    break;
                }
                else if (input.ToLower() == "nej")
                {
                    svar = false;
                    break;
                }

            }
            Console.Clear();
            return svar;
        }

        public static double PrisInräknatVikt(double vikt)
        {
            double pris = 1000;
            if (vikt < 1000)
                pris = 500;
            return pris;
        }

        public static double PrisInräknatTid(double pris, DateTime tid)
        {

            if (tid.DayOfWeek != DayOfWeek.Saturday && tid.DayOfWeek != DayOfWeek.Sunday)
            {
                if (tid.Hour > 18 || tid.Hour < 06)
                {
                    pris = pris * 0.5;
                }

            }

            return pris;
        }

        public static double PrisInräknatFordonsTyp(double pris, FordonsTyp fordonsTyp)
        {

            if (fordonsTyp == FordonsTyp.Lastbil)
            {
                pris = 2000;
            }

            if (fordonsTyp == FordonsTyp.Motorcykel)
            {
                pris = pris * 0.7;
            }

            return pris;
        }

        public static double PrisInräknatDag(double pris, DayOfWeek dag)
        {
            if (dag == DayOfWeek.Saturday || dag == DayOfWeek.Sunday)
            {
                pris = pris * 2;

            }

            return pris;
        }

        public static double PrisInräknatMiljöKlass(double pris, bool miljöKlass)
        {
            if (miljöKlass)
                pris = 0;
            return pris;
        }

        public static double TullPris(Fordon fordon)
        {
            double prisVikt = PrisInräknatVikt(fordon.Vikt);
            double prisTid = PrisInräknatTid(prisVikt, fordon.TidVidTullen);
            double prisFordonsTyp = PrisInräknatFordonsTyp(prisTid, fordon.FordonsTyp);
            double prisDag = PrisInräknatDag(prisFordonsTyp, fordon.TidVidTullen.DayOfWeek);
            double prisMiljöKlass = PrisInräknatMiljöKlass(prisDag, fordon.MiljöKlassad);
            double tullPris = Math.Round(PrisInräknatMiljöKlass(prisMiljöKlass, fordon.MiljöKlassad));

            return tullPris;

        }



        public static void DisplaySummary(Fordon fordon, double tullPris)
        {

            Console.WriteLine($"\n{"Vikt: ",-20}{fordon.Vikt,-20}\n" +
                              $"{"Tidpunkt: ",-20}{fordon.TidVidTullen.TimeOfDay,-20}\n" +
                              $"{"Fordonstyp: ",-20}{fordon.FordonsTyp,-20}\n" +
                              $"{"Dag: ",-20}{fordon.TidVidTullen.DayOfWeek,-20}\n" +
                              $"{"Miljöklassad?: ",-20}{fordon.MiljöKlassad,-20}\n" +
                              $"{"Tullpris: ",-20}{tullPris,-20}\n");
        }

        public static void Main(string[] args)
        {

            var fordon = new Fordon
            {
                FordonsTyp = GetFordonsTyp(),
                Vikt =GetVikt(),
                TidVidTullen = GetTid(),
                MiljöKlassad = GetMiljöKlass()
            };

            double tullPris = TullPris(fordon);
            DisplaySummary(fordon, tullPris);

        }
    }
}
