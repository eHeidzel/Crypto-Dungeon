using Assets.Scripts.Cyphers;
using System;

public class CaesarsСipher : Cipher
{
    public int Shift { get; private set; }
    public readonly Alphabet Alphabet;
    public readonly char[] AlphabetChars;

    public CaesarsСipher(string message, Alphabet alphabet) : base(message)
    {
        Alphabet = alphabet;
        AlphabetChars = AlphabetManager.GetAlphabet(alphabet);
    }

    public CaesarsСipher(string message, Alphabet alphabet, int shift) : this(message, alphabet)
    {
        Shift = shift;
    }

    protected int GetCharIndexInAlphabet(char ch)
    {
        var charIndex = ch - (int)AlphabetChars[0];

        if ((int)ch == 1025)
            charIndex = 6;
        if ((int)ch > 1045)
            charIndex++;

        return charIndex;
    }

    protected char EncodeSym(char symToEncode, int shift)
    {
        int charIndex = GetCharIndexInAlphabet(symToEncode);

        var pos = charIndex + shift;

        if (pos < 0)
            pos = AlphabetChars.Length - Math.Abs(pos);

        return AlphabetChars[pos % AlphabetChars.Length];
    }

    public override string Encode(string message)
    {
        string encodedMessage = "";

        for (int i = 0; i < message.Length; i++)
            encodedMessage += EncodeSym(message[i], Shift);

        return encodedMessage;
    }

    public override string Decode(string message)
    {
        Shift = -Shift;
        var res = Encode(message);
        Shift = -Shift;
        return res;
    }
}
