using System;
using System.Collections.Generic;


/// Creativity:
/// - Preserves punctuation when hiding words (e.g., "uncleanness," → "__________,").
/// - Supports a library of scriptures (at least 3). Each time the program runs,
///   a random scripture is chosen for memorization practice.
/// 
/// Author: Emmanuel Bawuni Yanwube

class Program
{
    static void Main(string[] args)
    {
        // Create scripture library
        List<Scripture> library = new List<Scripture>();

        // Galatians 5:19
        library.Add(new Scripture(
            new Reference("Galatians", 5, 19),
            "Now the works of the flesh are manifest, which are these; Adultery, fornication, uncleanness, lasciviousness,"
        ));

        // Proverbs 3:5-6
        library.Add(new Scripture(
            new Reference("Proverbs", 3, 5, 6),
            "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."
        ));

        // John 3:16
        library.Add(new Scripture(
            new Reference("John", 3, 16),
            "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."
        ));

        // Pick one scripture at random
        Random rand = new Random();
        Scripture scripture = library[rand.Next(library.Count)];

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

            // Hide 3 words each time
            scripture.HideRandomWords(3);

            // End if everything is hidden
            if (scripture.IsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("\nAll words hidden — great job memorizing!");
                break;
            }
        }
    }
}

