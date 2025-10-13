using System;

public abstract class Goal
{
    // Shared attributes (encapsulation: protected for derived class access)
    protected string _name;
    protected string _description;
    protected int _points;
    protected bool _isComplete;

    // Constructor
    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
        _isComplete = false;
    }

    // Common methods
    public abstract int RecordEvent();
    public abstract string GetStatus();
    public abstract string GetStringRepresentation();

    // Helper for display
    public string GetName() => _name;
    public bool IsComplete() => _isComplete;
}
