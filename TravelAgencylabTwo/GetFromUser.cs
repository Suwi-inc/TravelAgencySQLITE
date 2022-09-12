using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace TravelAgencylabTwo
{
    internal class GetFromUser
    {
        public static Tourist EnterTourist()
        {

            Console.WriteLine("Enter Tourists First Name :");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Tourists Middle Name :");
            string midname = Console.ReadLine();
            Console.WriteLine("Enter Tourists Last Name :");
            string lastname = Console.ReadLine();
            Console.WriteLine("Enter Tourists Passport Number :");
            string passport = Console.ReadLine();
            Console.WriteLine("Enter Tourists Date Of Birth:");
            DateOnly dob = DateOnly.Parse(Console.ReadLine());

            Tourist tourist = new Tourist(lastname,name,midname,passport,dob);
            return tourist;
        }

        public static Tour_Operator EnterTourOperator()
        {
            Console.WriteLine("Enter Tour Operators First Name :");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Tour Operators Middle Name :");
            string midname = Console.ReadLine();
            Console.WriteLine("Enter Tour Operators Last Name :");
            string lastname = Console.ReadLine();
            Console.WriteLine("Enter Tour Operators Passport Number :");
            string passport = Console.ReadLine();
         

            Tour_Operator tour_Operator = new Tour_Operator(lastname, name, midname, passport);
            return tour_Operator;

        }

        public static Tour EnterTour()
        {
            Console.WriteLine("Enter Tour Name :");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Tour Start Date :");
            DateOnly tourStart = DateOnly.Parse(Console.ReadLine());
            Console.WriteLine("Enter Tour End Date :");
            DateOnly tourEnd = DateOnly.Parse(Console.ReadLine());
            Console.WriteLine("Enter Tour City :");
            string city = Console.ReadLine();

            Tour tour = new Tour(name,tourStart,tourEnd,city);
            return tour;

        }

        public static Agreement EnterAgreement(List<Tour> tours,List<Tourist> tourists,List<Tour_Operator> tour_Operators)
        {
            Console.WriteLine("Enter Agreement Date");
            DateOnly agreementdate = DateOnly.Parse(Console.ReadLine());
            Console.WriteLine("Enter Tour Name :");
            string name = Console.ReadLine();
            var _tour = tours.FirstOrDefault(s => s.name == name);

            Console.WriteLine("Enter Tourists Passport Number :");
            string touristpass = Console.ReadLine();
            var _tourist = tourists.FirstOrDefault(s => s.passportNumber == touristpass);

            Console.WriteLine("Enter Tour operators Passport Number :");
            string touroppass = Console.ReadLine();
            var _tour_operator = tour_Operators.FirstOrDefault(s => s.passportNumber == touroppass);


            Console.WriteLine("Enter Tour Price");
            double tourprice = double.Parse(Console.ReadLine());


            //fix me, add check for null values
            Agreement agreement = new Agreement(agreementdate,tourprice,_tourist,_tour_operator,_tour);
            return agreement;
        }
    }
}
