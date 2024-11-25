using System;

public class TimeConverter
{
    public static string SecondsToLongTimeFormat(int seconds)
    {
        TimeSpan t = TimeSpan.FromSeconds(seconds);

        string answer = string.Format("{0:D2}:{1:D2}:{2:D2}",
                        t.Hours,
                        t.Minutes,
                        t.Seconds);

        return answer;
    }
}
