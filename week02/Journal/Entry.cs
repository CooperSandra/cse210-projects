using System;

public class Entry
{
    private string Date;
    private string Prompt;
    private string Response;

    public Entry(string date, string prompt, string response)
    {
        Date = date;
        Prompt = prompt;
        Response = response;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {Date}");
        Console.WriteLine($"Prompt: {Prompt}");
        Console.WriteLine($"Response: {Response}\n");
    }

    public string ToFileString()
    {
        return $"{Date}|{Prompt}|{Response}";
    }

    public static Entry FromFileString(string line)
    {
        string[] parts = line.Split('|');
        if (parts.Length == 3)
        {
            return new Entry(parts[0], parts[1], parts[2]);
        }
        return null;
    }
}