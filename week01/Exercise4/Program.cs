using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        int number;
        do
        {
            Console.Write("Enter number: ");
            number = int.Parse(Console.ReadLine());

            if (number != 0)
            {
                numbers.Add(number);
            }
        } while (number != 0);

        if (numbers.Count == 0)
        {
            Console.WriteLine("No numbers were entered.");
            return;
        }

        int sum = 0;
        int largest = numbers[0];
        int? smallestPositive = null;

        foreach (int value in numbers)
        {
            sum += value;

            if (value > largest)
            {
                largest = value;
            }

            if (value > 0 && (smallestPositive == null || value < smallestPositive))
            {
                smallestPositive = value;
            }
        }

        double average = (double)sum / numbers.Count;

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {largest}");

        if (smallestPositive != null)
        {
            Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        }

        numbers.Sort();
        Console.WriteLine("The sorted list is:");

        foreach (int value in numbers)
        {
            Console.WriteLine(value);
        }
    }
}