using Assets;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TitlesPlayer : MonoBehaviour
{
    private Title[] _titles;
    [SerializeField] private GameObject _textPrefab;

    [Header("ScrollSettings")]
    [SerializeField] private Scrollbar _scrollbar;
    [SerializeField] private float _scrollDelayInMilliseconds;
    [SerializeField] private float _scrollTimes;
    private float _scrollValue;

    [Header("ChapterFontAsset")]
    [SerializeField] private TMP_FontAsset ChapterFont;
    [Header("AuthorAsset")]      
    [SerializeField] private TMP_FontAsset AuthorFont;

    [SerializeField]
    private Dictionary<FontType, TMP_FontAsset> fonts = new Dictionary<FontType, TMP_FontAsset>();

    private void Start()
    {
        _scrollValue = 1  / _scrollTimes;
        fonts[FontType.Chapter] = ChapterFont;
        fonts[FontType.Author] = AuthorFont;
        _titles = ReadTitles(Paths.GetTitlesPath());
        InstantiateTitles(_titles);
        StartCoroutine(ShowCredits());
    }

    private Title[] ReadTitles(string path)
    {
        string[] lines = File.ReadAllLines(path);
        Title[] titles = new Title[lines.Length];

        for (int i = 0; i < lines.Length; i++)
            titles[i] = new Title(lines[i]);

        return titles;

    }

    private void InstantiateTitles(Title[] titles)
    {
        foreach (var title in titles)
        {
            var gm = Instantiate(_textPrefab, transform);
            gm.name = title.FontAssetType + "TitleText";
            gm.GetComponent<RectTransform>().sizeDelta = new Vector2(title.Width, title.Height);
            var tmp = gm.GetComponent<TextMeshProUGUI>();
            tmp.text = title.Text;
            tmp.font = fonts[title.FontAssetType];
        }
    }

    private IEnumerator ShowCredits(int index = 0)
    {
        yield return new WaitForSeconds(_scrollDelayInMilliseconds / 1000);
        _scrollbar.value -= _scrollValue;

        if (_scrollbar.value > 0)
            StartCoroutine(ShowCredits(index));
    }
}
