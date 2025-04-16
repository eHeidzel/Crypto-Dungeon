using System;
using TMPro;

public class Title
{
    public string Text { get; }
    public float DurationInMilliseconds { get; }
    public FontType FontAssetType { get; }
    public int Width { get; }
    public int Height { get; }

    /// <summary>
    /// Must be in "Text(string) font(enum) width(int) height(int)" format
    /// </summary>
    public Title(string creditString)
    {
        string[] data = creditString.Split(' ');
        Text = data[0];
        FontAssetType = (FontType)Enum.Parse(typeof(FontType), data[1]);
        Width = int.Parse(data[2]);
        Height = int.Parse(data[3]);
    }
}
