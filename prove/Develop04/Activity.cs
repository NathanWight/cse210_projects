using System.Diagnostics;

public class Activity
{
    private int  _sessionLength = 0, _spinner = 0;
    
    private string _message, _endingMessage,  _activityDescription, _activityName;
    
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
        _message = $"Welcome to the {_activityName}.";
        Console.WriteLine(_message + "\n");
    }

    public void DisplayDescription()
    {
        Console.WriteLine(_activityDescription + "\n");
    }

    public void DisplayEndingMessage()
    {
        _endingMessage = $"You have completed {_sessionLength} seconds of the {_activityName}.";

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
            _spinner++;
            switch (_spinner % 4)
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
        return _sessionLength;
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

    // Additional methods for getting sessi
}
