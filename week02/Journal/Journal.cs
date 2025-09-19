using System;
using System.IO;
using System.Collections.Generic;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();
    private string _autoSaveFile = "journal-autosave.txt"; // default autosave file

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayEntries()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries to display.\n");
            return;
        }

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string File)
    {
        using (StreamWriter writer = new StreamWriter(File))
        {
            foreach (Entry entry in _entries)
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

        _entries.Clear();
        foreach (string line in File.ReadAllLines(file))
        {
            Entry entry = Entry.FromFileString(line);
            if (entry != null)
            {
                _entries.Add(entry);
            }
        }
        Console.WriteLine($"Journal loaded from {file}\n");
    }

    public void AutoSave()
    {
        using (StreamWriter writer = new StreamWriter(_autoSaveFile))
        {
            foreach (Entry entry in _entries)
            {
                writer.WriteLine(entry.ToFileString());
            }
        }
        Console.WriteLine($"Journal saved to {_autoSaveFile}\n");
    }
}