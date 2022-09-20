using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencylabTwo.Open_closed;

namespace TravelAgencylabTwo.Menus
{
    internal class MenuTwo
    {
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
                        

                        }
                        break;
                    case 2:
                        {
                         
                            foreach (Tourist t in tourists)
                                PrintValues.PrintTourist(t, false);

                          
                        }
                        break;
                    case 3:
                        {
                           
                            foreach (Tourist t in tourists)
                                PrintValues.PrintTourist(t, true);

                        }
                        break;
                    case 4:
                        {
                            Tour tour = GetFromUser.EnterTour();
                            GetFromDB.EnterTour(tour);
                            tours = GetFromDB.GetTourFromDB();
                          
                        }
                        break;
                    case 5:
                        {
                           
                            foreach (Tour t in tours)
                                PrintValues.PrintTour(t, false);

                        

                        }
                        break;
                    case 6:
                        {
                          
                            foreach (Tour t in tours)
                                PrintValues.PrintTour(t, true);
                       
                        }
                        break;
                    case 7:
                        {
                            Tour_Operator tour_Operator = GetFromUser.EnterTourOperator();
                            GetFromDB.EnterTourOP(tour_Operator);
                            tour_Operators = GetFromDB.GetTourOperatorFromDB();
                         
                        }
                        break;
                    case 8:
                        {
                        
                            foreach (Tour_Operator tr in tour_Operators)
                                PrintValues.PrintTourOperator(tr, false);
                        

                        }
                        break;
                    case 9:
                        {
                       
                            foreach (Tour_Operator tr in tour_Operators)
                                PrintValues.PrintTourOperator(tr, true);

                        
                            
                        }
                        break;
                    case 10:
                        {
                            if (tours.Count > 0 && tourists.Count > 0 && tour_Operators.Count > 0)
                            {
                                Agreement agreement = GetFromUser.EnterAgreement(tours, tourists, tour_Operators);

                                GetFromDB.EnterAgreement(agreement);
                                agreements = GetFromDB.GetAgreementFromDB(tours, tourists, tour_Operators);
                          
                            }
                        }
                        break;
                    case 11:
                        {
                           
                            foreach (Agreement ag in agreements)
                                PrintValues.PrintAgreement(ag, false);

                    

                        }
                        break;
                    case 12:
                        {
                            foreach (Agreement ag in agreements)
                                PrintValues.PrintAgreement(ag, true);
                        }
                        break;

                    case 0: break;
                    default: break;
                }

            }
        }
    }
}
