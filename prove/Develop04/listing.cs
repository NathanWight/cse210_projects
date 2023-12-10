

public class ListingActivity : Activity
{
    private List<string> _prompts;

    public ListingActivity() : base("Listing Activity", "Reflect on the good things in your life by listing as many things as you can in a certain area.")
    {
        InitializePrompts();
    }

    private void InitializePrompts()
    {
        _prompts = new List<string>
        {
        "--- Who are people that inspire you and why? ---",
        "--- What are some achievements you're proud of and why? ---",
        "--- Reflect on moments that brought you joy recently. ---",
        "--- List things you are grateful for in your life. ---",
        "--- Think about skills or hobbies you want to learn and why. ---"
    
        };
    }

    public void RunListingActivity()
    {
        RunActivityParentStart();
        DisplayPrompt();
        ListingCounter();
        RunActivityParentEnd();
    }

    private void DisplayPrompt()
    {
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine();
        int randomIndex = new Random().Next(0, _prompts.Count);
        Console.WriteLine(_prompts[randomIndex]);
        Console.WriteLine();
    }

    private void ListingCounter()
    {
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(GetUserSessionLengthInput());
        int count = 0;

        while (DateTime.Now < futureTime)
        {
            Console.Write("> ");
            Console.ReadLine();
            count++;
        }

        Console.WriteLine();
        Console.WriteLine($"You listed {count} items.");
        DisplaySpinner(5);
    }
}
