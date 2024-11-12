using System;
using System.Collections.Generic;

namespace ConsoleApp5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Creating a dictionary of countries and their capitals
            Dictionary<string, string> countries = new Dictionary<string, string>
            {
                ["USA"] = "Washington, D.C.",
                ["France"] = "Paris",
                ["Japan"] = "Tokyo",  // Corrected the typo here
                ["India"] = "New Delhi"
            };

            // Displaying all countries and their capitals
            Console.WriteLine("Countries and Capitals:");
            foreach (var pair in countries)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }

            // Accessing and displaying the capital of Japan
            Console.WriteLine($"\nCapital of Japan: {countries["Japan"]}");

            // Removing France from the dictionary
            countries.Remove("France");

            // Displaying the updated list of countries and capitals
            Console.WriteLine($"\nUpdated Countries and Capitals:");
            foreach (var pair in countries)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }
        }
    }
}
