using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create videos
        Video video1 = new Video("C# Basics Tutorial", "Alice Johnson", 600);
        Video video2 = new Video("Top 10 Programming Languages", "TechWorld", 900);
        Video video3 = new Video("Funny Cat Compilation", "PetLovers", 300);

        // Add comments to video 1
        video1.AddComment(new Comment("Bob", "This was super helpful, thanks!"));
        video1.AddComment(new Comment("Clara", "I finally understand classes now."));
        video1.AddComment(new Comment("David", "Great pace and clear explanation."));

        // Add comments to video 2
        video2.AddComment(new Comment("Ella", "I agree with most, but I’d rank Python first."));
        video2.AddComment(new Comment("Frank", "Thanks, this was interesting!"));
        video2.AddComment(new Comment("Grace", "Could you make a follow-up on frameworks?"));

        // Add comments to video 3
        video3.AddComment(new Comment("Henry", "I can’t stop laughing!"));
        video3.AddComment(new Comment("Isla", "The one at 1:23 is my favorite."));
        video3.AddComment(new Comment("Jack", "Cats are the best stress relief."));

        // Store videos in a list
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Display video details and comments
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthSeconds} seconds");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");
            Console.WriteLine("Comments:");
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($" - {comment.Name}: {comment.Text}");
            }
            Console.WriteLine(new string('-', 50));
        }
    }
}
