using System;

class Program
{
    static void Main(string[] args)
    {   
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Mindfulness Program");
            Console.WriteLine("Please select one of the following activities: ");
            Console.WriteLine();
            Console.WriteLine("1. Reflection Activity");
            Console.WriteLine("2. Listing Activity");
            Console.WriteLine("3. Breathing Activity");
            Console.WriteLine("4. Quit");
            int selection = int.Parse(Console.ReadLine());

            if (selection == 1){
                ReflectionActivity ReflectionActivity = new ReflectionActivity(10,"This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.", "Reflection", 3,3, "You have completed the Reflection Activity" );
                ReflectionActivity.StartReflectionActivity();
                
            }
            else if (selection == 2){
                ListingActivity ListingActivity = new ListingActivity(10, "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.", "Listing", 3,3, "Great job! You have completed the listing activity.");
                ListingActivity.StartListingActivity();
            }
            else if (selection == 3){
                BreathingActivity breathingActivity = new BreathingActivity(10,"This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.", "Breathing", 3, 3, "Great job! You have completed the breathing activity.", 5, 5);
                breathingActivity.StartBreathingActivity();
            }
            else{
                Console.Clear();
                Console.WriteLine("You should be more mindful and spend more time on this program. I am dissapointed.");
                Activity activity = new Activity(10, "", "", 3,3, "");
                activity.InitialPause();
                break;
            }
        }
        

        



        
        
    }
}

//Program file


public class Activity{

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
public void DisplayStartingMessage(string activityName,string message){
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

public void DisplayHoldAnimation(int pauseSeconds){
    string[] spinner = {"-","|", "/" };
    for (int i = 0; i < pauseSeconds; i++ ){
        Console.Write(spinner[i % spinner.Length]);
        Thread.Sleep(500);
        Console.SetCursorPosition(Console.CursorLeft -1, Console.CursorTop);
    }
}

public void InitialPause(int duration = 10){
    DisplayHoldAnimation(duration);

}

public void DisplayEndingMessage(string _activityName){;
    Console.WriteLine(_endingMessage);
    DisplayHoldAnimation(10);

}

public void StartActivity(string _activityName, string _description){
    Console.Clear();
    InitialPause();
    DisplayStartingMessage(_activityName, _description);
}

public class BreathingActivity : Activity{
    private int _breathInSeconds;
    private int _breatheOutSeconds;

    public BreathingActivity(int _duration, string _description, string _activityName, int _initialPauseDuration, int _finalPauseDuration, string _endingMessage, int breathIn, int breathOut) : base(_duration, _description, _activityName, _initialPauseDuration, _finalPauseDuration, _endingMessage)
    {
        _breatheOutSeconds = breathOut;
        _breathInSeconds = breathIn;
    }

    public void StartBreathingActivity(){
        StartActivity(_activityName, _description);

        int breathCount = _duration / (_breathInSeconds + _breatheOutSeconds);
        Console.Clear();
        Console.WriteLine("Get ready to start!");
        InitialPause();
        for (int i = 0; i < breathCount; i++){
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



}

public class ListingActivity : Activity
{
    private List<string> _promptsList = new List<string>(); 
    public List<string> _responsesList =new List<string>();

    public ListingActivity(int _duration, string _description, string _activityName, int _initialPauseDuration, int _finalPauseDuration, string _endingMessage) : base(_duration, _description, _activityName, _initialPauseDuration, _finalPauseDuration, _endingMessage)
    {   
        
        _promptsList.Add("Who are people that you appreciate?");
        _promptsList.Add("What are personal strengths of yours?");
        _promptsList.Add("Who are people that you have helped this week?");
        _promptsList.Add("When have you felt the Holy Ghost this month?");
        _promptsList.Add("Who are some of your personal heroes?");
        
    
    }
    public void StartListingActivity(){
        StartActivity(_activityName, _description );
        Console.Clear();
        Console.WriteLine("Get ready to start!");
        InitialPause();
        Console.WriteLine("List as many responses you can to the following prompt: ");
        Random random = new Random();
        int randomIndex = random.Next(_promptsList.Count);
        Console.WriteLine(_promptsList[randomIndex]);
        _promptsList.RemoveAt(randomIndex);
        InitialPause();
        Console.WriteLine("You may begin in:");
        Countdown(_initialPauseDuration);
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);
        

        while  (DateTime.Now < endTime){
            Console.Write(">");
            _responsesList.Add(Console.ReadLine());
        }
        int lenghtListedItems = _responsesList.Count;
        Console.WriteLine($"You listed {lenghtListedItems} items!");
        Console.WriteLine();
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


public class ReflectionActivity : Activity{
    private List<string> _promptsList = new List<string>(); 
    public List<string> _questionsList =new List<string>(){
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

    public ReflectionActivity(int _duration, string _description, string _activityName, int _initialPauseDuration, int _finalPauseDuration, string _endingMessage) : base(_duration, _description, _activityName, _initialPauseDuration, _finalPauseDuration, _endingMessage)
    {   
        
        _promptsList.Add("Think of a time when you stood up for someone else.");
        _promptsList.Add("Think of a time when you did something really difficult.");
        _promptsList.Add("Think of a time when you helped someone in need.");
        _promptsList.Add("Think of a time when you did something truly selfless.");
        
    
    }
    public void StartReflectionActivity(){
        StartActivity(_activityName, _description );
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
        while  (DateTime.Now < endTime){
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