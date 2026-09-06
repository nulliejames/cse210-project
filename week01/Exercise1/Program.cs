using System;

class Program
{
    static void Main(string[] args)
    {
        //Ask the user for their first and last name, then display their name in the format "Last, First Last"
        Console.WriteLine("What is your first name? ");
        string first = Console.ReadLine();

        Console.Write("What is your last name? ");
        string last = Console.ReadLine();

        Console.WriteLine($"Your name is {last}, {first} {last}");
    } 
}