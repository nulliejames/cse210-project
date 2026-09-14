using System;

class Entry
{
    public string Date { get; }
    public string Prompt { get; }
    public string Response { get; }

    public Entry(string prompt, string response, string date)
    {
        Prompt = prompt;
        Response = response;
        Date = date;
    }

    public override string ToString()
    {
        return $"Date: {Date} - Prompt: {Prompt}\n{Response}";
    }

    public string ToFileLine()
    {
        return $"{Date}|{Prompt}|{Response}";
    }

    public static Entry FromFileLine(string line)
    {
        string[] parts = line.Split('|', 3);
        if (parts.Length != 3)
        {
            throw new FormatException("The journal entry is not in the expected format.");
        }

        return new Entry(parts[1], parts[2], parts[0]);
    }
}