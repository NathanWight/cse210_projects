using System;

public class GoalList : Goal
{
    private int _requiredCompletionCount;
    private int _completedCount;

    public GoalList(string name, string description, int points, int requiredCompletionCount, int completedCount, bool isCompleted) : base(name, description, points, isCompleted)
    {
        _requiredCompletionCount = requiredCompletionCount;
        _completedCount = completedCount;
    }

    public override void SetIsCompleted()
    {
        if (_completedCount >= _requiredCompletionCount)
        {
            _isCompleted = true;
            _points += (_completedCount / _requiredCompletionCount) * 10; // Custom logic for assigning points
            Console.WriteLine($"Congratulations! {_name} goal achieved. You've earned {_points} points.");
        }
        else
        {
            Console.WriteLine($"Work harder to achieve the {_name} goal!");
        }
    }

    public override void DisplayGoal(int option)
    {
        Console.WriteLine($"Goal: {_name}");
        Console.WriteLine($"Description: {_description}");
        Console.WriteLine($"Completion Progress: {_completedCount}/{_requiredCompletionCount}");
        Console.WriteLine($"Points: {_points}");
        Console.WriteLine($"Is Completed: {_isCompleted}");
    }

    public override string GetStringRep()
    {
        return $"Goal: {_name} | Description: {_description} | Points: {_points} | Required: {_requiredCompletionCount} | Completed: {_completedCount} | Is Completed: {_isCompleted}";
    }
}
