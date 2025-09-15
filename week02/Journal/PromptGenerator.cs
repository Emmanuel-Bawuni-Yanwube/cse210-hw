using System;
using System.Collections.Generic;

public class PromptGenerator
{
    private List<string> _prompts = new List<string>
    {
        "What is something I accomplished today that I’m proud of?",
        "What challenge did I face today, and how did I handle it?",
        "What is one small moment today that brought me joy?",
        "What is something I learned about myself today?",
        "If I could send a message to my future self, what would it say?",
        "What’s one thing I wish I had done differently today?",
        "Who or what inspired me today?",
        "What am I most grateful for today?",
        "What was a moment of peace or calm I experienced today?",
        "What is one step I can take tomorrow to make it better than today?"
    };

    private Random _rand = new Random();

    public string GetRandomPrompt()
    {
        int index = _rand.Next(_prompts.Count);
        return _prompts[index];
    }
}
