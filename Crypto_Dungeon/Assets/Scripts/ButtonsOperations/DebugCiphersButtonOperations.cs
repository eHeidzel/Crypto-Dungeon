using TMPro;
using UnityEngine;

public class DebugCiphersButtonOperations : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _messageTMP;
    [SerializeField] private TextMeshProUGUI _encodedMessageTMP;

    public void EncodeTextWithCaesarRU(int shift)
    {
        Caesars—ipher cipher = new Caesars—ipher(_messageTMP.text, Alphabet.RU, shift);
        _encodedMessageTMP.text = cipher.—ipherText;
    }

    public void EncodeTextWithCaesarEN(int shift)
    {
        Caesars—ipher cipher = new Caesars—ipher(_messageTMP.text, Alphabet.EN, shift);
        _encodedMessageTMP.text = cipher.—ipherText;
    }
}
