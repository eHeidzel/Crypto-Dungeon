using Assets.Scripts;
using TMPro;
using UnityEngine;

public class DecodeScreen : MonoBehaviour
{
    [SerializeField] private Cipher _cipher;
    [SerializeField] private TextMeshProUGUI _encodedText;
    [SerializeField] private TextMeshProUGUI _userInputText;

    [SerializeField] private InputKeysReaderWithChecker _inputKeysReader;

    private void Start()
    {
        _inputKeysReader.SetCheckSeq(_cipher.Message);
        InitText();
        UpdateUserInputText();
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
}
