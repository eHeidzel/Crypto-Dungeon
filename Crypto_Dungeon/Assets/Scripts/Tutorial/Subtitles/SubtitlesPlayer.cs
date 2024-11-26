using Assets;
using System.Collections;
using System.IO;
using TMPro;
using UnityEngine;

public class SubtitlesPlayer : MonoBehaviour
{
    [SerializeField] private string filename;
    [SerializeField] private SubtitilesType type;
    [SerializeField] private TextMeshProUGUI subtitlesText;
    
    private Subtitle[] subtitles;

    private void Start()
    {
        subtitles = ReadSubtitles(Paths.GetSubtitlesPath(filename, type));
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
}
