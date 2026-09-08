using System;

class Program
{
    static void Main(string[] args)
    {
        // Guess my number game, and the computer pick the magic number
        // Console.WriteLine("Guess my number game, and the computer pick the magic number");
        // int magicNumber = int.Parse(Console.ReadLine());  

        // For Part 3, where we use a random number
        Random random = new Random();
        int magicNumber = random.Next(1, 101); // Generates a random number between 1 and 100


        int guess = -1;

        // We could also use a do-while loop here
        while (guess != magicNumber)
        {
            Console.WriteLine("What is your guess? ");
            guess = int.Parse(Console.ReadLine());

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
    }

}