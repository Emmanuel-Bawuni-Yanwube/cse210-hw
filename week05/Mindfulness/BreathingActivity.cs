public class BreathingActivity : Activity
{
    public BreathingActivity() 
        : base("Breathing Activity", 
               "This activity will help you relax by guiding you through slow breathing.") { }

    public override void Run()
    {
        StartActivity();
        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("Breathe in... ");
            ShowCountdown(4);
            Console.Write("\nBreathe out... ");
            ShowCountdown(6);
            Console.WriteLine();
        }

        EndActivity();
    }
}
