using System;

class Program
{
    static void Main(string[] args)
    {
        int completedActivities = 0;
        bool isRunning = true;

        while (isRunning)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine($"Activities completed this visit: {completedActivities}");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Surprise me");
            Console.WriteLine("0. Quit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();
            Activity activity = choice switch
            {
                "1" => new BreathingActivity(),
                "2" => new ReflectingActivity(),
                "3" => new ListingActivity(),
                // Surprise me randomly selects an activity; the menu also tracks completed sessions.
                "4" => CreateRandomActivity(),
                "0" => null,
                _ => null
            };

            if (choice == "0")
            {
                isRunning = false;
            }
            else if (activity == null)
            {
                Console.WriteLine("Please choose one of the listed options.");
                Thread.Sleep(1200);
            }
            else
            {
                activity.RunActivity();
                completedActivities++;
            }
        }

        Console.WriteLine($"You completed {completedActivities} activity session(s). Goodbye.");
    }

    private static Activity CreateRandomActivity()
    {
        return Random.Shared.Next(3) switch
        {
            0 => new BreathingActivity(),
            1 => new ReflectingActivity(),
            _ => new ListingActivity()
        };
    }
}