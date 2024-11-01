public abstract class Cipher
{
    public string Message { get; private set; }

    public string ÑipherText { get => Encode(Message); }

    public Cipher(string message)
    {
        Message = message;
    }

    public bool IsAnswerCorrectlyEncoded(string encodedMessage) => Message == encodedMessage;
    public bool IsAnswerCorrectlyDecoded(string decodedMessage) => ÑipherText == decodedMessage;

    public abstract string Encode(string message);
    public abstract string Decode(string message);
}
