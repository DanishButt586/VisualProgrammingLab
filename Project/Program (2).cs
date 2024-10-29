using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StudentClub clubManagement = new StudentClub();

            while (true)
            {
                Console.WriteLine("Student Club Management System");
                Console.WriteLine("\n----------------------------\n");

                Console.WriteLine("1. Register a new society");
                Console.WriteLine("2. Allocate funding to Societies");
                Console.WriteLine("3. Register an event for a Society");
                Console.WriteLine("4. Display Society Funding Information");
                Console.WriteLine("5. Display events for a Society");
                Console.WriteLine("6. Exit\n");

                Console.Write("Choose an option: ");
                int option;
                if (!int.TryParse(Console.ReadLine(), out option) || option < 1 || option > 6)
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 6.\n");
                    continue;
                }

                switch (option)
                {
                    case 1:
                        clubManagement.RegisterSociety();
                        break;
                    case 2:
                        clubManagement.AllocateFunding();
                        break;
                    case 3:
                        clubManagement.AddEvent();
                        break;
                    case 4:
                        clubManagement.ShowSocietyFunding();
                        break;
                    case 5:
                        clubManagement.ShowSocietyEvents();
                        break;
                    case 6:
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }
    }

    public class Member
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public string Contact { get; set; }
    }

    public class Society
    {
        public string Name { get; set; }
        public string Contact { get; set; }
        public List<string> Events { get; set; } = new List<string>();

        public void AddEvent(string eventName)
        {
            Events.Add(eventName);
        }
    }

    public class FundedSociety : Society
    {
        public double FundingAmount { get; set; }
    }

    public class NonFundedSociety : Society
    {
    }

    public class StudentClub
    {
        private List<Society> societies = new List<Society>();
        private double totalBudget = 10000.0; // Default budget value

        public void RegisterSociety()
        {
            Society newSociety = new Society();

            Console.Write("Enter society name: ");
            newSociety.Name = Console.ReadLine();

            Console.Write("Enter society contact: ");
            newSociety.Contact = Console.ReadLine();

            societies.Add(newSociety);
            Console.WriteLine($"Society '{newSociety.Name}' registered successfully.\n");
        }

        public void AllocateFunding()
        {
            Console.Write("Enter society name to allocate funding: ");
            string societyName = Console.ReadLine();
            Society selectedSociety = societies.Find(s => s.Name == societyName);

            if (selectedSociety == null)
            {
                Console.WriteLine("Society not found.\n");
                return;
            }

            Console.Write("Enter funding amount: ");
            double fundingAmount;
            if (double.TryParse(Console.ReadLine(), out fundingAmount) && fundingAmount <= totalBudget)
            {
                if (selectedSociety is FundedSociety fundedSociety)
                {
                    fundedSociety.FundingAmount += fundingAmount;
                }
                else
                {
                    fundedSociety = new FundedSociety
                    {
                        Name = selectedSociety.Name,
                        Contact = selectedSociety.Contact,
                        FundingAmount = fundingAmount
                    };
                    societies.Remove(selectedSociety);
                    societies.Add(fundedSociety);
                }
                totalBudget -= fundingAmount;
                Console.WriteLine($"Funding of {fundingAmount} allocated to '{selectedSociety.Name}'. Remaining budget: {totalBudget}\n");
            }
            else
            {
                Console.WriteLine("Invalid amount or insufficient budget.\n");
            }
        }

        public void AddEvent()
        {
            Console.Write("Enter society name to add an event: ");
            string societyName = Console.ReadLine();
            Society selectedSociety = societies.Find(s => s.Name == societyName);

            if (selectedSociety == null)
            {
                Console.WriteLine("Society not found.\n");
                return;
            }

            Console.Write("Enter event name: ");
            string eventName = Console.ReadLine();

            selectedSociety.AddEvent(eventName);
            Console.WriteLine($"Event '{eventName}' added to '{selectedSociety.Name}'.\n");
        }

        public void ShowSocietyFunding()
        {
            Console.WriteLine("\nSociety Funding Information:");
            foreach (var society in societies)
            {
                if (society is FundedSociety fundedSociety)
                {
                    Console.WriteLine($"Society: {fundedSociety.Name}, Funding: {fundedSociety.FundingAmount}");
                }
                else
                {
                    Console.WriteLine($"Society: {society.Name}, No funding allocated");
                }
            }
            Console.WriteLine();
        }

        public void ShowSocietyEvents()
        {
            Console.WriteLine("\nSociety Events:");
            foreach (var society in societies)
            {
                Console.WriteLine($"Society: {society.Name}");
                if (society.Events.Count > 0)
                {
                    foreach (var eventName in society.Events)
                    {
                        Console.WriteLine($" - {eventName}");
                    }
                }
                else
                {
                    Console.WriteLine(" No events registered.");
                }
            }
            Console.WriteLine();
        }
    }
}
