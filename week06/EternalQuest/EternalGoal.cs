using System;

public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    public override int RecordEvent()
    {
        Console.WriteLine($"Great job! You recorded progress for '{_name}' and earned {_points} points!");
        return _points;
    }

    public override string GetStatus() =>
        $"[∞] {_name} ({_description})";

    public override string GetStringRepresentation() =>
        $"EternalGoal:{_name}|{_description}|{_points}|{_isComplete}";
}
