using System;

class Program
{
    static void Main(string[] args)
    {
        // Ask the user for their grade percentage
        Console.WriteLine("\nEnter your grade percentage (ex. 75): ");
        string input = Console.ReadLine();
        int gradePercentage = int.Parse(input);

        // Initialize a variable to hold the letter grade
        string letterGrade = " ";

        // Determine the letter grade based on the percentage

        if (gradePercentage >= 90)
        {
            letterGrade = "A";
        }
        else if (gradePercentage >= 80)
        {
            letterGrade = "B";
        }
        else if (gradePercentage >= 70)
        {
            letterGrade = "C";
        }
        else if (gradePercentage >= 60)
        {
            letterGrade = "D";
        }
        else
        {
            letterGrade = "F";
        }

        // Display the letter grade to the user
        Console.WriteLine($"Your letter grade is: {letterGrade}");

        // Provide feedback based on the grade percentage
        if (gradePercentage >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course.");
        }
        else
        {
            Console.WriteLine("Unfortunately, you did not pass. Keep trying, you've got this!");
        }
    }
}