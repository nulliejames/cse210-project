using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

class ListingActivity : Activity
{
    private readonly List<string> _prompts = new()
    {
        "Who are people that you appreciate?",
        "What are personal strengths you are grateful for?",
        "Who have you helped this week?",
        "When have you felt the Holy Ghost this month?",
        "What are some things you value?",
        "Who are people you have helped this week?"
    };

    public ListingActivity()
        : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }

    protected override void PerformActivity()
    {
        string prompt = _prompts[Random.Shared.Next(_prompts.Count)];
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine($"--- {prompt} ---");
        Console.Write("You may begin in: ");
        ShowCountdown(string.Empty, 5);

        Stopwatch stopwatch = Stopwatch.StartNew();
        int responseCount = 0;

        while (stopwatch.Elapsed.TotalSeconds < Duration)
        {
            Console.Write($"Response {responseCount + 1}: ");
            string response = ReadTimedLine(stopwatch);

            if (!string.IsNullOrWhiteSpace(response))
            {
                responseCount++;
            }
        }

        Console.WriteLine($"You listed {responseCount} response(s).");
    }

    private string ReadTimedLine(Stopwatch stopwatch)
    {
        StringBuilder response = new();

        while (!HasActivityTimeExpired(stopwatch))
        {
            if (!Console.KeyAvailable)
            {
                Thread.Sleep(GetPauseSliceMilliseconds(50, stopwatch));
                continue;
            }

            ConsoleKeyInfo key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.Enter)
            {
                Console.WriteLine();
                return response.ToString();
            }

            if (key.Key == ConsoleKey.Backspace)
            {
                if (response.Length > 0)
                {
                    response.Length--;
                    Console.Write("\b \b");
                }
            }
            else if (!char.IsControl(key.KeyChar))
            {
                response.Append(key.KeyChar);
                Console.Write(key.KeyChar);
            }
        }

        Console.WriteLine();
        return string.Empty;
    }
}