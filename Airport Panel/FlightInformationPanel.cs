using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport_Panel
{
    class FlightInformationPanel
    {
        public List<FlightInformation> Flights = new List<FlightInformation>();
        
        public void AddFlight()
        {
            Console.WriteLine("===Add Flight===");
            FlightInformation addFlight = new FlightInformation();
            addFlight.Flight = Flights.Count + 1;
            Console.Write(" Введите номер рейса: ");
            addFlight.FlightNumber = Console.ReadLine();
            Console.WriteLine();
            Console.Write(" Введите дату прибытия в формате гггг-мм-дд чч:мм.");
            addFlight.DateArrivals = DateTime.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.Write(" Введите город прибытия: ");
            addFlight.CityArrivals = Console.ReadLine();
            Console.WriteLine();
            Console.Write(" Введите дату отправления в формате гггг-мм-дд чч:мм.");
            addFlight.DateDepartures = DateTime.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.Write(" Введите город отправления: ");
            addFlight.CityDepartures = Console.ReadLine();
            Console.WriteLine();
            Console.Write(" Выберите авиакомпанию: ");
            Console.WriteLine(" 1. British_Airways.");
            Console.WriteLine("\t\t\t 2. Air_France.");
            Console.WriteLine("\t\t\t 3. American_Airlines.");
            Console.WriteLine("\t\t\t 4. Cathay_Pacific.");
            Console.WriteLine("\t\t\t 5. Lufthansa.");
            Console.WriteLine("\t\t\t 6. Emirates.");
            switch (Console.ReadLine())
            {
                case "1":
                    addFlight.Airline = Airlines.British_Airways;
                    break;
                case "2":
                    addFlight.Airline = Airlines.Air_France;
                    break;
                case "3":
                    addFlight.Airline = Airlines.American_Airlines;
                    break;
                case "4":
                    addFlight.Airline = Airlines.Cathay_Pacific;
                    break;
                case "5":
                    addFlight.Airline = Airlines.Lufthansa;
                    break;
                case "6":
                    addFlight.Airline = Airlines.Emirates;
                    break;
                default:
                    Console.WriteLine(" Неизвестная авиокомпания, выберите авиокомпанию из списка.");
                    break;
            }

            Console.Write(" Введите терминал: ");
            Console.WriteLine(" 1. A.");
            Console.WriteLine("\t\t    2. B.");
            Console.WriteLine("\t\t    3. C.");
            Console.WriteLine("\t\t    4. D.");
            Console.WriteLine("\t\t    5. E.");
            Console.WriteLine("\t\t    6. F.");

            switch (Console.ReadLine())
            {
                case "1":
                    addFlight.Terminal = Terminal.A;
                    break;
                case "2":
                    addFlight.Terminal = Terminal.B;
                    break;
                case "3":
                    addFlight.Terminal = Terminal.C;
                    break;
                case "4":
                    addFlight.Terminal = Terminal.D;
                    break;
                case "5":
                    addFlight.Terminal = Terminal.E;
                    break;
                case "6":
                    addFlight.Terminal = Terminal.F;
                    break;
                default:
                    Console.WriteLine(" Неизвестный терминал, выберите терминал из списка.");
                    break;
            }


            Console.Write(" Введите gate: ");
            Console.WriteLine(" 1. A1.");
            Console.WriteLine("\t\t2. A2.");
            Console.WriteLine("\t\t3. A3.");
            Console.WriteLine("\t\t4. A4.");
            Console.WriteLine("\t\t5. A5.");
            Console.WriteLine("\t\t6. A6.");


            switch (Console.ReadLine())
            {
                case "1":
                    addFlight.Gate = Gate.A1;
                    break;
                case "2":
                    addFlight.Gate = Gate.A2;
                    break;
                case "3":
                    addFlight.Gate = Gate.A3;
                    break;
                case "4":
                    addFlight.Gate = Gate.A4;
                    break;
                case "5":
                    addFlight.Gate = Gate.A5;
                    break;
                case "6":
                    addFlight.Gate = Gate.A6;
                    break;
                default:
                    Console.WriteLine(" Неизвестный gate, выберите gate из списка.");
                    break;
            }


            Console.Write(" Введите статус рейса: ");
            Console.WriteLine(" 1. Check_in.");
            Console.WriteLine("\t\t\t2. Gate_closed.");
            Console.WriteLine("\t\t\t3. Arrived.");
            Console.WriteLine("\t\t\t4. Departed_at.");
            Console.WriteLine("\t\t\t5. Unknown.");
            Console.WriteLine("\t\t\t6. Canceled.");
            Console.WriteLine("\t\t\t7. Expected_at.");
            Console.WriteLine("\t\t\t8. Delayed.");
            Console.WriteLine("\t\t\t9. In_flight.");

            switch (Console.ReadLine())
            {
                case "1":
                    addFlight.FlightStatus = FlightStatus.Check_in;
                    break;
                case "2":
                    addFlight.FlightStatus = FlightStatus.Gate_closed;
                    break;
                case "3":
                    addFlight.FlightStatus = FlightStatus.Arrived;
                    break;
                case "4":
                    addFlight.FlightStatus = FlightStatus.Departed_at;
                    break;
                case "5":
                    addFlight.FlightStatus = FlightStatus.Unknown;
                    break;
                case "6":
                    addFlight.FlightStatus = FlightStatus.Expected_at;
                    break;
                case "7":
                    addFlight.FlightStatus = FlightStatus.Delayed;
                    break;
                case "8":
                    addFlight.FlightStatus = FlightStatus.In_flight;
                    break;
                default:
                    Console.WriteLine(" Неизвестный статус рейса, выберите статус рейса из списка.");
                    break;
            }

            Console.WriteLine();
            addFlight.Info();
            Console.WriteLine(" Добавить данный рейс в список полётов? y/n");
            while (true)
            {
                switch (Console.ReadLine())
                {
                    case "y":

                        string connstring = @"Server=DESKTOP-DF21NNB\MSSQLSERVER03;Database=AirportDB1;Integrated Security=True";
                        using (SqlConnection dbconn = new SqlConnection(connstring))
                        {
                            dbconn.Open();
                            Console.WriteLine("Connection to AirportDB is open");

                            string query = "INSERT INTO FlightInfo (Flight_id, FlightNumber, DateArrivals, DateDepartures, " +
                                "CityArrivals, CityDepartures) " +
                                "VALUES (@NEXT, @FlightNumber, @DateArrivals, @DateDepartures, @CityArrivals, @CityDepartures)";

                            using (SqlCommand command = new SqlCommand(query, dbconn))
                            {
                                command.Parameters.AddWithValue("@NEXT", addFlight.Flight);
                                command.Parameters.AddWithValue("@FlightNumber", addFlight.FlightNumber);
                                command.Parameters.AddWithValue("@DateArrivals", addFlight.DateArrivals);
                                command.Parameters.AddWithValue("@DateDepartures", addFlight.DateDepartures);
                                command.Parameters.AddWithValue("@CityArrivals", addFlight.CityArrivals);
                                command.Parameters.AddWithValue("@CityDepartures", addFlight.CityDepartures);

                                command.ExecuteNonQuery();
                            }
                            string query1 = "INSERT INTO AirlineInfo (Airline_id,Flight_id, Airline)" +
                                "VALUES (@Airline_id,@Flight_id, @Airline)";
                            using (SqlCommand command1 = new SqlCommand(query1, dbconn))
                            {
                                command1.Parameters.AddWithValue("@Airline_id", addFlight.Flight);
                                command1.Parameters.AddWithValue("@Flight_id", addFlight.Flight);
                                command1.Parameters.AddWithValue("@Airline", addFlight.Airline);
                                
                                command1.ExecuteNonQuery();
                            }
                            
                            string query2 = "INSERT INTO TerminalInfo (Terminal_id,Flight_id, Terminal)" +
                                "VALUES (@Terminal_id,@Flight_id, @Terminal)";
                            using (SqlCommand command2 = new SqlCommand(query2, dbconn))
                            {
                                command2.Parameters.AddWithValue("@Terminal_id", addFlight.Flight);
                                command2.Parameters.AddWithValue("@Flight_id", addFlight.Flight);
                                 command2.Parameters.AddWithValue("@Terminal", addFlight.Terminal);
                                 
                                 command2.ExecuteNonQuery();
                               
                            }
                             
                            string query3 = "INSERT INTO GateInfo (Gate_id,Flight_id, Gate)" +
                                "VALUES (@Gate_id,@Flight_id, @Gate)";
                            using(SqlCommand command3 = new SqlCommand(query3, dbconn))
                            {
                                command3.Parameters.AddWithValue("@Gate_id", addFlight.Flight);
                                command3.Parameters.AddWithValue("@Flight_id", addFlight.Flight);
                                command3.Parameters.AddWithValue("@Gate", addFlight.Gate);

                                command3.ExecuteNonQuery();
                            }
                            
                            string query4 = "INSERT INTO FlightStatusInfo (FlightStatus_id,Flight_id, FlightStatus)" +
                               "VALUES (@FlightStatus_id,@Flight_id, @FlightStatus)";
                            using (SqlCommand command4 = new SqlCommand(query4, dbconn))
                            {
                                command4.Parameters.AddWithValue("@FlightStatus_id", addFlight.Flight);
                                command4.Parameters.AddWithValue("@Flight_id", addFlight.Flight);
                                command4.Parameters.AddWithValue("@FlightStatus", addFlight.FlightStatus);

                                command4.ExecuteNonQuery();
                            }
                        }
                            
                                Flights.Add(addFlight);
                        Console.WriteLine(" Рейс добавлен!");
                        return;
                    case "n":
                        Console.WriteLine(" Добавление рейса отменено!");
                        return;
                    default:
                        Console.WriteLine(" Неизвестный символ, выберите y/n");
                        break;
                }
            }
        }

        public void EditFlight()
        {
            Console.WriteLine("===Edit Flight===");
            Console.Write(" Enter Flight Number: ");
            string flightNumber = Console.ReadLine();
            //Flights.RemoveAll(Predicate<FlightInformation>flightNumber);   ???
            FlightInformation flight = null;
            foreach (FlightInformation f in Flights)
            {
                if (f != null && f.FlightNumber == flightNumber)
                {
                    flight = f;
                    break;
                }
            }
            if (flight == null)
            {
                Console.WriteLine(" Flight not found!");
                return;
            }
            FlightInformation editFlight = new FlightInformation();
            Console.WriteLine();
            Console.Write(" Введите дату прибытия в формате гггг-мм-дд чч:мм.");
            editFlight.DateArrivals = DateTime.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.Write(" Введите город прибытия: ");
            editFlight.CityArrivals = Console.ReadLine();
            Console.WriteLine();
            Console.Write(" Введите дату отправления в формате гггг-мм-дд чч:мм.");
            editFlight.DateDepartures = DateTime.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.Write(" Введите город отправления: ");
            editFlight.CityDepartures = Console.ReadLine();
            Console.WriteLine();
            Console.Write(" Выберите авиакомпанию: ");
            Console.WriteLine(" 1. British_Airways.");
            Console.WriteLine("\t\t\t 2. Air_France.");
            Console.WriteLine("\t\t\t 3. American_Airlines.");
            Console.WriteLine("\t\t\t 4. Cathay_Pacific.");
            Console.WriteLine("\t\t\t 5. Lufthansa.");
            Console.WriteLine("\t\t\t 6. Emirates.");
            switch (Console.ReadLine())
            {
                case "1":
                    editFlight.Airline = Airlines.British_Airways;
                    break;
                case "2":
                    editFlight.Airline = Airlines.Air_France;
                    break;
                case "3":
                    editFlight.Airline = Airlines.American_Airlines;
                    break;
                case "4":
                    editFlight.Airline = Airlines.Cathay_Pacific;
                    break;
                case "5":
                    editFlight.Airline = Airlines.Lufthansa;
                    break;
                case "6":
                    editFlight.Airline = Airlines.Emirates;
                    break;
                default:
                    Console.WriteLine(" Неизвестная авиокомпания, выберите авиокомпанию из списка.");
                    break;
            }

            Console.Write(" Введите терминал: ");
            Console.WriteLine(" 1. A.");
            Console.WriteLine("\t\t    2. B.");
            Console.WriteLine("\t\t    3. C.");
            Console.WriteLine("\t\t    4. D.");
            Console.WriteLine("\t\t    5. E.");
            Console.WriteLine("\t\t    6. F.");

            switch (Console.ReadLine())
            {
                case "1":
                    editFlight.Terminal = Terminal.A;
                    break;
                case "2":
                    editFlight.Terminal = Terminal.B;
                    break;
                case "3":
                    editFlight.Terminal = Terminal.C;
                    break;
                case "4":
                    editFlight.Terminal = Terminal.D;
                    break;
                case "5":
                    editFlight.Terminal = Terminal.E;
                    break;
                case "6":
                    editFlight.Terminal = Terminal.F;
                    break;
                default:
                    Console.WriteLine(" Неизвестный терминал, выберите терминал из списка.");
                    break;
            }


            Console.Write(" Введите gate: ");
            Console.WriteLine(" 1. A1.");
            Console.WriteLine("\t\t2. A2.");
            Console.WriteLine("\t\t3. A3.");
            Console.WriteLine("\t\t4. A4.");
            Console.WriteLine("\t\t5. A5.");
            Console.WriteLine("\t\t6. A6.");


            switch (Console.ReadLine())
            {
                case "1":
                    editFlight.Gate = Gate.A1;
                    break;
                case "2":
                    editFlight.Gate = Gate.A2;
                    break;
                case "3":
                    editFlight.Gate = Gate.A3;
                    break;
                case "4":
                    editFlight.Gate = Gate.A4;
                    break;
                case "5":
                    editFlight.Gate = Gate.A5;
                    break;
                case "6":
                    editFlight.Gate = Gate.A6;
                    break;
                default:
                    Console.WriteLine(" Неизвестный gate, выберите gate из списка.");
                    break;
            }


            Console.Write(" Введите статус рейса: ");
            Console.WriteLine(" 1. Check_in.");
            Console.WriteLine("\t\t\t2. Gate_closed.");
            Console.WriteLine("\t\t\t3. Arrived.");
            Console.WriteLine("\t\t\t4. Departed_at.");
            Console.WriteLine("\t\t\t5. Unknown.");
            Console.WriteLine("\t\t\t6. Canceled.");
            Console.WriteLine("\t\t\t7. Expected_at.");
            Console.WriteLine("\t\t\t8. Delayed.");
            Console.WriteLine("\t\t\t9. In_flight.");

            switch (Console.ReadLine())
            {
                case "1":
                    editFlight.FlightStatus = FlightStatus.Check_in;
                    break;
                case "2":
                    editFlight.FlightStatus = FlightStatus.Gate_closed;
                    break;
                case "3":
                    editFlight.FlightStatus = FlightStatus.Arrived;
                    break;
                case "4":
                    editFlight.FlightStatus = FlightStatus.Departed_at;
                    break;
                case "5":
                    editFlight.FlightStatus = FlightStatus.Unknown;
                    break;
                case "6":
                    editFlight.FlightStatus = FlightStatus.Expected_at;
                    break;
                case "7":
                    editFlight.FlightStatus = FlightStatus.Delayed;
                    break;
                case "8":
                    editFlight.FlightStatus = FlightStatus.In_flight;
                    break;
                default:
                    Console.WriteLine(" Неизвестный статус рейса, выберите статус рейса из списка.");
                    break;
            }

            Console.WriteLine();
            editFlight.Info();
            Console.WriteLine(" Добавить изменённый рейс в список полётов? y/n");
            while (true)
            {
                switch (Console.ReadLine())
                {
                    case "y":
                        string connstring = @"Server=DESKTOP-DF21NNB\MSSQLSERVER03;Database=AirportDB1;Integrated Security=True";
                        using (SqlConnection dbconn = new SqlConnection(connstring))
                        {
                            dbconn.Open();
                            Console.WriteLine("Connection to AirportDB is open");

                            string query = "UPDATE FlightInfo " +
                                "SET Flight_id = @NEXT, FlightNumber =  @FlightNumber, DateArrivals =  @DateArrivals," +
                                " DateDepartures = @DateDepartures, CityArrivals = @CityArrivals, CityDepartures = @CityDepartures" +
                                "WHERE Flight_id = 1 ";
                               

                            using (SqlCommand command = new SqlCommand(query, dbconn))
                            {
                                command.Parameters.AddWithValue("@NEXT", editFlight.Flight); //?
                                command.Parameters.AddWithValue("@FlightNumber", editFlight.FlightNumber);
                                command.Parameters.AddWithValue("@DateArrivals", editFlight.DateArrivals);
                                command.Parameters.AddWithValue("@DateDepartures", editFlight.DateDepartures);
                                command.Parameters.AddWithValue("@CityArrivals", editFlight.CityArrivals);
                                command.Parameters.AddWithValue("@CityDepartures", editFlight.CityDepartures);

                                command.ExecuteNonQuery();
                            }
                            string query1 = "UPDATE AirlineInfo " +
                                "SET Airline_id = @Airline_id, Flight_id = @Flight_id, Airline = @Airline" +
                                "WHERE Flight_id = 1";
                            using (SqlCommand command1 = new SqlCommand(query1, dbconn))
                            {
                                command1.Parameters.AddWithValue("@Airline_id", editFlight.Flight);
                                command1.Parameters.AddWithValue("@Flight_id", editFlight.Flight);
                                command1.Parameters.AddWithValue("@Airline", editFlight.Airline);

                                command1.ExecuteNonQuery();
                            }

                            string query2 = "UPDATE TerminalInfo " +
                                "SET Terminal_id = @Terminal_id, Flight_id = @Flight_id, Terminal =  @Terminal " +
                                "WHERE FLight_id = 1";
                            using (SqlCommand command2 = new SqlCommand(query2, dbconn))
                            {
                                command2.Parameters.AddWithValue("@Terminal_id", editFlight.Flight);
                                command2.Parameters.AddWithValue("@Flight_id", editFlight.Flight);
                                command2.Parameters.AddWithValue("@Terminal", editFlight.Terminal);

                                command2.ExecuteNonQuery();

                            }

                            string query3 = "UPDATE GateInfo " +
                                "SET Gate_id = @Gate_id, Flight_id = @Flight_id, Gate = @Gate  " +
                                "WHERE FLight_id = 1";
                            using (SqlCommand command3 = new SqlCommand(query3, dbconn))
                            {
                                command3.Parameters.AddWithValue("@Gate_id", editFlight.Flight);
                                command3.Parameters.AddWithValue("@Flight_id", editFlight.Flight);
                                command3.Parameters.AddWithValue("@Gate", editFlight.Gate);

                                command3.ExecuteNonQuery();
                            }

                            string query4 = "UPDATE FlightStatusInfo " +
                                "SET FlightStatus_id = @FlightStatus_id, Flight_id = @Flight_id, FlightStatus = @FlightStatus" +
                               "WHERE FLight_id = 1";
                            using (SqlCommand command4 = new SqlCommand(query4, dbconn))
                            {
                                command4.Parameters.AddWithValue("@FlightStatus_id", editFlight.Flight);
                                command4.Parameters.AddWithValue("@Flight_id", editFlight.Flight);
                                command4.Parameters.AddWithValue("@FlightStatus", editFlight.FlightStatus);

                                command4.ExecuteNonQuery();
                            }
                        }
                        Flights.Add(editFlight);
                        Console.WriteLine(" Рейс добавлен!");
                        return;
                    case "n":
                        Console.WriteLine(" Добавление рейса отменено!");
                        return;
                    default:
                        Console.WriteLine(" Неизвестный символ, выберите y/n");
                        break;
                }
            }
        }

        public void DeleteFlight()
        {
            Console.WriteLine("===Delete Flight===");
            Console.Write(" Enter Flight Number: ");
            string flightNumber = Console.ReadLine();
            FlightInformation flight = Flights.FirstOrDefault(f => f.FlightNumber == flightNumber);
            if (flight == null)
            {
                Console.WriteLine(" Flight not found!");
                return;
            }
            Flights.Remove(flight);
            Console.WriteLine(" Flight deleted!");

        }

       
        public void DisplayArrivals()
        {
            Console.WriteLine("===Arrivals===");
            foreach (FlightInformation flight in Flights)
            {
                if (flight?.Gate != null)
                {
                    Console.WriteLine($" Flight Number: {flight.FlightNumber}\n" +
                                      $" City of arrival: {flight.CityArrivals}\n" +
                                      $" Arrival Time: {flight.DateArrivals}\n" +
                                      $" Arrival Gate: {flight.Gate}\n" +
                                      $" Airline: {flight.Airline}\n" +
                                      $" Terminal: {flight.Terminal}\n" +
                                      $" Flight Status: {flight.FlightStatus}\n");
                }
            }
        }
        public void DisplayDepartures()
        {
            Console.WriteLine("===Departures===");
            foreach (FlightInformation flight in Flights)
            {
                if (flight != null)
                {
                    Console.WriteLine($" Flight Number: {flight.FlightNumber}\n" +
                                      $" City of departure: {flight.CityDepartures}\n" +
                                      $" Departure Time: {flight.DateDepartures}\n" +
                                      $" Departure Gate: {flight.Gate}\n" +
                                      $" Airline: {flight.Airline}\n" +
                                      $" Terminal: {flight.Terminal}\n" +
                                      $" Flight Status: {flight.FlightStatus}\n");
                }
            }
        }
        
        public void SearchByFlightNumber()
        {
            Console.WriteLine("===Search By Flight Number===");
            Console.Write(" Enter Flight Number: ");
            string flightNumber = Console.ReadLine();
            FlightInformation flight = Flights.FirstOrDefault(f => f != null && f.FlightNumber == flightNumber);
            if (flight == null)
            {
                Console.WriteLine(" Flight not found!");
                return;
            }
            Console.WriteLine($" Flight Number: {flight.FlightNumber}\n" +
                              $" City of arrival: {flight.CityArrivals}\n" +
                              $" Arrival Time: {flight.DateArrivals}\n" +
                              $" Arrival Gate: {flight.Gate}\n" +
                              $" Airline: {flight.Airline}\n" +
                              $" Terminal: {flight.Terminal}\n" +
                              $" Flight Status: {flight.FlightStatus}\n");
        }

      

        public void SearchByArrivalTime()
        {
            Console.WriteLine("===Search By Arrival Time===");
            Console.Write(" Enter Arrival Time: ");
            DateTime dateArrivals = DateTime.Parse(Console.ReadLine());
            FlightInformation flight = Flights.FirstOrDefault(f => f != null && f.DateArrivals == dateArrivals);
            if (flight == null)
            {
                Console.WriteLine(" Flight not found!");
                return;
            }
            Console.WriteLine($" Flight Number: {flight.FlightNumber}\n" +
                              $" City of arrival: {flight.CityArrivals}\n" +
                              $" Arrival Time: {flight.DateArrivals}\n" +
                              $" Arrival Gate: {flight.Gate}\n" +
                              $" Airline: {flight.Airline}\n" +
                              $" Terminal: {flight.Terminal}\n" +
                              $" Flight Status: {flight.FlightStatus}\n");

        }

      
        public void SearchByArrivalPort()
        {
            Console.WriteLine("===Search By Arrival Port===");
            Console.Write(" Enter Arrival Port: ");
            string cityArrivals = Console.ReadLine();
            FlightInformation flight = Flights.FirstOrDefault(f => f != null && f.CityArrivals == cityArrivals);
            if (flight == null)
            {
                Console.WriteLine(" Flight not found!");
                return;
            }
            Console.WriteLine($" Flight Number: {flight.FlightNumber}\n" +
                              $" City of arrival: {flight.CityArrivals}\n" +
                              $" Arrival Time: {flight.DateArrivals}\n" +
                              $" Arrival Gate: {flight.Gate}\n" +
                              $" Airline: {flight.Airline}\n" +
                              $" Terminal: {flight.Terminal}\n" +
                              $" Flight Status: {flight.FlightStatus}\n");

        }

       

        public void SearchNearestFlight(DateTime searchTime, string searchPort, bool isArrival)
        {
            Console.WriteLine("Searching for nearest flight...");
            Console.WriteLine($"Time: {searchTime.ToString("yyyy-MM-dd HH:mm")}, " +
                $"Port: {searchPort}, Direction: {(isArrival ? "Arrival" : "Departure")}");
            
            List<FlightInformation> matchingFlights = new List<FlightInformation>();

            IEnumerable<FlightInformation> Arrivals = null;
            IEnumerable<FlightInformation> Departures = null;
            IEnumerable<FlightInformation> flights = isArrival ? Arrivals : Departures;

            foreach (FlightInformation flight in flights.Where(f => f.CityArrivals == searchPort))
            {
                TimeSpan timeDiff = isArrival ? (searchTime - flight.DateArrivals) :
                    (searchTime - flight.DateDepartures);

                if (Math.Abs(timeDiff.TotalHours) <= 1) 
                {
                    matchingFlights.Add(flight);
                }
            }
            matchingFlights.Sort((a, b) => isArrival ? a.DateArrivals.CompareTo(b.DateArrivals)
            : a.DateDepartures.CompareTo(b.DateDepartures));

            if (matchingFlights.Count > 0)
            {
                Console.WriteLine($"Found {matchingFlights.Count} matching flight(s):");
                foreach (FlightInformation flight in matchingFlights)
                {
                    Console.WriteLine(flight.ToString());
                }
            }
            else
            {
                Console.WriteLine("No matching flights found.");
            }
        }

        public void DisplayAllFlights()
        {
            {
                Console.WriteLine("===All Flights===");
                foreach (FlightInformation flight in Flights)
                {
                    if (flight != null)
                    {
                        Console.WriteLine($" Flight Number: {flight.FlightNumber}\n" +
                                          $" City of departure: {flight.CityDepartures}\n" +
                                          $" Departure Time: {flight.DateDepartures}\n" +
                                          $" City of arrival: {flight.CityArrivals}\n" +
                                          $" Arrival Time: {flight.DateArrivals}\n" +
                                          $" Departure Gate: {flight.Gate}\n" +
                                          $" Airline: {flight.Airline}\n" +
                                          $" Terminal: {flight.Terminal}\n" +
                                          $" Flight Status: {flight.FlightStatus}\n");
                    }
                }
            }
        }

        public void DisplayFlightInfo()
        {
            Console.WriteLine("===Flight Information===");
            Console.Write(" Enter flight number: ");
            string flightNumber = Console.ReadLine();
            foreach (FlightInformation flight in Flights)
            {
                if (flight != null && flight.FlightNumber == flightNumber)
                {
                    Console.WriteLine($" Flight Number: {flight.FlightNumber}\n" +
                                      $" City of departure: {flight.CityDepartures}\n" +
                                      $" Departure Time: {flight.DateDepartures}\n" +
                                      $" City of arrival: {flight.CityArrivals}\n" +
                                      $" Arrival Time: {flight.DateArrivals}\n" +
                                      $" Departure Gate: {flight.Gate}\n" +
                                      $" Airline: {flight.Airline}\n" +
                                      $" Terminal: {flight.Terminal}\n" +
                                      $" Flight Status: {flight.FlightStatus}\n");
                }
            }
        }
        public void DisplayEmergencyInfo()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("===Emergency Information===");
            Console.WriteLine(" In case of an emergency, please follow these instructions:");
            Console.WriteLine(" 1. Remain calm and follow instructions from airport staff.");
            Console.WriteLine(" 2. Locate the nearest emergency exit and evacuate the area immediately.");
            Console.WriteLine(" 3. Do not use elevators or escalators during an emergency.");
            Console.WriteLine(" 4. If there is a fire, activate the nearest fire alarm and use the nearest fire extinguisher to put out the fire if possible.");
            Console.WriteLine(" 5. Do not attempt to retrieve personal belongings during an emergency.");
            Console.WriteLine(" 6. If you require assistance, call the airport emergency number at 911.");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
