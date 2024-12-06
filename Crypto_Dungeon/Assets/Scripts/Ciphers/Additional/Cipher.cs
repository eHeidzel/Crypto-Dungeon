using UnityEngine;

public abstract class Cipher : MonoBehaviour
{
    public string Message;

    public string EncodedText { get => Encode(Message); }

    public Cipher(string message)
    {
        Message = message.ToUpper();
    }

    public abstract string Encode(string message);
    public abstract string Decode(string message);
}
