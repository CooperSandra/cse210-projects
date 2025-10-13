using System;
using System.Collections.Generic;

public class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {

    };

    private List<string> _questions = new List<string>
    {

    };

    public ReflectingActivity()
        : base("Reflecting", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine($"Consider the following prompt:\n-- {GetRandomPrompt()} --");
        Console.WriteLine("\nWhen you have something in mind, select enter to continue.");
        Console.ReadLine();

        Console.WriteLine("\nNow ponder the following questions as they appear:");
        ShowSpinner(3);

        DisplayQuestions();

        DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        Random rand = new Random();
        return _prompts[rand.Next(_prompts.Count)];
    }

    private string GetRandomQuestion()
    {
        Random rand = new Random();
        return _questions[rand.Next(_questions.Count)];
    }

    private void DisplayQuestions()
    {
        DateTime end = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < end)
        {
            Console.WriteLine($"> {GetRandomQuestion()}");
            ShowSpinner(6);
        }
    }

}
