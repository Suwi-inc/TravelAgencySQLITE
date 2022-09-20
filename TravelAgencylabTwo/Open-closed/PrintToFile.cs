using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencylabTwo.Open_closed
{
    /// <summary>
    /// class that outputs class contents to file
    /// </summary>
    internal class PrintToFile : IPrinter
    {
        string path;
        public PrintToFile(string path)
        {
            this.path = path;
        }

        public void PrintAgreement(Agreement agreement)
        {
            using var sw = new StreamWriter(path);
            sw.WriteLine(agreement.ToString());
        }

        public void PrintTour(Tour tour)
        {
            using var sw = new StreamWriter(path);
            sw.WriteLine(tour.ToString());
        }

        public void PrintTourist(Tourist tourist)
        {
            using var sw = new StreamWriter(path,true);
            sw.WriteLine(tourist.ToString());
        }

        public void PrintTourOperator(Tour_Operator tour_Operator)
        {
            using var sw = new StreamWriter(path);
            sw.WriteLine(tour_Operator.ToString());
        }
    }
}
