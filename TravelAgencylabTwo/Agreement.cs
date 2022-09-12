using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencylabTwo
{
    internal class Agreement
    {
        public DateOnly agreementDate { get; set; }
        public double tourPrice { get; set; }
        Tourist tourist;
        Tour_Operator tour_operator;
        Tour tour;

        public Agreement(DateOnly agreementDate, double tourPrice, Tourist tourist, Tour_Operator tour_operator, Tour tour)
        {
            this.agreementDate = agreementDate;
            this.tourPrice = tourPrice;
            this.tourist = tourist;
            this.tour_operator = tour_operator;
            this.tour = tour;
        }
        public Tourist GetTourist()
        {
            return tourist;
        }
        public Tour_Operator GetTour_Operator()
        {
            return tour_operator;
        }
        public Tour GetTour()
        {
            return tour;
        }

        
    }
}
