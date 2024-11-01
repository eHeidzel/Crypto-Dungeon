using Assets.Scripts.Cyphers;
using System;

public class CaesarsСipher : Cipher
{
    public int Shift { get; private set; }
    public Alphabet Alphabet { get; private set; }

    public CaesarsСipher(string message, Alphabet alphabet, int shift) : base(message)
    {
        Shift = shift;
        Alphabet = alphabet;
    }

    public override string Encode(string message)
    {
        string encodedMessage = "";
        char[] alphabet = AlphabetManager.GetAlphabet(Alphabet);

        for (int i = 0; i < Message.Length; i++)
        {
            var charIndex = Message[i] - (int)alphabet[0];

            if ((int)Message[i] == 1025)
                charIndex = 6;
            if ((int)Message[i] > 1045)
                charIndex++;

            var pos = (charIndex + Shift);
            pos = pos < 0 ? alphabet.Length + pos : pos;

            encodedMessage += alphabet[pos % alphabet.Length];
        }

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
