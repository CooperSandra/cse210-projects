using System;


//Extra features have been added to GoalManager:
//Leveling - User begin at level 1, and increases every 1000 points. 
//Milestone - Messages revealed at threshholds (e.g., 1000, 5000, 10000)
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Eternal Quest!");
        GoalManager manager = new GoalManager();
        manager.Start();
        Console.WriteLine("Goodbye!");
    }
}