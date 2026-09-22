class Reference
{
    private readonly string _book;
    private readonly int _chapter;
    private readonly int _startVerse;
    private readonly int? _endVerse;

    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = verse;
    }

    public Reference(string book, int chapter, int startVerse, int endVerse)
        : this(book, chapter, startVerse)
    {
        _endVerse = endVerse;
    }

    public string GetDisplayText()
    {
        string verseText = _endVerse.HasValue
            ? $"{_startVerse}-{_endVerse.Value}"
            : _startVerse.ToString();

        return $"{_book} {_chapter}:{verseText}";
    }
}