class ScriptureContent
{
    private string _text;
    private VerseReference _reference;

    public ScriptureContent(VerseReference reference, string text)
    {
        _reference = reference;
        _text = text;
    }

    public override string ToString()
    {
        return $"{_text}";
    }
}
