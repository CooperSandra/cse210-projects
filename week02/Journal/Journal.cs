using System;
using System.IO;
using System.Collections.Generic;

public class Journal
{
    private List<Entry> entries = new List<Entry>();
    private string autoSaveFile = "journalAutoSave.txt"; // default autosave file

    public void AddEntry(Entry newEntry)
    {
        entries.Add(newEntry);
    }

    public void DisplayEntries()
    {
        if (entries.Count == 0)
        {
            Console.WriteLine("No entries to display.\n");
            return;
        }

        foreach (Entry entry in entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string File)
    {
        using (StreamWriter writer = new StreamWriter(File))
        {
            foreach (Entry entry in entries)
            {
                writer.WriteLine(entry.ToFileString());
            }
        }
        Console.WriteLine($"Journal saved to {File}\n");
    }

    public void LoadFromFile(string file)
    {
        if (!File.Exists(file))
        {
            Console.WriteLine("File not found.\n");
            return;
        }

        entries.Clear();
        foreach (string line in File.ReadAllLines(file))
        {
            Entry entry = Entry.FromFileString(line);
            if (entry != null)
            {
                entries.Add(entry);
            }
        }
        Console.WriteLine($"Journal loaded from {file}\n");
    }

    public void AutoSave()
    {
        using (StreamWriter writer = new StreamWriter(autoSaveFile))
        {
            foreach (Entry entry in entries)
            {
                writer.WriteLine(entry.ToFileString());
            }
        }
        Console.WriteLine($"Journal saved to {autoSaveFile}\n");
    }
}