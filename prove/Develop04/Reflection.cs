using System;
using System.Collections.Generic;
using System.Diagnostics;

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
            "--- Think of a time when you stood up for someone else. ---",
            "--- Think of a time when you did something really difficult. ---",
            "--- Think of a time when you helped someone in need. ---",
            "--- Think of a time when you did something truly selfless. ---"
        };

        _questions = new List<string> 
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
