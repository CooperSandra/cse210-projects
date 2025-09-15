using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        int input = -1;

        while (input != 0)
        {
            Console.Write("Enter number: ");
            string userInput = Console.ReadLine();
            if (!int.TryParse(userInput, out input))
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
                continue;
            }

            if (input != 0) // don't add the 0
            {
                numbers.Add(input);
            }
        }

        // Double-check, print the list of numbers
        Console.WriteLine("You entered the following numbers:");
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }

        // Calculate the sum
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }

        // Display the sum
        Console.WriteLine($"The sum is: {sum}");

        // Calculate the average
        double average = (double)sum / numbers.Count;
        Console.WriteLine($"The average is: {average}"); // Display the average

        // Find the largest number
        int max = numbers[0];
        foreach (int number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }
        // Display the largest number
        Console.WriteLine($"The largest number is: {max}");

        // Find the smallest number
        int min = int.MaxValue;
        foreach (int number in numbers)
        {
            if (number > 0 && number < min)
            {
                min = number;
            }
        }

        // Display the smallest number
        if (min == int.MaxValue)
        {
            Console.WriteLine("No positive numbers were entered.");
        }
        else
        {
            Console.WriteLine($"The smallest positive number is: {min}");
        }
    }
}