using System;

class Program
{
    static void Main(string[] args)
    {
        // Scripture example
        Reference reference = new Reference("Psalms", 23, 6);
        string text = "Surely goodness and mercy shall follow me all the days of my life: and I will dwell in the house of the Lord for ever.";
        Scripture scripture = new Scripture(reference, text);

        while (!scripture.IsCompletelyHidden())
        {
            ConsoleClear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress enter to continue or type 'quit' to finish");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords(4);
        }

        ConsoleClear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine("\nProgram has ended");
    }

    static void ConsoleClear()
    {
        try
        {
            Console.Clear();
        }
        catch (IOException)
        {
            Console.WriteLine(new string('\n', 20));
            }
        }
}