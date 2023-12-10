using System;
using System.Threading;

public class Activity
{
    protected int _duration;
    protected string _description;
    protected string _activityName;
    protected int _initialPauseDuration;
    protected int _finalPauseDuration;
    private string _endingMessage;

    public Activity(int duration, string description, string activityName, int initialPauseDuration, int finalPauseDuration, string endingMessage)
    {
        _duration = duration;
        _description = description;
        _activityName = activityName;
        _initialPauseDuration = initialPauseDuration;
        _finalPauseDuration = finalPauseDuration;
        _endingMessage = endingMessage;
    }

    public void DisplayStartingMessage(string activityName, string message)
    {
        _description = message;
        _activityName = activityName;
        Console.Clear();
        Console.WriteLine($"Welcome to the {_activityName} Activity.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.WriteLine("How long in seconds would you like your session?");
        _duration = Convert.ToInt32(Console.ReadLine());
    }

    public void DisplayHoldAnimation(int pauseSeconds)
    {
        string[] spinner = { "-", "|", "/" };
        for (int i = 0; i < pauseSeconds; i++)
        {
            Console.Write(spinner[i % spinner.Length]);
            Thread.Sleep(500);
            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
        }
    }

    public void InitialPause(int duration = 10)
    {
        DisplayHoldAnimation(duration);
    }

    public void DisplayEndingMessage(string activityName)
    {
        Console.WriteLine(_endingMessage);
        DisplayHoldAnimation(10);
    }

    public void StartActivity(string activityName, string description)
    {
        Console.Clear();
        InitialPause();
        DisplayStartingMessage(activityName, description);
    }
}
