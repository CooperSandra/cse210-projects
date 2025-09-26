using System;

public class Comment
{
    public string ViewerName { get; set; }
    public string Text { get; set; }

    public Comment(string viewerName, string text)
    {
        ViewerName = viewerName;
        Text = text;
    }

    public Comment(string v)
    {
    }
}