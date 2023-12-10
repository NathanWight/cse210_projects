class Memorizer
{
    private string[] _wordList;
    private int _totalWordsRemoved = 0;
    private const int WordsToRemove = 3;

    public Memorizer(string[] wordList)
    {
        _wordList = wordList;
    }

    public void RemoveWords()
    {
        int wordsRemoved = 0;

        do
        {
            int randomIndex = new Random().Next(0, _wordList.Length);

            if (!_wordList[randomIndex].Contains('_'))
            {
                _wordList[randomIndex] = new string('_', _wordList[randomIndex].Length);
                wordsRemoved++;
                _totalWordsRemoved++;

                if ((_wordList.Length - WordsToRemove) <= _totalWordsRemoved && _totalWordsRemoved < (_wordList.Length + 1))
                {
                    wordsRemoved = WordsToRemove;
                }
            }
        } while (wordsRemoved != WordsToRemove);
    }

    public override string ToString()
    {
        return string.Join(" ", _wordList);
    }

    public bool HasWordsRemaining()
    {
        return Array.Exists(_wordList, word => !word.Contains("_"));
    }
}
