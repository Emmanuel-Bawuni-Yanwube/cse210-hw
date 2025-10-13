using System;

public class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonus)
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _bonus = bonus;
        _currentCount = 0;
    }

    public override int RecordEvent()
    {
        if (_isComplete)
        {
            Console.WriteLine("This goal has already been completed!");
            return 0;
        }

        _currentCount++;
        int totalPoints = _points;
        Console.WriteLine($"Progress recorded! {_name}: {_currentCount}/{_targetCount}");

        if (_currentCount >= _targetCount)
        {
            _isComplete = true;
            totalPoints += _bonus;
            Console.WriteLine($"🎉 You completed '{_name}' and earned a {_bonus}-point bonus!");
        }
        else
        {
            Console.WriteLine($"You earned {_points} points!");
        }

        return totalPoints;
    }

    public override string GetStatus() =>
        $"[{(_isComplete ? "X" : " ")}] {_name} ({_description}) - Completed {_currentCount}/{_targetCount} times";

    public override string GetStringRepresentation() =>
        $"ChecklistGoal:{_name}|{_description}|{_points}|{_targetCount}|{_currentCount}|{_bonus}|{_isComplete}";
}
