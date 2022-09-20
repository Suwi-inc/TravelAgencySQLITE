using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencylabTwo.Open_closed
{
    internal  interface IPrinter
    {
        public void PrintTourist(Tourist tourist);

        public  void PrintTourOperator(Tour_Operator tour_Operator);

        public  void PrintTour(Tour tour);

        public  void PrintAgreement(Agreement agreement);

  
    }
}
