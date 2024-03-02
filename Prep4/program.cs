using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        // Step 1: Ask the user for a series of numbers and append each one to a list
        int userInput;
        do
        {
            Console.Write("Enter number: ");
            userInput = int.Parse(Console.ReadLine());

            if (userInput != 0)
            {
                numbers.Add(userInput);
            }
        } while (userInput != 0);

        // Step 2: Compute the sum of the numbers in the list
        int sum = numbers.Sum();

        // Step 3: Compute the average of the numbers in the list
        double average = numbers.Average();

        // Step 4: Find the maximum number in the list
        int max = numbers.Max();

        // Step 5: Print the results
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");

        // Stretch Challenge: Have the user enter both positive and negative numbers,
        // then find the smallest positive number (the positive number that is closest to zero)
        int smallestPositive = numbers.Where(n => n > 0).DefaultIfEmpty(int.MaxValue).Min();
        if (smallestPositive != int.MaxValue)
        {
            Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        }
        else
        {
            Console.WriteLine("There are no positive numbers.");
        }

        // Stretch Challenge: Sort the numbers in the list and display the new, sorted list
        List<int> sortedNumbers = numbers.OrderBy(n => n).ToList();
        Console.WriteLine("The sorted list is:");
        foreach (int num in sortedNumbers)
        {
            Console.WriteLine(num);
        }
    }
}
