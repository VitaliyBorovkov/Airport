using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Airport_Panel
{
    internal class Program : FlightInformation
    {


        public static void Main(string[] args)
        {

            string connstring = @"Server=DESKTOP-DF21NNB\MSSQLSERVER03;Database=AirportDB1;Integrated Security=True";
            string querystring = "SELECT * FROM FlightInfo";
            string querystring1 = "SELECT * FROM AirlineInfo";

            using (SqlConnection dbconn = new SqlConnection(connstring))
            {
                FlightInformationPanel flightPanel = new FlightInformationPanel();
                Passengers passenger = new Passengers();
                dbconn.Open();
                Console.WriteLine("Connection to AirportDB is open");
                
                using (SqlCommand command = new SqlCommand(querystring, dbconn))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("{0,3} {1,10} {2,15} \t{3,15}\t {4,10} {5,10}",
                        reader[0], reader[1], reader[2], reader[3], reader[4], reader[5]);
                        
                    }
                    //command.ExecuteReader().Close();
                }
                //using (SqlCommand command = new SqlCommand(querystring1, dbconn))
                //{
                //    SqlDataReader reader = command.ExecuteReader();
                //    while (reader.Read())
                //    {
                //        Console.WriteLine("{0,3} {1,10} {2,15}",
                //        reader[0], reader[1], reader[2]);

                //    }
                //    command.ExecuteReader().Close();
                //}

                Console.WriteLine();
                Console.WriteLine("\t\t\t\t\tWelcome to the Airport Panel!");
                Console.WriteLine();

                while (true)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine(" Choose what you want to do:");
                    Console.WriteLine(" 1. Working with flights");
                    Console.WriteLine(" 2. Working with passengers");
                    Console.WriteLine(" 3. Exit the program");
                    Console.ForegroundColor = ConsoleColor.White;
                    int chose = int.Parse(Console.ReadLine());
                    if (chose == 1)
                    {
                        while (true)
                        {
                            Console.WriteLine(" ===Airport Flight Information Panel===");
                            Console.WriteLine(" 1. View Arrivals");
                            Console.WriteLine(" 2. View Departures");
                            Console.WriteLine(" 3. Add Flight");
                            Console.WriteLine(" 4. Edit Flight");
                            Console.WriteLine(" 5. Delete Flight");
                            Console.WriteLine(" 6. Search Flight by Flight Number");
                            Console.WriteLine(" 7. Search Flight by Arrival Time");
                            Console.WriteLine(" 8. Search Flight by Arrival Port");
                            Console.WriteLine(" 9. Search Nearest Flight");
                            Console.WriteLine(" 10. Display All Flights");
                            Console.WriteLine(" 11. Display Flight Information");
                            Console.WriteLine(" 12. Emergency Information");
                            Console.WriteLine(" 13. Exit");
                            Console.Write(" Enter your choice (1-13): ");
                            int choice = int.Parse(Console.ReadLine());

                            switch (choice)
                            {
                                case 1:
                                    Console.WriteLine();
                                    flightPanel.DisplayArrivals();
                                    Console.WriteLine();
                                    break;
                                case 2:
                                    Console.WriteLine();
                                    flightPanel.DisplayDepartures();
                                    Console.WriteLine();
                                    break;
                                case 3:
                                    Console.WriteLine();
                                    flightPanel.AddFlight();
                                    Console.WriteLine();
                                    break;
                                case 4:
                                    Console.WriteLine();
                                    flightPanel.EditFlight();
                                    Console.WriteLine();
                                    break;
                                case 5:
                                    Console.WriteLine();
                                    flightPanel.DeleteFlight();
                                    Console.WriteLine();
                                    break;
                                case 6:
                                    Console.WriteLine();
                                    flightPanel.SearchByFlightNumber();
                                    Console.WriteLine();
                                    break;
                                case 7:
                                    Console.WriteLine();
                                    flightPanel.SearchByArrivalTime();
                                    Console.WriteLine();
                                    break;
                                case 8:
                                    Console.WriteLine();
                                    flightPanel.SearchByArrivalPort();
                                    Console.WriteLine();
                                    break;
                                case 9:
                                    Console.WriteLine();
                                    flightPanel.SearchNearestFlight(DateTime.Now, "New York", true);
                                    Console.WriteLine();
                                    break;
                                case 10:
                                    Console.WriteLine();
                                    flightPanel.DisplayAllFlights();
                                    Console.WriteLine();
                                    break;
                                case 11:
                                    Console.WriteLine();
                                    flightPanel.DisplayFlightInfo();
                                    Console.WriteLine();
                                    break;
                                case 12:
                                    Console.WriteLine();
                                    flightPanel.DisplayEmergencyInfo();
                                    Console.WriteLine();
                                    break;
                                case 13:
                                    Console.WriteLine(" Exit application.");
                                    return;
                                default:
                                    Console.WriteLine(" Invalid choice!");
                                    break;
                            }
                        }
                    }
                    else if (chose == 2)
                    {
                        while (true)
                        {
                            Console.WriteLine("===Airport Passenger Information Panel===");
                            Console.WriteLine(" 1. View All Passengers");
                            Console.WriteLine(" 2. Add Passenger");
                            Console.WriteLine(" 3. Edit Passenger");
                            Console.WriteLine(" 4. Delete Passenger");
                            Console.WriteLine(" 5. Search Passenger by Passport");
                            Console.WriteLine(" 6. Search Passenger by Flight Number");
                            Console.WriteLine(" 7. Search Passenger by Class");
                            Console.WriteLine(" 8. Search Passenger by First name and Last name");
                            Console.WriteLine(" 9. Search Passenger by City Arrival");
                            Console.WriteLine(" 10. Search Passenger by City Departure");
                            Console.WriteLine(" 11. Exit");
                            Console.Write(" Enter your choice (1-11): ");
                            int choice = int.Parse(Console.ReadLine());
                            switch (choice)
                            {
                                case 1:
                                    Console.WriteLine();
                                    passenger.DisplayAllPassengers();
                                    Console.WriteLine();
                                    break;
                                case 2:
                                    Console.WriteLine();
                                    passenger.AddPassenger();
                                    Console.WriteLine();
                                    break;
                                case 3:
                                    Console.WriteLine();
                                    passenger.EditPassenger();
                                    Console.WriteLine();
                                    break;
                                case 4:
                                    Console.WriteLine();
                                    passenger.DeletePassenger();
                                    Console.WriteLine();
                                    break;
                                case 5:
                                    Console.WriteLine();
                                    passenger.SearchByPassport();
                                    Console.WriteLine();
                                    break;
                                case 6:
                                    Console.WriteLine();
                                    passenger.SearchByFlightNumber();
                                    Console.WriteLine();
                                    break;
                                case 7:
                                    Console.WriteLine();
                                    passenger.SearchByClass();
                                    Console.WriteLine();
                                    break;
                                case 8:
                                    Console.WriteLine();
                                    passenger.SearchByFirstNameLastName();
                                    Console.WriteLine();
                                    break;
                                case 9:
                                    Console.WriteLine();
                                    passenger.SearchByCityArrival();
                                    Console.WriteLine();
                                    break;
                                case 10:
                                    Console.WriteLine();
                                    passenger.SearchByCityDeparture();
                                    Console.WriteLine();
                                    break;
                                case 11:
                                    Console.WriteLine(" Exit application.");
                                    return;
                                default:
                                    Console.WriteLine(" Invalid choice!");
                                    break;
                            }

                        }
                    }
                    else if (chose == 3)
                    {
                        break;
                    }
                    //Console.ReadLine();
                }
            }



        }
    }
}
