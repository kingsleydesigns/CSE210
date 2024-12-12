using System;

class Program
{
    static void Main(string[] args)
    {
        // Creating videos
        Video video1 = new Video("Beginner tutorial on C#", "The Tech guy", 600);
        Video video2 = new Video("Master Coding in 5 steps", "James Harden", 900);
        Video video3 = new Video("A complete guide to Object Oriented Programming", "Steve Armin", 480);

        // Adding comments to Video 1
        video1.AddComment(new Comment("Malik", "Great video!"));
        video1.AddComment(new Comment("Churchill", "Very informative."));
        video1.AddComment(new Comment("Anita brownson", "Loved it!"));

        // Adding comments to Video 2
        video2.AddComment(new Comment("Francisco Rossi", "Awesome content!"));
        video2.AddComment(new Comment("Harvey Downs", "Learned a lot."));
        video2.AddComment(new Comment("Michael", "Well done!"));
        video2.AddComment(new Comment("Sammy", "Love your content!"));


        // Adding comments to Video 3
        video3.AddComment(new Comment("Austin", "Incredible Tutorial!"));
        video3.AddComment(new Comment("Estarosa Nadal", "Everything i had been looking for is right here!"));
        video3.AddComment(new Comment("Abdul Rasheed", "Gained a lot of insight!"));

        // Creating a list of videos
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Iterating through the list of videos and displaying the information
        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video._title}");
            Console.WriteLine($"Author: {video._author}");
            Console.WriteLine($"Length: {video._length} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");
            video.DisplayComments();
            Console.WriteLine();
        }
    }
}
    