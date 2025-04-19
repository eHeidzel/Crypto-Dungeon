using Assets;
using System.Collections;
using System.IO;
using TMPro;
using UnityEngine;

public class SubtitlesPlayer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI subtitlesText;

    [Header("Use if not addicted to another script")]
    [SerializeField] private string _filename;
    [SerializeField] private SubtitlesType _type;

    private Subtitle[] subtitles;
    private Coroutine runningSubtitlesCoroutine;

    public void SetConfigPath(string filename, SubtitlesType type)
    {
        _filename = filename;
        _type = type;
    }

    public void ShowSubtitles(int index = 0)
    {
        StopSubtitles();

        subtitles = ReadSubtitles(Paths.GetSubtitlesPath(_filename, _type, index));
        runningSubtitlesCoroutine = StartCoroutine(ShowSubtitle());
    }

    private void StopSubtitles() {
        if (runningSubtitlesCoroutine != null)
            StopCoroutine(runningSubtitlesCoroutine);
    }

    private IEnumerator ShowSubtitle(int index = 0)
    {
        if (subtitles != null)
        {
            Subtitle subtitle = subtitles[index];

            subtitlesText.text = subtitle.Text;
            yield return new WaitForSeconds(subtitle.DurationInMilliseconds / 1000);

            if (++index < subtitles.Length)
                runningSubtitlesCoroutine = StartCoroutine(ShowSubtitle(index));
        }
    }

    private Subtitle[] ReadSubtitles(string path)
    {
        if (!File.Exists(path))
            return null;

        string[] lines = File.ReadAllLines(path);
        Subtitle[] subtitles = new Subtitle[lines.Length];

        for (int i = 0; i < lines.Length; i++)
            subtitles[i] = new Subtitle(lines[i]);

        return subtitles;
    }
}
