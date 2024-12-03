using Assets;
using Assets.Scripts;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DecodeScreen : MonoBehaviour
{
    [SerializeField] private GameObject _hintScreen, _hintBtn;
    [SerializeField] private Cipher _cipher;
    [SerializeField] private TextMeshProUGUI _encodedText;
    [SerializeField] private TextMeshProUGUI _userInputText;

    [SerializeField] private InputKeysReaderWithChecker _inputKeysReader;

    private void Start()
    {
        _inputKeysReader.SetCheckSeq(_cipher.Message);

        InitText();
        UpdateUserInputText();
        SetHintImage();
        SetHintBtnEvent();
    }

    private void InitText()
    {
        _encodedText.text = TextConverter.TextToUnderlinedFormat(_cipher.EncodedText);

        _inputKeysReader.SetAfterUpdateEvent(() => UpdateUserInputText());
    }

    private void UpdateUserInputText()
    {
        _userInputText.text = TextConverter.TextToUnderlinedFormat(_inputKeysReader.Text, _encodedText.text);
    }

    private void SetHintBtnEvent()
    {
        _hintBtn.GetComponent<Button>().onClick.AddListener(() => ToggleHintScreen());
    }

    private void SetHintImage()
    {
        string hintImagePath = Paths.GetHintImagePath(_cipher.GetType().ToString());
        byte[] pngBytes = File.ReadAllBytes(hintImagePath);

        Texture2D tex = new Texture2D(2, 2);
        tex.LoadImage(pngBytes);

        Sprite hint = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);

        _hintScreen.GetComponentInChildren<Image>().overrideSprite = hint;
    }

    public void ToggleHintScreen() => _hintScreen.SetActive(!_hintScreen.activeSelf);
}
