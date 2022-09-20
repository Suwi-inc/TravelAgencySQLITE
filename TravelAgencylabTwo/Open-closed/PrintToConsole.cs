using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TravelAgencylabTwo.Open_closed
{
    /// <summary>
    /// class that outputs class contents to console
    /// </summary>
    internal class PrintToConsole : IPrinter
    {
        public  void PrintTourist(Tourist tourist)
        {
            Console.WriteLine(tourist.ToString());
        }
        public  void PrintTourOperator(Tour_Operator tour_Operator)
        {
            Console.WriteLine(tour_Operator.ToString());
        }
        public  void PrintTour(Tour tour)
        {
            Console.WriteLine(tour.ToString());

        }
        public  void PrintAgreement(Agreement agreement)
        {
            Console.WriteLine(agreement.ToString());

        }
       

    }
}
