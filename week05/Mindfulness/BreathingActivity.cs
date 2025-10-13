using System;

public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base("Breathing", "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }
    
    public void Run()
    {
        DisplayStartingMessage();

        DateTime end = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < end)
        {
            Console.Write("Breathe in...");
            ShowCountDown(4);

            Console.Write("Breathe out...");
            ShowCountDown(4);

            Console.WriteLine("\n");
        }

        DisplayEndingMessage();
    }
}