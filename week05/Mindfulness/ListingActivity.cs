public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() 
        : base("Listing Activity", 
               "This activity will help you reflect on the good things in your life by having you list as many things as you can.") { }

    public override void Run()
    {
        StartActivity();
        Random rand = new Random();
        Console.WriteLine("\n" + _prompts[rand.Next(_prompts.Count)]);
        Console.Write("You may begin listing in: ");
        ShowCountdown(5);

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        int count = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            Console.ReadLine();
            count++;
        }

        Console.WriteLine($"\nYou listed {count} items!");
        EndActivity();
    }
}
