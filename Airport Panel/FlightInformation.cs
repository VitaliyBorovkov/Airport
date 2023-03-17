using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Airport_Panel;

namespace Airport_Panel
{
    enum FlightStatus
    {
        Check_in,
        Gate_closed,
        Arrived,
        Departed_at,
        Unknown,
        Canceled,
        Expected_at,
        Delayed,
        In_flight
    }
    enum Terminal
    {
        A,
        B,
        C,
        D,
        E,
        F,

    }
    enum Gate
    {
        A1,
        A2,
        A3,
        A4,
        A5,
        A6,
    }
    enum Airlines
    {
        British_Airways,
        Air_France,
        Lufthansa,
        American_Airlines,
        Cathay_Pacific,
        Emirates,
    }
    public enum Class
    {
        Economy,
        Business,
    }
    class FlightInformation : IComparable<FlightInformation>
    {
        public int Flight { get; set; }
        public string FlightNumber { get; set; }
        public DateTime DateArrivals { get; set; }
        public DateTime DateDepartures { get; set; }
        public string CityArrivals { get; set; }
        public string CityDepartures { get; set; }
        public Airlines Airline { get; set; }
        public Terminal Terminal { get; set; }
        public Gate Gate { get; set; }
        public FlightStatus FlightStatus { get; set; }
        public Class Class { get; internal set; }
        public double BusinessClassPrice { get; set; }
        public double EconomyClassPrice { get; set; }

        public FlightInformation(int flight, string flightNumber, DateTime dateArrivals, DateTime dateDepartures,
            string cityArrivals, string cityDepartures, Airlines airline, Terminal terminal,
            FlightStatus flightStatus, Gate gate)
        {
            Flight = flight;
            FlightNumber = flightNumber;
            DateArrivals = dateArrivals;
            DateDepartures = dateDepartures;
            CityArrivals = cityArrivals;
            CityDepartures = cityDepartures;
            Airline = airline;
            Terminal = terminal;
            FlightStatus = flightStatus;
            Gate = gate;
        }

        public FlightInformation()
        {
        }
        public int CompareTo(FlightInformation other)
        {
            return this.FlightNumber.CompareTo(other.FlightNumber);
        }

        public void Info()
        {
            Console.WriteLine(" Date of arrival: {0}", DateArrivals);
            Console.WriteLine(" Date of departures: {0}", DateDepartures);
            Console.WriteLine(" Flight number: {0}", FlightNumber);
            Console.WriteLine(" City of arrival: {0}", CityArrivals);
            Console.WriteLine(" City of departure: {0}", CityDepartures);
            Console.WriteLine(" Airline: {0}", Airline);
            Console.WriteLine(" Terminal: {0}", Terminal);
            Console.WriteLine(" Gate: {0}", Gate);
            Console.WriteLine(" Flight status: {0}", FlightStatus);
            Console.WriteLine();

        }
    }
}


