public abstract class Goal
{
    protected bool _isCompleted;
    protected string _name;
    protected string _description;
    protected int _points;
    protected int _type;

    public Goal(string name, string description, int points, bool isCompleted)
    {
        try
        {
            _name = name;
            _description = description;
            _points = points;
            _isCompleted = isCompleted;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    public abstract void SetIsCompleted();
    public abstract void DisplayGoal(int option); //user.RecordEvent will use the option to show a list of the goals without the checkbox and description
    public abstract string GetStringRep();

    //GETTERS
    public bool GetIsCompleted()
    {
        try
        {
            return _isCompleted;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            return false;
        }
    }

    public int GetPoints()
    {
        try
        {
            return _points;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            return 0;
        }
    }
}
