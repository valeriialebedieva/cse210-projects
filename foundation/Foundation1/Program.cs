using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Video video1 = new Video("Tech Review", "John Doe", 300);
        Video video2 = new Video("Travel Vlog", "Jane Smith", 450);
        Video video3 = new Video("Cooking Tutorial", "Chef Mike", 600);

        video1.AddComment(new Comment("Alice", "Great review!"));
        video1.AddComment(new Comment("Bob", "Very informative."));
        video1.AddComment(new Comment("Charlie", "I learned a lot!"));

        video2.AddComment(new Comment("Dave", "Amazing places!"));
        video2.AddComment(new Comment("Eve", "I want to visit!"));

        video3.AddComment(new Comment("Frank", "I love this recipe!"));
        video3.AddComment(new Comment("Grace", "Looks delicious!"));
        video3.AddComment(new Comment("Heidi", "I will try this out."));

        List<Video> videoList = new List<Video> { video1, video2, video3 };

        foreach (var video in videoList)
        {
            video.DisplayVideoInfo();
        }
    }
}
