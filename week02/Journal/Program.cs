using System;

class Program
{
    static void Main(string[] args)
    {
        // Creativity: the prompt list includes seven prompts to encourage more varied journal entries.
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        bool running = true;

        while (running)
        {
            Console.WriteLine();
            Console.WriteLine("Journal Menu");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit");
            Console.Write("Select a choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine($"Prompt: {prompt}");
                    Console.Write("Response: ");
                    string response = Console.ReadLine();
                    journal.AddEntry(new Entry(prompt, response, DateTime.Now.ToShortDateString()));
                    break;
                case "2":
                    journal.Display();
                    break;
                case "3":
                    Console.Write("Enter a filename: ");
                    journal.SaveToFile(Console.ReadLine());
                    Console.WriteLine("Journal saved.");
                    break;
                case "4":
                    Console.Write("Enter a filename: ");
                    journal.LoadFromFile(Console.ReadLine());
                    Console.WriteLine("Journal loaded.");
                    break;
                case "5":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Please choose a valid menu option.");
                    break;
            }
        }
    }
}