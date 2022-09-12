using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencylabTwo
{
    internal class PrintValues
    {
        public static void PrintTourist(Tourist tourist)
            {
            writespace();
            Console.WriteLine("First Name :"+tourist.firstName
                +"\n"+"Middle Name :"+tourist.patronymic
                +"\n"+"Last Name :" +tourist.lastName 
                +"\n"+"PassPort Number :"+tourist.passportNumber
                +"\n"+"Date of birth :"+tourist.birthDate+"\n");
            writespace();
        }
        public static void PrintTourOperator(Tour_Operator tour_Operator)
        {
            writespace();
            Console.WriteLine("First Name :" + tour_Operator.firstName
                + "\n" + "Middle Name :" + tour_Operator.patronymic
                + "\n" + "Last Name :" + tour_Operator.lastName
                + "\n" + "PassPort Number :" + tour_Operator.passportNumber
                + "\n" );
            writespace();
        }
        public static void PrintTour(Tour tour)
        {
            writespace();
            Console.WriteLine("Tour Name :" + tour.name
               + "\n" + "Tour Start :" + tour.tourStart
               + "\n" + "Tour End :" + tour.tourEnd
               + "\n" + "Tour City :" + tour.city
               + "\n");
            writespace();

        }
        public static void PrintAgreement(Agreement agreement)
        {
            writespace();
            Console.WriteLine("Agreement Date :" + agreement.agreementDate
               + "\n" + "Tour price :" + agreement.tourPrice
               + "\n" + "Tour Name :" + agreement.GetTour().name
               + "\n" + "Tourist :" + agreement.GetTourist().firstName +" "+ agreement.GetTourist().patronymic+" "+ agreement.GetTourist().lastName
               + "\n"+ "Tour Operator :"+ agreement.GetTour_Operator().firstName + " " + agreement.GetTour_Operator().patronymic + " " + agreement.GetTour_Operator().lastName
               +"\n");
            writespace();

        }
        public static void writespace()
        {
            Console.WriteLine("-------------------------------------------------------------------------------------");
        }

    }
    
}
