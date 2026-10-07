using System;
using System.Diagnostics;

class BreathingActivity : Activity
{
    public BreathingActivity()
        : base("Breathing Activity", "This activity will help you relax by guiding you through slow breathing. Clear your mind and focus on your breathing.")
    {
    }

    protected override void PerformActivity()
    {
        Stopwatch stopwatch = Stopwatch.StartNew();

        while (stopwatch.Elapsed.TotalSeconds < Duration)
        {
            Console.Write("Breathe in... ");
            ShowCountdown(string.Empty, 4, stopwatch);

            if (HasActivityTimeExpired(stopwatch))
            {
                break;
            }

            Console.Write("Breathe out... ");
            ShowCountdown(string.Empty, 4, stopwatch);
        }
    }
}