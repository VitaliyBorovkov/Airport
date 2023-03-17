using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport_Panel
{
    class Passengers : FlightInformationPanel
    {
        public List<Passengers> PassengerList = new List<Passengers>();
        public int Passenger { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nationality { get; set; }
        public string Passport { get; set; }
        public DateTime Birthday { get; set; }
        public string Sex { get; set; }
        public string FlightNumber { get; set; }
        public string Class { get; set; }

        public Passengers(int pasenger, string firstName, string lastName, string nationality, string passport,
                         DateTime birthday, string sex, string flightNumber, string flightClass)
        {
            Passenger = pasenger;
            FirstName = firstName;
            LastName = lastName;
            Nationality = nationality;
            Passport = passport;
            Birthday = birthday;
            Sex = sex;
            FlightNumber = flightNumber;
            Class = flightClass;
        }

        public Passengers()
        {
        }

        public void DisplayAllPassengers()
        {
            foreach (Passengers passenger in PassengerList)
            {
                if (passenger == null)
                {
                    Console.WriteLine(" Passengers not found.");
                    return;
                }
                else
                {
                    Console.WriteLine("Passengers: " + passenger);

                }
               
            }
        }

        public void AddPassenger()
        {
            Console.Write("Enter flight number: ");
            string flightNumber = Console.ReadLine();
            FlightInformation flight = Flights.Find(f => f.FlightNumber == flightNumber);
            if (flight == null)
            {
                Console.WriteLine("Flight not found.");
                return;
            }
            int pasenger = PassengerList.Count + 1;
            Console.Write("Enter first name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter last name: ");
            string lastName = Console.ReadLine();
            Console.Write("Enter nationality: ");
            string nationality = Console.ReadLine();
            Console.Write("Enter passport: ");
            string passport = Console.ReadLine();
            Console.Write("Enter birthday (dd/MM/yyyy): ");
            DateTime birthday = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
            Console.Write("Enter sex: ");
            string sex = Console.ReadLine();
            Console.Write("Enter class (Business or Economy): ");
            string flightClass = Console.ReadLine();
            if (flightClass.ToLower() != "business" && flightClass.ToLower() != "economy") 
            {
                Console.WriteLine("Invalid class.");
                return;
            }
            Passengers passenger = new Passengers(pasenger, firstName, lastName, nationality, passport, birthday, sex, flightNumber, flightClass);

            string connstring = @"Server=DESKTOP-DF21NNB\MSSQLSERVER03;Database=AirportDB1;Integrated Security=True";
            using (SqlConnection dbconn = new SqlConnection(connstring))
            {
                dbconn.Open();
                Console.WriteLine("Connection to AirportDB is open");

                string query = "INSERT INTO PassengerInfo (Passenger,FlightNumber, FirstName, LastName, Nationality, Passport, DateOfBirth, Sex) " +
                  "VALUES (@Passenger, @FlightNumber, @FirstName, @LastName, @Nationality, @Passport, @DateOfBirth, @Sex)";

                using (SqlCommand command = new SqlCommand(query, dbconn))
                {
                    command.Parameters.AddWithValue("@Passenger", passenger.Passenger);
                    command.Parameters.AddWithValue("@FlightNumber", passenger.FlightNumber);
                    command.Parameters.AddWithValue("@FirstName", passenger.FirstName);
                    command.Parameters.AddWithValue("@LastName", passenger.LastName);
                    command.Parameters.AddWithValue("@Nationality", passenger.Nationality);
                    command.Parameters.AddWithValue("@Passport", passenger.Passport);
                    command.Parameters.AddWithValue("@DateOfBirth", passenger.Birthday);
                    command.Parameters.AddWithValue("@Sex", passenger.Sex);
                    
                    command.ExecuteNonQuery();
                    
                }

                string query1 = "INSERT INTO ClassInfo (Class_id, FlightNumber, Class) " +
                  "VALUES (@Class_id, @FlightNumber, @Class)";
                using (SqlCommand command1 = new SqlCommand(query1, dbconn))
                {
                    command1.Parameters.AddWithValue("@Class_id", passenger.FlightNumber);
                    command1.Parameters.AddWithValue("@FlightNumber", passenger.FlightNumber);
                    command1.Parameters.AddWithValue("@Class", passenger.Class);
                    
                    command1.ExecuteNonQuery();
                }
            }

            PassengerList.Add(passenger);
            Console.WriteLine("Passenger added.");
        }

        public void EditPassenger()
        {
            Console.Write("Enter passport: ");
            string passport = Console.ReadLine();
            Passengers passenger = PassengerList.Find(p => p.Passport == passport);
            if (passenger == null)
            {
                Console.WriteLine("Passenger not found.");
                return;
            }

            Console.Write("Enter new first name (leave blank to keep current): ");
            string firstName = Console.ReadLine();
            if (!string.IsNullOrEmpty(firstName))
            {
                passenger.FirstName = firstName;
            }

            Console.Write("Enter new last name (leave blank to keep current): ");
            string lastName = Console.ReadLine();
            if (!string.IsNullOrEmpty(lastName))
            {
                passenger.LastName = lastName;
            }

            Console.Write("Enter new nationality (leave blank to keep current): ");
            string nationality = Console.ReadLine();
            if (!string.IsNullOrEmpty(nationality))
            {
                passenger.Nationality = nationality;
            }

            Console.Write("Enter new passport (leave blank to keep current): ");
            string newPassport = Console.ReadLine();
            if (!string.IsNullOrEmpty(newPassport))
            {
                passenger.Passport = newPassport;
            }

            Console.Write("Enter new birthday (dd/MM/yyyy) (leave blank to keep current): ");
            string birthdayString = Console.ReadLine();
            if (!string.IsNullOrEmpty(birthdayString))
            {
                passenger.Birthday = DateTime.ParseExact(birthdayString, "dd/MM/yyyy", null);
            }

            Console.Write("Enter new sex (leave blank to keep current): ");
            string sex = Console.ReadLine();
            if (!string.IsNullOrEmpty(sex))
            {
                passenger.Sex = sex;
            }

            Console.Write("Enter new class (Business or Economy) (leave blank to keep current): ");
            string flightClass = Console.ReadLine();
            if (!string.IsNullOrEmpty(flightClass))
            {
                FlightInformation flight = Flights.Find(f => f.FlightNumber == passenger.FlightNumber);
                if (flightClass.ToLower() == "Business" || flightClass.ToLower() == "Economy")
                {
                    passenger.Class = flightClass;
                    Console.WriteLine("Passenger class updated to {0}.", flightClass);
                }
                else
                {
                    Console.WriteLine("Invalid class.");
                }
            }

            Console.WriteLine("Passenger updated.");
        }

        public void DeletePassenger()
        {
            Console.Write("Enter passport: ");
            string passport = Console.ReadLine();
            Passengers passenger = PassengerList.Find(p => p.Passport == passport);
            if (passenger == null)
            {
                Console.WriteLine("Passenger not found.");
                return;
            }

            PassengerList.Remove(passenger);
            Console.WriteLine("Passenger deleted.");
        }

        public void SearchByPassport()
        {
            Console.Write("Enter passport: ");
            string passport = Console.ReadLine();
            List<Passengers> result = PassengerList.FindAll(p => p.Passport == passport);
            if (result.Count == 0)
            {
                Console.WriteLine("Passenger not found.");
                return;
            }

            Console.WriteLine("Passengers:");
            foreach (Passengers passenger in result)
            {
                Console.WriteLine(passenger);
            }
        }
        public new void SearchByFlightNumber()
        {
            Console.Write("Enter flight number: ");
            string flightNumber = Console.ReadLine();
            List<Passengers> result = PassengerList.FindAll(p => p.FlightNumber == flightNumber);
            if (result.Count == 0)
            {
                Console.WriteLine("Passengers not found.");
                return;
            }

            Console.WriteLine("Passengers:");
            foreach (Passengers passenger in result)
            {
                Console.WriteLine(passenger);
            }
        }

        public void SearchByClass()
        {
            Console.Write("Enter class (Business or Economy): ");
            string flightClass = Console.ReadLine();
            List<Passengers> result = PassengerList.FindAll(p => p.Class == flightClass);//??
            if (result.Count == 0)
            {
                Console.WriteLine("Passengers not found.");
                return;
            }

            Console.WriteLine("Passengers:");
            foreach (Passengers passenger in result)
            {
                Console.WriteLine(passenger);
            }
        }

        public void SearchByFirstNameLastName()
        {
            Console.Write("Enter first name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter last name: ");
            string lastName = Console.ReadLine();
            List<Passengers> result = PassengerList.FindAll(p => p.FirstName == firstName && p.LastName == lastName);
            if (result.Count == 0)
            {
                Console.WriteLine("Passengers not found.");
                return;
            }

            Console.WriteLine("Passengers:");
            foreach (Passengers passenger in result)
            {
                Console.WriteLine(passenger);
            }
        }

        public void SearchByCityArrival()
        {
            Console.Write("Enter arrival city: ");
            string city = Console.ReadLine();
            List<Passengers> result = PassengerList.FindAll(p => Flights.Find(f => f.FlightNumber == p.FlightNumber).CityArrivals == city);
            if (result.Count == 0)
            {
                Console.WriteLine("Passengers not found.");
                return;
            }

            Console.WriteLine("Passengers:");
            foreach (Passengers passenger in result)
            {
                Console.WriteLine(passenger);
            }
        }


        public void SearchByCityDeparture()
        {
            Console.Write("Enter departure city: ");
            string city = Console.ReadLine();
            List<Passengers> result = PassengerList.FindAll(p => Flights.Find(f => f.FlightNumber == p.FlightNumber).CityDepartures == city);
            if (result.Count == 0)
            {
                Console.WriteLine("Passengers not found.");
                return;
            }

            Console.WriteLine("Passengers:");
            foreach (Passengers passenger in result)
            {
                Console.WriteLine(passenger);
            }
        }
    }
    
   
}


