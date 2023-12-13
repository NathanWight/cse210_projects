public class EternalGoal : Goal
{
    private int _timesAccomplished;

    public EternalGoal(string name, string description, int timesAccomplished, int points) : base(name, description, points, false)
    {
        _type = 2;
        _timesAccomplished = timesAccomplished;
    }

    public override void SetIsCompleted()
    {
        try
        {
            _timesAccomplished += 1;
            _isCompleted = false;
            Console.WriteLine($"Congratulations! You earned {_points} points");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    public override void DisplayGoal(int option)
    {
        try
        {
            if (option == 0)
            {
                Console.WriteLine($"    {_name} ({_description}) -- Times accomplished: {_timesAccomplished}");
            }
            else
            {
                Console.WriteLine($"{_name}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    public override string GetStringRep()
    {
        try
        {
            return $"{_type}|{_name}|{_description}|{_timesAccomplished}|{_points}";
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            return string.Empty;
        }
    }
}
