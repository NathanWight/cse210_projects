public class User
{
    private string _userName;
    private List<Goal> _goals;
    private int _totalPoints;

    public User(string name)
    {
        _userName = name;
        _goals = new List<Goal>();
    }

    public void CreateNewGoal()
    {
        try
        {
            // Implement code to create different types of goals based on user input
            // (Already provided in previous examples)
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    public void DisplayGoals()
    {
        try
        {
            int i = 1;
            foreach (Goal goal in _goals)
            {
                Console.Write(i + ". ");
                goal.DisplayGoal(0);
                i++;
            }
            Console.WriteLine();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    public void Save()
    {
        try
        {
            Console.Clear();
            Console.Write("Enter filename: ");
            string filename = Console.ReadLine();

            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                outputFile.WriteLine($"00|{_userName}|{_totalPoints}");
                foreach (Goal goal in _goals)
                {
                    outputFile.WriteLine(goal.GetStringRep());
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    public void Load()
    {
        try
        {
            // Implement code to load goals from a file
            // (Already provided in previous examples)
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    public void RecordEvent()
    {
        try
        {
            // Implement code to record events related to goals
            // (Already provided in previous examples)
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    public int GetTotalPoints()
    {
        try
        {
            return _totalPoints;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            return 0;
        }
    }
}
