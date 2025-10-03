public class GratitudeActivity : Activity
{
    private List<string> _gratitudePrompts = new List<string>
    {
        "Think of someone who recently made your life easier. How did they help you?",
        "Think of a place that brings you peace. What do you appreciate about it?",
        "Think of a small thing today that made you smile.",
        "Think of a challenge you’ve overcome. What strengths did you discover?",
        "Think of a simple pleasure in your life you sometimes take for granted."
    };

    public GratitudeActivity() 
        : base("Gratitude Activity", 
               "This activity helps you reflect on people, places, and moments you are grateful for, encouraging positivity and calmness.") { }

    public override void Run()
    {
        StartActivity();
        Random rand = new Random();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            string prompt = _gratitudePrompts[rand.Next(_gratitudePrompts.Count)];
            Console.WriteLine("\n" + prompt);
            Console.WriteLine("Take a few moments to reflect...");
            ShowSpinner(7); // give them time
        }

        EndActivity();
    }
}
