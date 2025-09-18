/* 
Program.cs
Author: Sandra Cooper
Date: 2024-06-10

Description:
This is the main entry point for the Journal application. It initializes the program 
and provides a simple user interface to interact with journal entries.

Exceeding Requirements:
- Added an auto-save feature that saves the journal to a default file upon exiting the program.
*/

using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        JournalPrompt prompt = new JournalPrompt();

        bool running = true;
        while (running)
        {
            Console.WriteLine("Welcome to the Journal Program!");
            Console.WriteLine("Please choose an option:");
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Save");
            Console.WriteLine("4. Load");
            Console.WriteLine("5. Exit");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    string promptText = prompt.GetRandomPrompt();
                    Console.WriteLine($"Prompt: " + prompt);
                    Console.Write("Your response: ");
                    string response = Console.ReadLine();

                    Entry newEntry = new Entry(DateTime.Now.ToShortDateString(), promptText, response);
                    journal.AddEntry(newEntry);
                    Console.WriteLine("Entry added!\n");
                    break;

                case "2":
                    journal.DisplayAll();
                    break;

                case "3":
                    Console.Write("Enter filename to save: ");
                    string saveFile = Console.ReadLine();
                    journal.SaveToFile(saveFile);
                    break;

                case "4":
                    Console.Write("Enter filename to load: ");
                    string loadFile = Console.ReadLine();
                    journal.LoadFromFile(loadFile);
                    break;

                case "5":
                    journal.AutoSave(); // Auto-save feature added on exit
                    running = false;
                    Console.WriteLine("Goodbye! Journal saved automatically");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.\n");
                    break;
            }
        }
    }


    
}