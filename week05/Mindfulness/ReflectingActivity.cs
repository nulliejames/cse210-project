using System;
using System.Collections.Generic;
using System.Diagnostics;

class ReflectingActivity : Activity
{
    private readonly List<string> _prompts = new()
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless.",
        "Think of a time when you made someone smile."
    };

    private readonly List<string> _questions = new()
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectingActivity()
        : base("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the strength you already have and how you can use it in other aspects of your life.")
    {
    }

    protected override void PerformActivity()
    {
        string prompt = _prompts[Random.Shared.Next(_prompts.Count)];
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine($"--- {prompt} ---");
        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
        ShowSpinner(5);

        Stopwatch stopwatch = Stopwatch.StartNew();
        int questionIndex = Random.Shared.Next(_questions.Count);
        int questionsAsked = 0;

        while (stopwatch.Elapsed.TotalSeconds < Duration)
        {
            Console.WriteLine($"> {_questions[questionIndex]}");
            questionIndex = (questionIndex + 1) % _questions.Count;
            questionsAsked++;
            ShowSpinner(8, stopwatch);
        }

        Console.WriteLine($"You reflected on {questionsAsked} question(s).");
    }
}