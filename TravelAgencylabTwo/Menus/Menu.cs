using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencylabTwo.Open_closed;

namespace TravelAgencylabTwo.Menus
{
    internal class Menu
    {
        /// <summary>
        /// this class should reflect a good implementation of the open closed principle 
        /// </summary>
        public static void menu()
        {
            int choice = -1;


            List<Tour> tours = GetFromDB.GetTourFromDB();
            List<Tourist> tourists = GetFromDB.GetTouristFromDB();
            List<Tour_Operator> tour_Operators = GetFromDB.GetTourOperatorFromDB();
            List<Agreement> agreements = GetFromDB.GetAgreementFromDB(tours, tourists, tour_Operators);

            Console.WriteLine("Please Selection Action ");
            while (choice != 0)
            {
                Console.WriteLine("1 : Add Tourist ");
                Console.WriteLine("2 : Show Tourists on console  ");
                Console.WriteLine("3 : Add Tourists To File ");
                Console.WriteLine("4 : Add Tour ");
                Console.WriteLine("5 : Show Tours on console  ");
                Console.WriteLine("6 : Add Tours To File ");
                Console.WriteLine("7 : Add Tour_Operator");
                Console.WriteLine("8 : Show Tour_Operator on console  ");
                Console.WriteLine("9 : Add Tour_Operator To File ");
                Console.WriteLine("10 : Add Agreement ");
                Console.WriteLine("11 : Show Agreements on console ");
                Console.WriteLine("12 : Add Agreements To File ");
                Console.WriteLine("0 : Exit");

                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        {
                            Tourist tourist = GetFromUser.EnterTourist();
                            GetFromDB.EnterTourist(tourist);
                            tourists = GetFromDB.GetTouristFromDB();
                            // tourists.Add(tourist);

                        }
                        break;
                    case 2:
                        {

                            //ok
                            PrintToConsole p = new PrintToConsole();
                            foreach (Tourist t in tourists)
                                p.PrintTourist(t);


                        }
                        break;
                    case 3:
                        {


                            PrintToFile pf = new PrintToFile("tourist.txt");
                            foreach (Tourist t in tourists)
                                pf.PrintTourist(t);

                        }
                        break;
                    case 4:
                        {
                            Tour tour = GetFromUser.EnterTour();
                            GetFromDB.EnterTour(tour);
                            tours = GetFromDB.GetTourFromDB();
                            //tours.Add(tour);
                        }
                        break;
                    case 5:
                        {

                            PrintToConsole p = new PrintToConsole();
                            foreach (Tour t in tours)
                                p.PrintTour(t);



                        }
                        break;
                    case 6:
                        {
                            PrintToFile pt = new PrintToFile("tour.txt");
                            foreach (Tour t in tours)
                                pt.PrintTour(t);

                        }
                        break;
                    case 7:
                        {
                            Tour_Operator tour_Operator = GetFromUser.EnterTourOperator();
                            GetFromDB.EnterTourOP(tour_Operator);
                            tour_Operators = GetFromDB.GetTourOperatorFromDB();
                            // tour_Operators.Add(tour_Operator);
                        }
                        break;
                    case 8:
                        {

                            PrintToConsole p = new PrintToConsole();
                            foreach (Tour_Operator tr in tour_Operators)
                                p.PrintTourOperator(tr);


                        }
                        break;
                    case 9:
                        {

                            PrintToFile p = new PrintToFile("tour_Operators.txt");
                            foreach (Tour_Operator tr in tour_Operators)
                            {

                                p.PrintTourOperator(tr);
                            }
                        }
                        break;
                    case 10:
                        {
                            if (tours.Count > 0 && tourists.Count > 0 && tour_Operators.Count > 0)
                            {
                                Agreement agreement = GetFromUser.EnterAgreement(tours, tourists, tour_Operators);

                                GetFromDB.EnterAgreement(agreement);
                                agreements = GetFromDB.GetAgreementFromDB(tours, tourists, tour_Operators);
                                //agreements.Add(agreement);
                            }
                        }
                        break;
                    case 11:
                        {

                            PrintToConsole p = new PrintToConsole();
                            foreach (Agreement ag in agreements)
                                p.PrintAgreement(ag);



                        }
                        break;
                    case 12:
                        {
                            PrintToFile pf = new PrintToFile("agreement.txt");
                            foreach (Agreement ag in agreements)
                                pf.PrintAgreement(ag);
                        }
                        break;

                    case 0: break;
                    default: break;
                }

            }
        }

    }
}
