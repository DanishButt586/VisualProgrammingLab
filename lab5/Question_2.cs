using System;
using System.Collections.Generic;

public class Program
{
    // Base class Customer
    public class Customer
    {
        // Instance variables for Customer
        public string CustomerId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        // Parameterized Constructor
        public Customer(string customerId, string lastName, string firstName, string street, string city, string state, string zipCode, string phone, string email, string password)
        {
            CustomerId = customerId;
            LastName = lastName;
            FirstName = firstName;
            Street = street;
            City = city;
            State = state;
            ZipCode = zipCode;
            Phone = phone;
            Email = email;
            Password = password;
        }
    }

    // Derived class RetailCustomer
    public class RetailCustomer : Customer
    {
        public string CreditCardType { get; set; }
        public string CreditCardNo { get; set; }

        // Parameterized Constructor
        public RetailCustomer(string customerId, string lastName, string firstName, string street, string city, string state, string zipCode, string phone, string email, string password, string creditCardType, string creditCardNo)
            : base(customerId, lastName, firstName, street, city, state, zipCode, phone, email, password)
        {
            CreditCardType = creditCardType;
            CreditCardNo = creditCardNo;
        }
    }

    // Derived class CorporateCustomer
    public class CorporateCustomer : Customer
    {
        public string CompanyName { get; set; }
        public int FrequentFlyerPts { get; set; }
        public string BillingAccountNo { get; set; }

        // Parameterized Constructor
        public CorporateCustomer(string customerId, string lastName, string firstName, string street, string city, string state, string zipCode, string phone, string email, string password, string companyName, int frequentFlyerPts, string billingAccountNo)
            : base(customerId, lastName, firstName, street, city, state, zipCode, phone, email, password)
        {
            CompanyName = companyName;
            FrequentFlyerPts = frequentFlyerPts;
            BillingAccountNo = billingAccountNo;
        }
    }

    // Reservation class
    public class Reservation
    {
        public string ReservationNo { get; set; }
        public DateTime Date { get; set; }
        public List<Seat> Seats { get; set; }

        // Parameterized Constructor
        public Reservation(string reservationNo, DateTime date)
        {
            ReservationNo = reservationNo;
            Date = date;
            Seats = new List<Seat>();
        }

        // Method to reserve a seat
        public void ReserveSeat(Seat seat)
        {
            Seats.Add(seat);
        }
    }

    // Seat class
    public class Seat
    {
        public int RowNo { get; set; }
        public int SeatNo { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }

        // Parameterized Constructor
        public Seat(int rowNo, int seatNo, decimal price, string status)
        {
            RowNo = rowNo;
            SeatNo = seatNo;
            Price = price;
            Status = status;
        }
    }

    // Flight class
    public class Flight
    {
        public string FlightId { get; set; }
        public DateTime Date { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public TimeSpan DepartureTime { get; set; }
        public TimeSpan ArrivalTime { get; set; }
        public int SeatingCapacity { get; set; }
        public List<Seat> Seats { get; set; }

        // Parameterized Constructor
        public Flight(string flightId, DateTime date, string origin, string destination, TimeSpan departureTime, TimeSpan arrivalTime, int seatingCapacity)
        {
            FlightId = flightId;
            Date = date;
            Origin = origin;
            Destination = destination;
            DepartureTime = departureTime;
            ArrivalTime = arrivalTime;
            SeatingCapacity = seatingCapacity;
            Seats = new List<Seat>();
        }

        // Method to add a seat to a flight
        public void AddSeat(Seat seat)
        {
            if (Seats.Count < SeatingCapacity)
                Seats.Add(seat);
            else
                Console.WriteLine("Cannot add more seats. Seating capacity reached.");
        }
    }

    // Main method 
    public static void Main(string[] args)
    {
        // Creating a flight
        Flight flight = new Flight("PIA123", DateTime.Now, "Islamabad", "New York", new TimeSpan(10, 0, 0), new TimeSpan(14, 0, 0), 200);
        Seat seat1 = new Seat(1, 1, 250.00m, "Available");
        Seat seat2 = new Seat(1, 2, 250.00m, "Available");
        flight.AddSeat(seat1);
        flight.AddSeat(seat2);

        // Creating a reservation
        Reservation reservation = new Reservation("RES111", DateTime.Now);
        reservation.ReserveSeat(seat1);

        // Creating customers
        RetailCustomer retailCustomer = new RetailCustomer("233606", "Butt", "Danish", "123 Street", "Islamabad", "Islamabad", "12345", "123456789", "233606@students.au.edu.pk", "password123", "Visa", "1234567899876543");
        CorporateCustomer corporateCustomer = new CorporateCustomer("233510", "Ali", "Muhammad", "456 Street", "Islamabad", "Islamabad", "67891", "987654321", "233510@students.au.edu.pk", "password456", "Company Inc.", 5000, "ACC123");

        // Output
        Console.WriteLine($"Flight {flight.FlightId} from {flight.Origin} to {flight.Destination} with seating capacity {flight.SeatingCapacity}.");
        Console.WriteLine($"Reservation No: {reservation.ReservationNo} on {reservation.Date.ToShortDateString()} for seat {reservation.Seats[0].RowNo}-{reservation.Seats[0].SeatNo}");
        Console.WriteLine($"Retail Customer: {retailCustomer.FirstName} {retailCustomer.LastName}, Credit Card: {retailCustomer.CreditCardType} {retailCustomer.CreditCardNo}");
        Console.WriteLine($"Corporate Customer: {corporateCustomer.FirstName} {corporateCustomer.LastName}, Company: {corporateCustomer.CompanyName}, Frequent Flyer Points: {corporateCustomer.FrequentFlyerPts}");
    }
}
