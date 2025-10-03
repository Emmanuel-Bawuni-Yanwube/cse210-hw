public class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "How did you get started?",
        "What made this time different from other times?",
        "What did you learn about yourself through this experience?"
    };

    public ReflectionActivity() 
        : base("Reflection Activity", 
               "This activity will help you reflect on times in your life when you have shown strength and resilience.") { }

    public override void Run()
    {
        StartActivity();
        Random rand = new Random();

        Console.WriteLine("\n" + _prompts[rand.Next(_prompts.Count)]);
        ShowSpinner(5);

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            Console.WriteLine(_questions[rand.Next(_questions.Count)]);
            ShowSpinner(5);
        }

        EndActivity();
    }
}
