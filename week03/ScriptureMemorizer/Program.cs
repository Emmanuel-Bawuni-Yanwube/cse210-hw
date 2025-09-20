using System;

class Program
{
    static void Main(string[] args)
    {
        // Create the reference for Galatians 5:19
        Reference reference = new Reference("Galatians", 5, 19);

        // Verse text
        string text = "Now the works of the flesh are manifest, which are these; Adultery, fornication, uncleanness, lasciviousness,";

        // Create the scripture object
        Scripture scripture = new Scripture(reference, text);

        // Display loop
        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.Write("Press Enter to hide words, or type 'quit' to exit: ");

            string input = Console.ReadLine();
            if (input?.ToLower() == "quit")
                break;

            // Hide a few random words
            scripture.HideRandomWords(3);

            // End if everything is hidden
            if (scripture.IsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("\nAll words hidden — good job memorizing!");
                break;
            }
        }
    }
}
