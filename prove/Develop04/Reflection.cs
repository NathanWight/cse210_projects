

public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;
    private Random _randomGenerator;

    public ReflectingActivity() : base("Reflection Activity", "Reflect on times in your life when you have shown strength and resilience.")
    {
        InitializePromptsAndQuestions();
        _randomGenerator = new Random();
    }

    private void InitializePromptsAndQuestions()
    {
        _prompts = new List<string>
        {
        "--- Think of a time when you showed resilience in a challenging situation. ---",
        "--- Recall a moment when you accomplished something you once thought was impossible. ---",
        "--- Reflect on a time when you helped someone without expecting anything in return. ---",
        "--- Consider a situation where you faced fear and overcame it. ---",
        "--- Remember a time when you learned a valuable lesson from a mistake. "
        };

        _questions = new List<string> 
        {
           "What strengths did you discover within yourself during that situation?",
        "How did that experience change your perspective on challenges?",
        "What strategies did you use to navigate through that difficult time?",
        "In what ways did that experience shape your future decisions?",
        "What advice would you give to someone facing a similar situation?",
        "How did that experience contribute to your personal growth?",
        "What emotions were predominant during that situation, and how did you manage them?",
        "In what ways did that experience influence your relationships with others?",
        "How can you apply the lessons learned from that situation to other aspects of your life?"
    };
        
    }

    public void RunReflectingActivity()
    {
        RunActivityParentStart();
        DisplayPrompt();
        DisplayQuestions();
        RunActivityParentEnd();
    }
    

    public virtual void DisplayPrompt()
    {
        Console.WriteLine("Consider the following: ");
        Console.WriteLine();

        int randomIndex = _randomGenerator.Next(0, _prompts.Count);
        Console.WriteLine(_prompts[randomIndex]);
        Console.WriteLine();

        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();
    }    

    private void DisplayQuestions()
    {
        Console.Clear();
        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
        Console.WriteLine();
        DisplayCountdown(5);

        int numQuestionsToShow = 4;
        List<int> indexes = GenerateUniqueRandomIndexes(numQuestionsToShow, _questions.Count);

        foreach (int index in indexes)
        {
            Console.Write(_questions[index]);
            DisplaySpinner(GetUserSessionLengthInput() / numQuestionsToShow);
            Console.WriteLine();
        }
    }

    private List<int> GenerateUniqueRandomIndexes(int count, int maxValue)
    {
        List<int> indexes = new List<int>();

        while (indexes.Count < count)
        {
            int randomInt = _randomGenerator.Next(0, maxValue);
            if (!indexes.Contains(randomInt))
            {
                indexes.Add(randomInt);
            }
        }

        return indexes;
    }
}
