using System;
using System.Collections.Generic;

public class JournalPrompts
{
    private List<string> prompts = new List<string>
    {
        "Think about the moments in your past that make you feel agitated and uneasy. List those moments: ",
        "List the moments that give you a feeling of peace and well-being: ",
        "Look at the present moment. What is causing you to feel agitated or uneasy right now? ",
        "Think about the future. What are your hopes and dreams that make you feel peaceful and content? ",
        "Look at the people in your life who you feel the safest with. List those people: ",
        "Think about the places where you feel the safest and most at peace. List those places: ",
        "Think about the activities that make you feel calm and centered. List those activities: ",
        "How can you bring more of those peaceful moments into your daily life? ",
        "What are your gifts to the world? ",
        "What are you most grateful for in your life? ",
        "What can you do to reject negativity and embrace positivity? ",
        "What are some positive affirmations you can tell yourself daily? ",
    };
    private Random random = new Random();
    public string GetRandomPrompt()
    {
        int index = random.Next(prompts.Count);
        return prompts[index];
    }
}