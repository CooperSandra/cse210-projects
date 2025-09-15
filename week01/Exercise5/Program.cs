using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();

        string userName = PromptUserName();
        int userNumber = PromptUserNumber();
        int squaredNumber = SquareNumber(userNumber);
        DisplayResult(userName, squaredNumber);
    }

    // This method displays a welcome message to the user.
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    // This method prompts the user for their name and returns it.
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        return name;
    }

    // This method prompts the user for their favorite number and returns it as an integer.
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        string input = Console.ReadLine();
        int number = int.Parse(input);
        return number;
    }

    // This method calculates the square of a given number and returns it.
    static int SquareNumber(int number)
    {
        return number * number;
    }

    // This method displays the result to the user.
    static void DisplayResult(string name, int squaredNumber)
    {
        Console.WriteLine($"{name}, the square of your favorite number is {squaredNumber}.");
    }
}