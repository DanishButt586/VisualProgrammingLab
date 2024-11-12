using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{

    internal class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, List<int>> students = new Dictionary<string, List<int>>();
            students["Alice"] = new List<int> { 85, 80, 90 };
            students["Bob"] = new List<int> { 70, 60, 75 };
            students["Charlie"] = new List<int> { 95, 92, 94 };
            students["Daisy"] = new List<int> { 35, 60, 58 };
            Console.WriteLine("Students Average");
            foreach (var student in students)
            {
                double average = student.Value.Average();
                Console.WriteLine($"{student.Key}:{student.Value}");
            }
            var topStudent = students.OrderByDescending(s=> s.Value.Average()).First();
            var lowStudent = students.OrderBy(s => s.Value.Average()).First();
            Console.WriteLine($"\nTop Performing: {topStudent.Key} with average of{topStudent.Value.Average(): F2}");
            Console.WriteLine($"\nTop Performing: {topStudent.Key} with average of{topStudent.Value.Average(): F2}");

            var failingStudents = students.Where(s=> s.Value.Average()) <60).Select(s=>s.Key).ToList();
            foreach(var student in failingStudents)
            {
                students.Remove(student);
            }

            Console.WriteLine("After removal");
            foreach (var student in students)
            {
                Console.WriteLine(students.Keys);
            }



        }
    }
}
