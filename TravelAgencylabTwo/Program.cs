using TravelAgencylabTwo;

internal class Program
{
    private static void Main(string[] args)
    {
        GetFromDB.initializeDb();
        Menu();

    }
    public static void Menu()
    {
        int choice = -1;
        /* List <Tour> tours = new List<Tour>();
         List <Tourist> tourists = new List<Tourist>();
         List<Tour_Operator> tour_Operators = new List<Tour_Operator>();
         List<Agreement> agreements = new List<Agreement>();*/

        List<Tour> tours = GetFromDB.GetTourFromDB();
        List<Tourist> tourists = GetFromDB.GetTouristFromDB();
        List<Tour_Operator> tour_Operators = GetFromDB.GetTourOperatorFromDB();
        List<Agreement> agreements = GetFromDB.GetAgreementFromDB(tours,tourists,tour_Operators);

        Console.WriteLine("Please Selection Action ");
        while (choice != 0)
        {
            Console.WriteLine("1 : Add Tourist ");
            Console.WriteLine("2 : Show Tourists ");
            Console.WriteLine("3 : Add Tour ");
            Console.WriteLine("4 : Show Tours ");
            Console.WriteLine("5 : Add Tour_Operator");
            Console.WriteLine("6 : Show Tour_Operator ");
            Console.WriteLine("7 : Add Agreement ");
            Console.WriteLine("8 : Show Agreements ");
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
                        foreach (Tourist t in tourists)
                            PrintValues.PrintTourist(t);
                        
                    }
                    break;
                case 3:
                    {
                        Tour tour = GetFromUser.EnterTour();
                        GetFromDB.EnterTour(tour);
                        tours = GetFromDB.GetTourFromDB();
                        //tours.Add(tour);
                    }
                    break;
                case 4:
                    {
                        foreach(Tour t in tours)
                            PrintValues.PrintTour(t);
                    }
                    break;
                case 5:
                    {
                        Tour_Operator tour_Operator = GetFromUser.EnterTourOperator();
                        GetFromDB.EnterTourOP(tour_Operator);
                        tour_Operators = GetFromDB.GetTourOperatorFromDB();
                       // tour_Operators.Add(tour_Operator);
                    }
                    break;
                case 6:
                    {
                        foreach (Tour_Operator tr in tour_Operators)
                            PrintValues.PrintTourOperator(tr);
                    }
                    break;
                case 7:
                    {
                        if(tours.Count>0 && tourists.Count>0 && tour_Operators.Count>0)
                        {
                            Agreement agreement = GetFromUser.EnterAgreement(tours, tourists, tour_Operators);

                            GetFromDB.EnterAgreement(agreement);
                            agreements = GetFromDB.GetAgreementFromDB(tours,tourists,tour_Operators);
                            //agreements.Add(agreement);
                        }
                    }
                    break;
                case 8:
                    {
                        foreach (Agreement ag in agreements)
                            PrintValues.PrintAgreement(ag);
                    }
                    break;

                case 0: break;
                default: break;
            }

        }
    }
}