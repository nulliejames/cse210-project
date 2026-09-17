using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        while (true)
        {
            Console.Write("Enter number: ");
            int number = int.Parse(Console.ReadLine() ?? "0");

            if (number == 0)
            {
                break;
            }

            numbers.Add(number);
        }

        if (numbers.Count == 0)
        {
            Console.WriteLine("No numbers were entered.");
            return;
        }

        int total = 0;
        int greatest = numbers[0];
        int closestPositive = int.MaxValue;

        foreach (int value in numbers)
        {
            total += value;
            greatest = Math.Max(greatest, value);

            if (value > 0 && value < closestPositive)
            {
                closestPositive = value;
            }
        }

        Console.WriteLine($"The sum is: {total}");
        Console.WriteLine($"The average is: {(double)total / numbers.Count}");
        Console.WriteLine($"The largest number is: {greatest}");

        if (closestPositive != int.MaxValue)
        {
            Console.WriteLine($"The smallest positive number is: {closestPositive}");
        }

        numbers.Sort();
        Console.WriteLine("The sorted list is:");
        foreach (int item in numbers)
        {
            Console.WriteLine(item);
        }
    }
}