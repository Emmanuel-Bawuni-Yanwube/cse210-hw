using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;
    private List<string> _badges = new List<string>();

    public void Start()
    {
        int choice;
        do
        {
            Console.WriteLine("\n=== Eternal Quest ===");
            Console.WriteLine($"Current Score: {_score} | Level: {GetLevel()} ({GetTitle()})");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Show Badges");
            Console.WriteLine("7. Quit");
            Console.Write("Select an option: ");
            choice = int.Parse(Console.ReadLine() ?? "0");

            switch (choice)
            {
                case 1: CreateGoal(); break;
                case 2: ListGoals(); break;
                case 3: RecordEvent(); break;
                case 4: SaveGoals(); break;
                case 5: LoadGoals(); break;
                case 6: ShowBadges(); break;
                case 7: Console.WriteLine("Goodbye! Keep working on your Eternal Quest!"); break;
                default: Console.WriteLine("Invalid choice."); break;
            }
        } while (choice != 7);
    }

    private void CreateGoal()
    {
        Console.WriteLine("\nWhich type of goal would you like to create?");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Select: ");
        int choice = int.Parse(Console.ReadLine() ?? "0");

        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter description: ");
        string description = Console.ReadLine();
        Console.Write("Enter points: ");
        int points = int.Parse(Console.ReadLine() ?? "0");

        switch (choice)
        {
            case 1:
                _goals.Add(new SimpleGoal(name, description, points));
                break;
            case 2:
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case 3:
                Console.Write("Enter target count: ");
                int target = int.Parse(Console.ReadLine() ?? "1");
                Console.Write("Enter bonus points: ");
                int bonus = int.Parse(Console.ReadLine() ?? "0");
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;
            default:
                Console.WriteLine("Invalid selection.");
                break;
        }
    }

    private void ListGoals()
    {
        Console.WriteLine("\nYour Goals:");
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals yet.");
            return;
        }

        int index = 1;
        foreach (Goal goal in _goals)
        {
            Console.WriteLine($"{index}. {goal.GetStatus()}");
            index++;
        }
    }

    private void RecordEvent()
    {
        ListGoals();
        Console.Write("Enter goal number to record: ");
        int index = int.Parse(Console.ReadLine() ?? "0") - 1;

        if (index < 0 || index >= _goals.Count)
        {
            Console.WriteLine("Invalid goal number.");
            return;
        }

        int earned = _goals[index].RecordEvent();
        _score += earned;

        CheckForBadges();
    }

    private void SaveGoals()
    {
        using (StreamWriter writer = new StreamWriter("goals.txt"))
        {
            writer.WriteLine(_score);
            foreach (Goal g in _goals)
            {
                writer.WriteLine(g.GetStringRepresentation());
            }
        }
        Console.WriteLine("Goals saved successfully!");
    }

    private void LoadGoals()
    {
        if (!File.Exists("goals.txt"))
        {
            Console.WriteLine("No saved goals found.");
            return;
        }

        _goals.Clear();
        string[] lines = File.ReadAllLines("goals.txt");
        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(':');
            string type = parts[0];
            string[] data = parts[1].Split('|');

            switch (type)
            {
                case "SimpleGoal":
                    var sg = new SimpleGoal(data[0], data[1], int.Parse(data[2]));
                    sg.GetType().GetField("_isComplete", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                        ?.SetValue(sg, bool.Parse(data[3]));
                    _goals.Add(sg);
                    break;
                case "EternalGoal":
                    _goals.Add(new EternalGoal(data[0], data[1], int.Parse(data[2])));
                    break;
                case "ChecklistGoal":
                    var cg = new ChecklistGoal(data[0], data[1], int.Parse(data[2]), int.Parse(data[3]), int.Parse(data[5]));
                    cg.GetType().GetField("_currentCount", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                        ?.SetValue(cg, int.Parse(data[4]));
                    cg.GetType().GetField("_isComplete", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                        ?.SetValue(cg, bool.Parse(data[6]));
                    _goals.Add(cg);
                    break;
            }
        }
        Console.WriteLine("Goals loaded successfully!");
    }

    private void ShowBadges()
    {
        Console.WriteLine("\nBadges Earned:");
        if (_badges.Count == 0)
            Console.WriteLine("No badges yet. Keep going!");
        else
            foreach (string badge in _badges)
                Console.WriteLine($"🏅 {badge}");
    }

    // 🎮 Gamification

    private int GetLevel() => _score / 1000 + 1;

    private string GetTitle()
    {
        int level = GetLevel();
        return level switch
        {
            <= 2 => "Novice Adventurer",
            <= 4 => "Faithful Knight",
            <= 6 => "Temple Guardian",
            <= 8 => "Ninja Unicorn",
            _ => "Celestial Champion"
        };
    }

    private void CheckForBadges()
    {
        if (_score >= 1000 && !_badges.Contains("Level 1 Achieved"))
            _badges.Add("Level 1 Achieved");
        if (_score >= 5000 && !_badges.Contains("Master Goal Crusher"))
            _badges.Add("Master Goal Crusher");
    }
}
