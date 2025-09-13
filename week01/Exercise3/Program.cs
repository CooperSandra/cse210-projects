using System;

class Program
{
    static void Main(string[] args)
    {
        // Display a greeting message to the user
        //Console.WriteLine("\nWhat is the magic number? ");
        //int magicNumber = int.Parse(Console.ReadLine());

        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101); // Generates a random number between 1 and 100

        int guess = -1;

        // Prompt the user to guess the magic number
        while (guess != magicNumber)
        {
            Console.WriteLine("Guess the magic number: ");
            guess = int.Parse(Console.ReadLine());

            // Check if the user's guess is correct and provide feedback
            if (guess < magicNumber)
            {
                Console.WriteLine("Too low - try again!\n");
            }
            else if (guess > magicNumber)
            {
                Console.WriteLine("Too high - try again!\n");
            }
            else
            {
                Console.WriteLine("Congratulations! You guessed the magic number!");
            }
        }
    }
}