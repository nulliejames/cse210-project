using System;

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();
        string playAgain = "yes";

        while (playAgain.Equals("yes", StringComparison.OrdinalIgnoreCase))
        {
            int magicNumber = random.Next(1, 101);
            int guess = -1;
            int guessCount = 0;

            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                guessCount++;

                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("Congratulations! You guessed it!");
                }
            }

            Console.WriteLine($"It took you {guessCount} guesses.");
            Console.Write("Would you like to play again? ");
            playAgain = Console.ReadLine();
        }
    }

}