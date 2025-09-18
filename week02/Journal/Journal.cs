using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();
    private string _autoSaveFile = "journal_autosave.txt";

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries Found.\n");
            return;
        }

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string file)
    {
        using (StreamWriter writer = new StreamWriter(file))
        {
            foreach (Entry entry in _entries)
            {
                writer.WriteLine(entry.ToFileString());
            }
        }
        Console.WriteLine($"Journal saved to {file}\n");
    }

    public void LoadFromFile(string file)
    {
        if (!File.Exists(file))
        {
            Console.WriteLine($"File {file} not found.\n");
            return;
        }
        
        _entries.Clear();
            foreach (String line in File.ReadAllLines(file))
            {
                Entry entry = Entry.FromFileString(line);
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
        Console.WriteLine($"[Auto-Save] Journal saved to {_autoSaveFile}\n");
     }
}