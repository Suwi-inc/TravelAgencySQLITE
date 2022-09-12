using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Reflection;


namespace TravelAgencylabTwo
{
    internal class GetFromDB
    {
        public static string connectString = @"Data Source=mytables.sqlite;version = 3;";
        static SQLiteConnection? _habitConnection;




        public static void initializeDb()
        {
            
             _habitConnection = new SQLiteConnection(connectString);
            CreateTable(_habitConnection);
            

        }

        /// <summary>
        /// method to add given tourist to the database
        /// </summary>
        /// <param name="tourist"></param>
        public static void EnterTourist(Tourist tourist)
        {
            string countstring = "select * from Tourist";
            SQLiteCommand selectCommand = new SQLiteCommand(countstring, _habitConnection);
            int count = 0;
            SQLiteDataReader values = selectCommand.ExecuteReader();
            while (values.Read())
            {
                count ++;
            }
            string insertCommandString = $"Insert into Tourist (touristid ,lastname,firstname ,patronymic ,passportnumber,birthdate) values('{++count}','{tourist.lastName}','{tourist.firstName}','{tourist.patronymic}','{tourist.passportNumber}','{tourist.birthDate}')";

            SQLiteCommand insertCommand = new SQLiteCommand(insertCommandString, _habitConnection);
            insertCommand.ExecuteNonQuery();


        }

        /// <summary>
        /// returns a collection of tourists from the database
        /// </summary>
        /// <returns></returns>
        public static List<Tourist> GetTouristFromDB()
        {
            List<Tourist> list = new List<Tourist>();

            string selectCommandString = "Select * from Tourist";

            SQLiteCommand selectCommand = new SQLiteCommand(selectCommandString, _habitConnection);

            SQLiteDataReader values = selectCommand.ExecuteReader();
            while (values.Read())
            {
               

                Tourist tourist = new Tourist(values["lastname"].ToString(), values["firstname"].ToString(),values["patronymic"].ToString(),values["passportnumber"].ToString(), DateOnly.Parse((string)values["birthdate"]));
                list.Add(tourist);
            }


            return list;
        }
     



        /// <summary>
        /// method to add given tour operator data to the database
        /// </summary>
        /// <param name="tour_Operator"></param>
        public static void EnterTourOP(Tour_Operator tour_Operator)
        {
            string countstring = "select * from Tour_Operator";
            SQLiteCommand selectCommand = new SQLiteCommand(countstring, _habitConnection);
            int count = 0;
            SQLiteDataReader values = selectCommand.ExecuteReader();
            while (values.Read())
            {
                count ++;
            }
            string insertCommandString = $"Insert into Tour_Operator (tourOPid ,lastname,firstname ,patronymic ,passportnumber ) values('{++count}','{tour_Operator.lastName}','{tour_Operator.firstName}','{tour_Operator.patronymic}','{tour_Operator.passportNumber}')";

            SQLiteCommand insertCommand = new SQLiteCommand(insertCommandString, _habitConnection);
            insertCommand.ExecuteNonQuery();

        }

        /// <summary>
        /// returns a collection of tour operators from the database
        /// </summary>
        /// <returns></returns>
        public static List<Tour_Operator> GetTourOperatorFromDB()
        {
            List<Tour_Operator> list = new List<Tour_Operator>();

            string selectCommandString = "Select * from Tour_Operator";

            SQLiteCommand selectCommand = new SQLiteCommand(selectCommandString, _habitConnection);

            SQLiteDataReader values = selectCommand.ExecuteReader();
            while (values.Read())
            {
                Tour_Operator tourOp = new Tour_Operator(values["lastname"].ToString(), values["firstname"].ToString(), values["patronymic"].ToString(), values["passportnumber"].ToString());
                list.Add(tourOp);
            }


            return list;
        }
        /// <summary>
        /// Method to add given tour to the database
        /// </summary>
        public static void EnterTour(Tour tour)
        {
            string countstring = "select * from Tour";
            SQLiteCommand selectCommand = new SQLiteCommand(countstring, _habitConnection);
            int count = 0;
            SQLiteDataReader values = selectCommand.ExecuteReader();
            while (values.Read())
            {
                count ++;
            }
            string insertCommandString = $"Insert into Tour (tourid ,tourstart ,tourend ,city,name) values('{++count}','{tour.tourStart}','{tour.tourEnd}','{tour.city}','{tour.name}')";

            SQLiteCommand insertCommand = new SQLiteCommand(insertCommandString, _habitConnection);
            insertCommand.ExecuteNonQuery();

        }
        /// <summary>
        /// returns a collection of tours from the database
        /// </summary>
        /// <returns></returns>
        public static List<Tour> GetTourFromDB()
        {
            List<Tour> list = new List<Tour>();

            string selectCommandString = "Select * from Tour";

            SQLiteCommand selectCommand = new SQLiteCommand(selectCommandString, _habitConnection);

            SQLiteDataReader values = selectCommand.ExecuteReader();
            while (values.Read())
            {
                Tour tour = new Tour(values["name"].ToString(), DateOnly.Parse((string)values["tourstart"]), DateOnly.Parse((string)values["tourend"]), values["city"].ToString());
                list.Add(tour);
            }


            return list;
        }

