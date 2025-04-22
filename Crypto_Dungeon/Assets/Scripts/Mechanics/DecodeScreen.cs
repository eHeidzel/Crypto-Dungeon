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
    private string mask;

    public void SetCipher(Cipher cipher)
    {
        _cipher = cipher;

        _inputKeysReader.SetCheckSequence(_cipher.Message);

        InitText();
        SetHintImage();
        SetHintBtnEvent();
    }

    private void InitText()
    {
        _encodedText.text = TextConverter.TextToUnderlinedFormat(_cipher.EncodedText);
        mask = _cipher.Message;

        _inputKeysReader.SetAfterUpdateEvent(() => UpdateUserInputText());
        UpdateUserInputText();
    }

    private void UpdateUserInputText()
    {
        _userInputText.text = TextConverter.TextToUnderlinedFormat(_inputKeysReader.Text, mask);
    }

    private void SetHintBtnEvent()
    {
        Button btn = _hintBtn.GetComponent<Button>();
        btn.onClick.RemoveAllListeners();
        btn.onClick.AddListener(() => ToggleHintScreen());
    }

    private void SetHintImage()
    {
        string hintImagePath = Paths.GetHintImagePath(_cipher.GetType().ToString());
        byte[] pngBytes = File.ReadAllBytes(hintImagePath);

        Texture2D tex = new Texture2D(2, 2);
        tex.LoadImage(pngBytes);

        Sprite hint = Sprite.Create(
            tex, 
            new Rect(0.0f, 0.0f, tex.width, tex.height), 
            new Vector2(0.5f, 0.5f), 100.0f);

        _hintScreen.GetComponentInChildren<Image>().overrideSprite = hint;
    }

    public void ToggleHintScreen() => _hintScreen.SetActive(!_hintScreen.activeSelf);
}
