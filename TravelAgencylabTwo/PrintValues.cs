using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencylabTwo
{
    internal class PrintValues
    {
        public static void PrintTourist(Tourist tourist, bool file)
            {
            if(!file)
            {
                Console.WriteLine(tourist.ToString());

            }
            if (file)
            {
                using var sw = new StreamWriter("tourist.txt");
                sw.WriteLine(tourist.ToString());
            }

        }
        public static void PrintTourOperator(Tour_Operator tour_Operator, bool file)
        {
            if (!file)
            {
                Console.WriteLine(tour_Operator.ToString());

            }
            if (file)
            {
                using var sw = new StreamWriter("tour_Operator.txt");
                sw.WriteLine(tour_Operator.ToString());
            }
        }
        public static void PrintTour(Tour tour, bool file)
        {
            if (!file)
            {
                Console.WriteLine(tour.ToString());

            }
            if (file)
            {
                using var sw = new StreamWriter("tour.txt");
                sw.WriteLine(tour.ToString());
            }
        }
        public static void PrintAgreement(Agreement agreement, bool file)
        {
            if (!file)
            {
                Console.WriteLine(agreement.ToString());

            }
            if(file)
            {
                using var sw = new StreamWriter("agreement.txt");
                sw.WriteLine(agreement.ToString());
            }

        }
        public static void writespace()
        {
            Console.WriteLine("-------------------------------------------------------------------------------------");
        }

    }
    
}
