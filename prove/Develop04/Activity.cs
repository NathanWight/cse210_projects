using System;
using System.Diagnostics;

public class Activity
{
    private string _startingMessage;
    private string _endingMessage;
    private string _activityDescription;
    private string _activityName;
    private int _spinnerCounter = 0;
    private int _userSessionLengthInput = 0;

    public Activity(string activityName, string activityDescription)
    {
        _activityName = activityName;
        _activityDescription = activityDescription;
    }
 public virtual void DisplayCountdown(int numSecondsToRun)
    {
        for (int i = numSecondsToRun; i >= 1; i--)
        {
            Console.Write($"You may begin in: {i} ");
            Console.SetCursorPosition(0, Console.CursorTop);
            Thread.Sleep(1000);
            Console.Write("\b\b\b\b\b\b\b\b\b\b\b");
        }
        Console.WriteLine("Begin!");
    }
    public void DisplayStartingMessage()
    {
        _startingMessage = $"Welcome to the {_activityName}.";
        Console.WriteLine(_startingMessage + "\n");
    }

    public void DisplayDescription()
    {
        Console.WriteLine(_activityDescription + "\n");
    }

    public void DisplayEndingMessage()
    {
        _endingMessage = $"You have completed {_userSessionLengthInput} seconds of the {_activityName}.";

        Console.WriteLine("\nWell done!");
        DisplaySpinner(3);
        Console.WriteLine(_endingMessage);
        DisplaySpinner(5);
        Console.Clear();
    }

    public void DisplaySpinner(int numSecondsToRun)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        while (stopwatch.ElapsedMilliseconds / 1000 < numSecondsToRun)
        {
            _spinnerCounter++;
            switch (_spinnerCounter % 4)
            {
                case 0: Console.Write("/"); break;
                case 1: Console.Write("-"); break;
                case 2: Console.Write("\\"); break;
                case 3: Console.Write("|"); break;
            }
            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
            Thread.Sleep(200);
        }

        Console.Write(" ");
    }
    

    public int GetUserSessionLengthInput()
    {
        return _userSessionLengthInput;
    }

    public virtual void RunActivityParentStart()
    {
        DisplayStartingMessage();
        DisplayDescription();
        Console.Clear();
    }
    public void RunActivityParentEnd()
    {
        DisplayEndingMessage();
    }

    // Additional methods for getting session length and getting ready
}
