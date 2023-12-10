using System;

public class BreathingActivity : Activity
{
    private int _breathInSeconds;
    private int _breatheOutSeconds;

    public BreathingActivity(int duration, string description, string activityName, int initialPauseDuration, int finalPauseDuration, string endingMessage, int breathIn, int breathOut) : base(duration, description, activityName, initialPauseDuration, finalPauseDuration, endingMessage)
    {
        _breatheOutSeconds = breathOut;
        _breathInSeconds = breathIn;
    }

    public void StartBreathingActivity()
    {
        StartActivity(_activityName, _description);

        int breathCount = _duration / (_breathInSeconds + _breatheOutSeconds);
        Console.Clear();
        Console.WriteLine("Get ready to start!");
        InitialPause();
        for (int i = 0; i < breathCount; i++)
        {
            Console.WriteLine("Breath in...");
            Countdown(_breathInSeconds);
            Console.WriteLine("Breath out...");
            Countdown(_breatheOutSeconds);
        }
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
