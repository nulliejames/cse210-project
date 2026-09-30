using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>
        {
            new Video("Building a Tiny House", "Maya Builds", 742),
            new Video("Why the Moon Changes Shape", "Curious Corner", 518),
            new Video("A Week of Easy Vegetarian Meals", "Nora Cooks", 963),
            new Video("Learning Guitar: First Chords", "Sound Steps", 681)
        };

        videos[0].AddComment(new Comment("Jordan Lee", "The storage ideas are brilliant."));
        videos[0].AddComment(new Comment("Avery Kim", "I would love to see the finished interior."));
        videos[0].AddComment(new Comment("Morgan Reed", "That window placement makes the room feel huge."));

        videos[1].AddComment(new Comment("Sam Patel", "The diagram made this so easy to understand."));
        videos[1].AddComment(new Comment("Taylor Brooks", "I never knew the shadow caused the phases."));
        videos[1].AddComment(new Comment("Casey Nguyen", "Please make one about eclipses next."));

        videos[2].AddComment(new Comment("Riley Chen", "The lentil bowls look delicious."));
        videos[2].AddComment(new Comment("Jamie Flores", "I tried the pasta and my family loved it."));
        videos[2].AddComment(new Comment("Alex Morgan", "Great ideas for meal prep."));

        videos[3].AddComment(new Comment("Drew Wilson", "This was a very approachable lesson."));
        videos[3].AddComment(new Comment("Quinn Davis", "The slow chord changes helped a lot."));
        videos[3].AddComment(new Comment("Robin Shah", "More beginner guitar videos, please!"));

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLengthInSeconds()} seconds");
            Console.WriteLine($"Comments ({video.GetCommentCount()}):");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.GetCommenterName()}: {comment.GetText()}");
            }

            Console.WriteLine();
        }
    }
}