        /// <summary>
        /// Method to add given agreement to the database
        /// agreement contains data about the tour, tour op and the tourist as well
        /// i use their primary key ids to reference them in the agreement table
        /// </summary>
        /// <param name="_habitConnection"></param>
        public static void EnterAgreement(Agreement agreement)
        {
            int touristid = 0, touropid = 0, tourid =  0, count = 0;

            //tourist search in db
            string selectstring = "select * from Tourist";
            SQLiteCommand selectCommand = new SQLiteCommand(selectstring, _habitConnection);
            SQLiteDataReader values = selectCommand.ExecuteReader();
            while (values.Read())
            {

                if ((string)values["passportnumber"] == agreement.GetTourist().passportNumber)
                {
                    touristid = (int)values["touristid"];
                    return;
                }

            }

            //tour Operator
             selectstring = "select * from Tour_Operator";
             selectCommand = new SQLiteCommand(selectstring, _habitConnection);
             values = selectCommand.ExecuteReader();
            while (values.Read())
            {
                if ((string)values["passportnumber"] == agreement.GetTour_Operator().passportNumber)
                {
                    touropid = (int)values["tourOPid"];
                    return;
                }
            }

            // tour search in db
             selectstring = "select * from Tour";
             selectCommand = new SQLiteCommand(selectstring, _habitConnection);
             values = selectCommand.ExecuteReader();
            while (values.Read())
            {
                if ((string)values["name"] == agreement.GetTour().name)
                {
                    tourid = (int)values["tourid"];
                    return ;
                }
            }


            //getting the current agreement index
            selectstring = "select * from Agreement";
             selectCommand = new SQLiteCommand(selectstring, _habitConnection);
             values = selectCommand.ExecuteReader();
            while (values.Read())
            {
                count ++;
            }

            string insertCommandString = $"Insert into Agreement (agreementid ,agreementdate ,tourprice ,touristid ,tourOP ,tourid ) values('{++count}','{agreement.agreementDate}','{agreement.tourPrice}','{touristid}','{touropid}','{tourid}')";

            SQLiteCommand insertCommand = new SQLiteCommand(insertCommandString, _habitConnection);
            insertCommand.ExecuteNonQuery();

        }
        /// <summary>
        /// returns a collection of agreements from the database
        /// </summary>
        /// <param name="_habitConnection"></param>
        /// 
        public static List<Agreement> GetAgreementFromDB(List<Tour> tours, List<Tourist> tourists, List<Tour_Operator> tour_Operators)
        {
            List<Agreement> list = new List<Agreement>();

            string selectCommandString = "Select * from Agreement";

            SQLiteCommand selectCommand = new SQLiteCommand(selectCommandString, _habitConnection);

            SQLiteDataReader values = selectCommand.ExecuteReader();
            while (values.Read())
            {
                //i search for the values of the tour,tourop and tourists from the db and match them with their index in the collections passes to get the objects which i add to the agreement object
                //index is inc by 1 because my db primary key values start at 1 while the collections index from 0
                DateOnly aggdate = DateOnly.Parse((string)values["agreementdate"]);
                Double tprice = (Double)values["tourprice"];
               
                
                Tourist tourist = tourists.ElementAt((int)values["touristid"] -1);
                Tour_Operator tour_Operator = tour_Operators.ElementAt((int)values["tourOP"] -1);
                Tour tour = tours.ElementAt((int)values["tourid"] -1);
                Agreement agreement = new Agreement(aggdate, tprice, tourist, tour_Operator, tour);
                list.Add(agreement);
            }


            return list;
        }

        public static void CreateTable(SQLiteConnection _habitConnection)
        {
            _habitConnection.Open();

            string createTourist = "Create table if not exists Tourist (touristid INT,lastname varchar(50),firstname varchar(50),patronymic varchar(50),passportnumber varchar(100),birthdate text)";

            SQLiteCommand createCommand = new SQLiteCommand(createTourist, _habitConnection);

            createCommand.ExecuteNonQuery();

            string createTourOP = "Create table if not exists Tour_Operator (tourOPid INT,lastname varchar(50),firstname varchar(50),patronymic varchar(50),passportnumber varchar(100))";

            createCommand = new SQLiteCommand(createTourOP, _habitConnection);

            createCommand.ExecuteNonQuery();

            string createTour = "Create table if not exists Tour (tourid INT,tourstart text,tourend text,city varchar(50),name varchar(100))"; //added var name

            createCommand = new SQLiteCommand(createTour, _habitConnection);

            createCommand.ExecuteNonQuery();

            string createAgreement = "Create table if not exists Agreement (agreementid INT,agreementdate text,tourprice REAL,touristid INT,tourOP INT,tourid INT)";

            createCommand = new SQLiteCommand(createAgreement, _habitConnection);

            createCommand.ExecuteNonQuery();


        }

        //test method no longer in ise
        public static void testdb(SQLiteConnection _habitConnection)
        {
            string insertCommandString = $"Insert into Tour (tourid,tourstart,tourend,city) values('1','2016-01-01','2016-03-01','kampala')";

            SQLiteCommand insertCommand = new SQLiteCommand(insertCommandString, _habitConnection);
            insertCommand.ExecuteNonQuery();


            Console.WriteLine("script executed");



            string selectCommandString = "Select * from Tour";

            SQLiteCommand selectCommand = new SQLiteCommand(selectCommandString, _habitConnection);

            SQLiteDataReader values = selectCommand.ExecuteReader();
            while (values.Read())
                Console.WriteLine( "tourid: " + values["tourid"] + "\ttourstart: " + values["tourstart"] + "\ttourend: " + values["tourend"] + "\tcity: " + values["city"]);

            string countstring = "select count(*) from Tour";
            selectCommand = new SQLiteCommand(countstring, _habitConnection);
            int count = 0;
            values = selectCommand.ExecuteReader();
            while (values.Read())
            {
                count++;
                Console.WriteLine(values[0]);
            }
            Console.WriteLine(count);
        }

    }
}
