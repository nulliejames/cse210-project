using System;
using System.Collections.Generic;
using System.IO;

class Journal
{
    private readonly List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void Display()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("There are no journal entries yet.");
            return;
        }

        foreach (Entry entry in _entries)
        {
            Console.WriteLine(entry);
            Console.WriteLine();
        }
    }

    public void SaveToFile(string filename)
    {
        using StreamWriter outputFile = new StreamWriter(filename);
        foreach (Entry entry in _entries)
        {
            outputFile.WriteLine(entry.ToFileLine());
        }
    }

    public void LoadFromFile(string filename)
    {
        List<Entry> loadedEntries = new List<Entry>();
        foreach (string line in File.ReadAllLines(filename))
        {
            if (!string.IsNullOrWhiteSpace(line))
            {
                loadedEntries.Add(Entry.FromFileLine(line));
            }
        }

        _entries.Clear();
        _entries.AddRange(loadedEntries);
    }
}