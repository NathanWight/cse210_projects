class Program

{
    static void Main(string[] args)
{
    // Read scriptures from a file
    string[] scriptures = File.ReadAllLines("scriptures.txt");

    if (scriptures.Length == 0)
    {
        Console.WriteLine("No scriptures found in the file.");
        return;
    }

    Random rnd = new Random();
    string randomScripture = scriptures[rnd.Next(scriptures.Length)];

    VerseReference scriptureReference = new VerseReference("Random", "1", "1");
    ScriptureContent scripture = new ScriptureContent(scriptureReference, randomScripture);
    Memorizer memorizer = new Memorizer(scripture.ToString().Split(" "));

    string userInput = "";

    while (userInput.ToLower() != "quit" && userInput.ToLower() != "q" && memorizer.HasWordsRemaining())
    {
        Console.Clear();
        Console.WriteLine($"{scriptureReference} {memorizer}");
        Console.WriteLine();
        Console.WriteLine("Type Quit to end");
        userInput = Console.ReadLine();
        memorizer.RemoveWords();
    }

    // One more time outside of the while loop since the program ends with one word left
    Console.Clear();
    Console.WriteLine($"{scriptureReference} {memorizer}");
    Console.WriteLine();
    Console.WriteLine("Good job!");
}

}