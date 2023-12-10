using System;
using System.Collections.Generic;

public class ReflectionActivity : Activity
{
    private List<string> _promptsList = new List<string>();
    private List<string> _questionsList = new List<string>()
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity(int duration, string description, string activityName, int initialPauseDuration, int finalPauseDuration, string endingMessage) : base(duration, description, activityName, initialPauseDuration, finalPauseDuration, endingMessage)
    {
        _promptsList.Add("Think of a time when you stood up for someone else.");
        _promptsList.Add("Think of a time when you did something really difficult.");
        _promptsList.Add("Think of a time when you helped someone in need.");
        _promptsList.Add("Think of a time when you did something truly selfless.");
    }

    public void StartReflectionActivity()
    {
        StartActivity(_activityName, _description);
        Console.Clear();
        Console.WriteLine("Get ready to start!");
        Console.WriteLine();
        InitialPause();
        Random random = new Random();
        int randomIndex = random.Next(_promptsList.Count);
        Console.WriteLine(_promptsList[randomIndex]);
        _promptsList.RemoveAt(randomIndex);
        InitialPause();
        Console.WriteLine();
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();
        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
        Countdown(_initialPauseDuration);
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);
        
        while (DateTime.Now < endTime)
        {
            Random randomQuestion = new Random();
            int randomQuestionIndex = randomQuestion.Next(_questionsList.Count);
            Console.WriteLine("> " + _questionsList[randomQuestionIndex]);
            _questionsList.RemoveAt(randomQuestionIndex);
            InitialPause(20);
            Console.WriteLine();
        }

        Console.WriteLine("Well Done!");
        InitialPause();
        DisplayEndingMessage(_activityName);
    }

    public void Countdown(int seconds)
    {
        for (int i = seconds; i >= 1; i--)
        {
            Console.Write(i + "...");
            System.Threading.Thread.Sleep(1000);
        }
        Console.WriteLine();
    }
}
