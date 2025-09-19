/*
Author: Sandra Louise Cooper
Date: 9/18/2025
Description: A simple journal program that allows users to 
write, display, load, and save journal entries with prompts.
Each entry includes a date, a prompt, and the user's response.
The program also features an autosave functionality to prevent data loss.
*/

using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        JournalPrompts journals = new JournalPrompts();

        bool running = true;

        while (running)
        {
            Console.WriteLine("Welcome to the Journal Program!");
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    string prompt = journals.GetRandomPrompt();
                    Console.WriteLine("Prompt: " + prompt);
                    Console.Write("Your response: ");
                    string response = Console.ReadLine();

                    Entry newEntry = new Entry(DateTime.Now.ToString("yyyy-MM-dd"), prompt, response);

                    journal.AddEntry(newEntry);
                    Console.WriteLine("Entry added!\n");
                    break;

                case "2":
                    journal.DisplayEntries();
                    break;

                case "3":
                    Console.Write("Enter the filename to load: ");
                    string loadFilename = Console.ReadLine();
                    journal.LoadFromFile(loadFilename);
                    break;

                case "4":
                    Console.Write("Enter the filename to save: ");
                    string saveFilename = Console.ReadLine();
                    journal.SaveToFile(saveFilename);
                    break;

                case "5":
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.\n");
                    break;
            }
        }

    }
}