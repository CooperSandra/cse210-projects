using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("---Menu Options:---");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Listing Activity");
            Console.WriteLine("3. Reflecting Activity");
            Console.WriteLine("4. Quit");
            Console.WriteLine("Select a choice from the menu:");

            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    new BreathingActivity().Run();
                    break;
                case "2":
                    new ListingActivity().Run();
                    break;
                case "3":
                    new ReflectingActivity().Run();
                    break;
                case "4":
                    Console.WriteLine("Goodbye! Remember to practice mindfulness.");
                    break;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        }
    }
}