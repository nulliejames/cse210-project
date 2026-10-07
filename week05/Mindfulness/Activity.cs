using System;
using System.Diagnostics;
using System.Threading;

abstract class Activity
{
    private readonly string _activityName;
    private readonly string _description;
    private int _duration;

    protected string ActivityName => _activityName;
    protected int Duration => _duration;

    protected Activity(string activityName, string description)
    {
        _activityName = activityName;
        _description = description;
    }

    public void RunActivity()
    {
        Console.Clear();
        DisplayStartingMessage();
        Console.WriteLine("Prepare to begin...");
        ShowSpinner(3);

        PerformActivity();

        DisplayEndingMessage();
    }

    protected abstract void PerformActivity();

    protected void DisplayStartingMessage()
    {
        Console.WriteLine($"Welcome to the {_activityName}.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();

        _duration = ReadDuration();
    }

    protected void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine($"You have completed {Duration} seconds of the {_activityName}.");
        ShowSpinner(3);
        Console.WriteLine("Well done!");
        Console.WriteLine("Press Enter to return to the menu.");
        Console.ReadLine();
    }

    protected void ShowSpinner(int seconds, Stopwatch activityTimer = null)
    {
        char[] frames = { '|', '/', '-', '\\' };

        int elapsedMilliseconds = 0;
        while (elapsedMilliseconds < seconds * 1000 && !HasActivityTimeExpired(activityTimer))
        {
            Console.Write(frames[(elapsedMilliseconds / 250) % frames.Length]);
            int pauseMilliseconds = GetPauseSliceMilliseconds(250, activityTimer);
            Thread.Sleep(pauseMilliseconds);
            elapsedMilliseconds += pauseMilliseconds;
            Console.Write('\b');
        }

        Console.Write(' ');
        Console.Write('\b');
        Console.WriteLine();
    }

    protected void ShowCountdown(string message, int seconds, Stopwatch activityTimer = null)
    {
        Console.Write(message);

        for (int remaining = seconds; remaining > 0; remaining--)
        {
            if (HasActivityTimeExpired(activityTimer))
            {
                break;
            }

            Console.Write($"{remaining} ");
            Thread.Sleep(GetPauseSliceMilliseconds(1000, activityTimer));
            Console.Write("\b\b  \b\b");
        }

        Console.WriteLine();
    }

    protected bool HasActivityTimeExpired(Stopwatch activityTimer)
    {
        return activityTimer != null && activityTimer.Elapsed.TotalSeconds >= Duration;
    }

    protected int GetPauseSliceMilliseconds(int maximumMilliseconds, Stopwatch activityTimer)
    {
        if (activityTimer == null)
        {
            return maximumMilliseconds;
        }

        double remainingMilliseconds = (Duration - activityTimer.Elapsed.TotalSeconds) * 1000;
        return Math.Max(1, Math.Min(maximumMilliseconds, (int)Math.Ceiling(remainingMilliseconds)));
    }

    private static int ReadDuration()
    {
        while (true)
        {
            Console.Write("How long, in seconds, would you like for your session? ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int duration) && duration > 0)
            {
                return duration;
            }

            Console.WriteLine("Enter a whole number greater than zero.");
        }
    }
}