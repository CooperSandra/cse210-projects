using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a list to hold YouTube video titles
        Video video1 = new Video("How To Calculate Your GPA In College", "The Organic Chemistry Tutor",334);
        Video video2 = new Video("Working with Data and APIs in JavaScript", "The Coding Train",115);
        Video video3 = new Video("Pomodoro Timer 4x45 (3hr) | ADHD | Let's get focused! | Lofi + white noise", "ADHA Couple",13802);

        // Comments from YouTube for the video1
        video1.AddComment(new Comment("Hippityhopp","This guy bro...he is my tutor, the best ever. I pray for your good health."));
        video1.AddComment(new Comment("Daisy","This makes TOTAL sense. I wish I had found your video 14 years ago when I was struggling to figure this out."));
        video1.AddComment(new Comment("Cr1mSon","Why am I watching this I'm in 8th grade"));

        // Comments from YouTube for the video2
        video2.AddComment(new Comment("Digigoliath","And you really know how to spread happiness to the world!!! BRAVO!"));
        video2.AddComment(new Comment("Yiyangzhou","have been mindlessly struggling for three days trying to figure out what's the next step after JS. Finally, this is what I need!"));
        video2.AddComment(new Comment("Brojhvick", "I can't wait to see these series! Couldn't come at a more perfect time ❤️❤"));

        // Comments from YouTube for the video3
        video3.AddComment(new Comment("Christian","I don't even know if I have ADHD or autism or if i'm just dumb, but this channel is the only thing that has given me hope for finishing my thesis next week"));
        video3.AddComment(new Comment("Kat2025","not to be dramatic but this is changing my life"));
        video3.AddComment(new Comment("Grabbygrab","I love the 45 minute/10 minute structure! Please use this in more videos!"));


        // Put vidoes in a list and display the video titles and their comments
        List<Video> videos = new List<Video> {video1, video2, video3};

        foreach (Video video in videos)
        {
            video.DisplayVideoComments();
        }
    }
}