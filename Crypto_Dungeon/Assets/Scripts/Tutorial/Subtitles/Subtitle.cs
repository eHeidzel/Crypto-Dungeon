﻿public class Subtitle
{
    public string Text { get; }
    public float DurationInMilliseconds { get; }

    /// <summary>
    /// Must be in "Text(string) DurationInMilliseconds(int)" format
    /// </summary>
    public Subtitle(string subtitileString)
    {
        string[] data = subtitileString.Split(' ');
        Text = data[0];
        DurationInMilliseconds = int.Parse(data[1]);
    }
}