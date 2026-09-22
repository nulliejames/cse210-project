using System;
using System.Collections.Generic;

class Scripture
{
    private readonly Reference _reference;
    private readonly List<Word> _words;
    private readonly Random _random = new Random();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        foreach (string word in text.Split(' ', StringSplitOptions.RemoveEmptyEntries))
        {
            _words.Add(new Word(word));
        }
    }

    public string GetDisplayText()
    {
        List<string> displayedWords = new List<string>();

        foreach (Word word in _words)
        {
            displayedWords.Add(word.GetDisplayText());
        }

        return $"{_reference.GetDisplayText()} {string.Join(" ", displayedWords)}";
    }

    public void HideRandomWords(int count)
    {
        List<Word> visibleWords = _words.FindAll(word => !word.IsHidden());
        int wordsToHide = Math.Min(count, visibleWords.Count);

        for (int index = 0; index < wordsToHide; index++)
        {
            int randomIndex = _random.Next(visibleWords.Count);
            visibleWords[randomIndex].Hide();
            visibleWords.RemoveAt(randomIndex);
        }
    }

    public bool AllWordsHidden()
    {
        return _words.TrueForAll(word => word.IsHidden());
    }
}