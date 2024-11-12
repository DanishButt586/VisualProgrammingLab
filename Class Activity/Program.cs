using System;
using System.Collections.Generic;

class GenericListActivity
{
    static void Main()
    {
        // Step 1: Create a new list of integers
        List<int> numbers = new List<int>();

        // Step 2: Add some integers to the list
        numbers.Add(5);  // Adding 5 to the list
        numbers.Add(2);  // Adding 2 to the list
        numbers.Add(8);  // Adding 8 to the list
        numbers.Add(1);  // Adding 1 to the list

        // Step 3: Print the original list
        Console.WriteLine("Original List:");
        // Using a foreach loop to print all elements in the list
        foreach (int number in numbers)
        {
            Console.WriteLine(number);  // Print each number in the list
        }

        // Step 4: Sort the list in ascending order
        numbers.Sort();  // The Sort() method arranges the list in ascending order

        // Step 5: Print the sorted list
        Console.WriteLine("\nSorted List:");
        // Again, using a foreach loop to print the sorted list
        foreach (int number in numbers)
        {
            Console.WriteLine(number);  // Print each number in the sorted list
        }

        // Step 6: Remove an element from the list
        numbers.Remove(8);  // Removing the number 8 from the list

        // Step 7: Print the list after removal
        Console.WriteLine("\nList after removal:");
        // Using a foreach loop to print the modified list
        foreach (int number in numbers)
        {
            Console.WriteLine(number);  // Print each number in the updated list
        }
    }
}
