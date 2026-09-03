using System;

class Program
{
    static void Main(string[] args)
    {
        // Prompt the user for their grade percentage
        Console.Write("What is your percentage? ");
        string answer = Console.ReadLine();
        int percent = int.Parse(answer);

        string letterGrade = "";

        if (percent >= 90   )
        {
            letterGrade = "A";
        }
        else if (percent >= 80)
        {
            letterGrade = "B";
        }
        else if (percent >= 70)
        {
            letterGrade = "C";
        }
        else if (percent >= 60)
        {
            letterGrade = "D";
        }
        else
        {
            letterGrade = "F";
        }
        {
            Console.WriteLine($"Your grade is: {letterGrade}");
        }
        if (percent >= 70)
        {
            Console.WriteLine($"You passed!");
        }
        else
        {
            Console.WriteLine($"Better luck next time!");
        }
    }
}