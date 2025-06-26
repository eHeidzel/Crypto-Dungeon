using Assets;
using Assets.Scripts.Save;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Slider : MonoBehaviour
{
    [SerializeField] private Image _slideImage;
    [SerializeField] private SubtitlesPlayer subtitlesPlayer;
    [SerializeField] private string _sceneToLoadAfterPresentation;
    
    private CipherType _cipherForPresentation;
    private Sprite[] _slides;
    private int _slideIndex;
    private int slideIndex
    {
        get => _slideIndex;
        set
        {
            if (value < 0)
                _slideIndex = 0;
            else if (value > _maxIndex)
                _slideIndex = _maxIndex;
            else
                _slideIndex = value;
        }
    }

    private int _maxIndex { get => _slides.Length - 1; }

    private void Start()
    {
        _cipherForPresentation = GameSaves.PresentedCipher;
        _slides = ReadSlides(_cipherForPresentation.ToString());
        subtitlesPlayer.SetConfigPath(_cipherForPresentation.ToString(), SubtitlesType.Tutorial);
        ShowSprite();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (slideIndex == _maxIndex)
                FindAnyObjectByType<CleverSceneLoader>().LoadScene(_sceneToLoadAfterPresentation);
            else
            {
                slideIndex++;
                ShowSprite(slideIndex);
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && slideIndex != 0)
        {
            slideIndex--;
            ShowSprite(slideIndex);
        }
    }

    private void ShowSprite(int index=0)
    {
        _slideImage.overrideSprite = _slides[index];
        subtitlesPlayer?.ShowSubtitles(index);
    }

    private Sprite[] ReadSlides(string presentationName)
    {
        string dirPath = Paths.GetSpritesDirPath(presentationName);
        string[] imgsPaths = Directory.GetFiles(dirPath, "*.png");
        imgsPaths = imgsPaths.OrderBy(x => int.Parse(Path.GetFileName(x).Split('.')[0])).ToArray();
        Sprite[] slides = new Sprite[imgsPaths.Length];

        for (int i = 0; i < imgsPaths.Length; i++)
        {
            Texture2D tex = new Texture2D(2, 2);
            byte[] pngBytes = File.ReadAllBytes(imgsPaths[i]);
            tex.LoadImage(pngBytes);

            Sprite slide = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
            slides[i] = slide;
        }

        return slides;
    }
}
