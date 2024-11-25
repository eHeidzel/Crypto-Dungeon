using System.Collections;
using System.IO;
using TMPro;
using UnityEngine;

public class SubtitlesPlayer : MonoBehaviour
{
    private readonly char sep = Path.DirectorySeparatorChar;

    [SerializeField] private string filename;
    [SerializeField] private SubtitilesType type;
    [SerializeField] private TextMeshProUGUI subtitlesText;

    private string fullPath { get => $"{Application.streamingAssetsPath}{sep}Subtitles{sep}{type}{sep}{filename}.txt"; }

    private Subtitle[] subtitles;

    private void Start()
    {
        subtitles = ReadSubtitles(fullPath);
        StartCoroutine(ShowSubtitle());
    }

    private IEnumerator ShowSubtitle(int index = 0)
    {
        Subtitle subtitle = subtitles[index];

        subtitlesText.text = subtitle.Text;
        yield return new WaitForSeconds(subtitle.DurationInMilliseconds / 1000);

        if (++index < subtitles.Length)
            StartCoroutine(ShowSubtitle(index));
    }

    private Subtitle[] ReadSubtitles(string path)
    {
        string[] lines = File.ReadAllLines(path);
        Subtitle[] subtitles = new Subtitle[lines.Length];

        for (int i = 0; i < lines.Length; i++)
            subtitles[i] = new Subtitle(lines[i]);

        return subtitles;
    }

    public enum SubtitilesType
    {
        Tutorial
    }
}
