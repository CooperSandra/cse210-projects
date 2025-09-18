using System;
using System.Collections.Generic;

public class JournalPrompt
{
    private List<string> _prompts = new List<string>
    {
        "Who was the most interesting person you interacted with today?",
        "Describe what positive impact they had on your day.",
        "How did you see the hand of the Lord in your life today?",
        "What was the strongest emotion you felt today?",
        "What was the best part of your day?",
        "What are you grateful for today?",
        "Describe a challenge you faced today and how you overcame it.",
        "What is something new you learned today?",
        "Reflect on a moment that made you smile today.",
        "What is a goal you have for tomorrow?",
        "How did you show kindness to someone today?",
        "What is something you wish you had done differently today?",
        "What is something you did today that you're proud of?",
        "How did you take care of yourself today?",
        "What is a favorite memory that came to mind today?"
    };

    private Random _random = new Random();

    public string GetRandomPrompt()
    {
        int index = _random.Next(_prompts.Count);
        return _prompts[index];
    }
}