using System;

public class SimpleGoal : Goal
{
    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    public override int RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
            Console.WriteLine($"Congratulations! You completed '{_name}' and earned {_points} points!");
            return _points;
        }
        else
        {
            Console.WriteLine("This goal is already complete!");
            return 0;
        }
    }

    public override string GetStatus() =>
        $"[{(_isComplete ? "X" : " ")}] {_name} ({_description})";

    public override string GetStringRepresentation() =>
        $"SimpleGoal:{_name}|{_description}|{_points}|{_isComplete}";
}
