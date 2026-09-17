using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter your grade percentage: ");
        int score = int.Parse(Console.ReadLine() ?? "0");

        string grade;

        if (score >= 90)
        {
            grade = "A";
        }
        else if (score >= 80)
        {
            grade = "B";
        }
        else if (score >= 70)
        {
            grade = "C";
        }
        else if (score >= 60)
        {
            grade = "D";
        }
        else
        {
            grade = "F";
        }

        string modifier = "";
        int onesPlace = Math.Abs(score) % 10;
        if (onesPlace >= 7 && grade != "A" && grade != "F")
        {
            modifier = "+";
        }
        else if (onesPlace < 3 && grade != "A" && grade != "F")
        {
            modifier = "-";
        }

        Console.WriteLine($"Your grade is: {grade}{modifier}");
        if (score >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course.");
        }
        else
        {
            Console.WriteLine("Keep working hard. You can do better next time.");
        }
    }
}