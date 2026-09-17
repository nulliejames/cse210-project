using System;

class Program
{
    static void Main(string[] args)
    {
        Random generator = new Random();
        bool continuePlaying = true;

        while (continuePlaying)
        {
            int target = generator.Next(1, 101);
            int attempts = 0;
            int guess;

            do
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine() ?? "0");
                attempts++;

                if (guess < target)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > target)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("Congratulations! You guessed it!");
                }
            } while (guess != target);

            Console.WriteLine($"It took you {attempts} guesses.");
            Console.Write("Would you like to play again? ");
            string answer = Console.ReadLine() ?? "";
            continuePlaying = answer.Trim().Equals("yes", StringComparison.OrdinalIgnoreCase);
        }
    }

}