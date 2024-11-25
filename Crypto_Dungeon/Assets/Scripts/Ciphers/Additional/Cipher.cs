public abstract class Cipher
{
    public string Message { get; private set; }

    public string CipherText { get => Encode(Message); }

    public Cipher(string message)
    {
        Message = message;
    }

    public bool IsAnswerCorrectlyEncoded(string encodedMessage) => CipherText == encodedMessage;
    public bool IsAnswerCorrectlyDecoded(string decodedMessage) => Message == decodedMessage;

    public abstract string Encode(string message);
    public abstract string Decode(string message);
}
