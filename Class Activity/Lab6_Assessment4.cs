using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Creating a dictionary to store student names and their scores
            Dictionary<string, List<int>> students = new Dictionary<string, List<int>>();

            // Adding students with their respective scores
            students["Alice"] = new List<int> { 85, 80, 90 };
            students["Bob"] = new List<int> { 70, 60, 75 };
            students["Charlie"] = new List<int> { 95, 92, 94 };
            students["Daisy"] = new List<int> { 35, 60, 58 };

            Console.WriteLine("Students Average:");

            // Calculate and display the average score for each student
            foreach (var student in students)
            {
                double average = student.Value.Average();
                Console.WriteLine($"{student.Key}: {string.Join(", ", student.Value)} - Average: {average:F2}");
            }

            // Find the top and lowest performing students based on average score
            var topStudent = students.OrderByDescending(s => s.Value.Average()).First();
            var lowStudent = students.OrderBy(s => s.Value.Average()).First();

            Console.WriteLine($"\nTop Performing: {topStudent.Key} with an average of {topStudent.Value.Average():F2}");
            Console.WriteLine($"Lowest Performing: {lowStudent.Key} with an average of {lowStudent.Value.Average():F2}");

            // Find students who have an average score below 60 and remove them from the dictionary
            var failingStudents = students
                .Where(s => s.Value.Average() < 60)
                .Select(s => s.Key)
                .ToList();

            foreach (var student in failingStudents)
            {
                students.Remove(student);
            }

            // Display remaining students after removal
            Console.WriteLine("\nAfter removal of failing students:");
            foreach (var student in students)
            {
                Console.WriteLine($"{student.Key}: {string.Join(", ", student.Value)}");
            }
        }
    }
}
