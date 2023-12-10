

public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity", "This activity helps you relax by guiding you through slow breathing exercises. Focus on your breath.")
    {
    }

    public void RunBreathingActivity()
    {
        RunActivityParentStart();
        SimulateBreathing();
        RunActivityParentEnd();
    }

    private void SimulateBreathing()
    {
        int totalDurationInSeconds = GetUserSessionLengthInput();
        int breatheInDuration = 5;
        int breatheOutDuration = 5;
        int intervalTime = breatheInDuration + breatheOutDuration;

        int intervals = totalDurationInSeconds / intervalTime;

        for (int i = 0; i < intervals; i++)
        {
            Console.WriteLine("Breathe in...");
            CountDownTimer(breatheInDuration);

            Console.WriteLine("Breathe out...");
            CountDownTimer(breatheOutDuration);
        }
    }

    private void CountDownTimer(int duration)
    {
        for (int i = duration; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
        Console.WriteLine();
    }
}
