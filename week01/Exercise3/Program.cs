using System;

class Program
{
    static void Main(string[] args)
    {
        // Guess my number game, and the computer pick the magic number
        // Console.WriteLine("Guess my number game, and the computer pick the magic number");
        // int magicNumber = int.Parse(Console.ReadLine());  

        // For Part 3, where we use a random number
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101); // Generates a random number between 1 and 100


        int guess = -1;

        // We could also use a do-while loop here
        while (guess != magicNumber)
        {
            Console.WriteLine("Guess a number between 1 and 100:");
            guess = int.Parse(Console.ReadLine());

            if (guess < magicNumber)
            {
                Console.WriteLine("Too low! Try again.");
            }
            else if (guess > magicNumber)
            {
                Console.WriteLine("Too high! Try again.");
            }
            else
            {
                Console.WriteLine("Congratulations! You've guessed the magic number!");
            }
        }
    }

}