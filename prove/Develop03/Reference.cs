class VerseReference
{
    private string _book, _chapter, _verse;

    public VerseReference(string book, string chapter, string verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
    }

    public override string ToString()
    {
        return $"{_book} {_chapter}:{_verse}";
    }
}