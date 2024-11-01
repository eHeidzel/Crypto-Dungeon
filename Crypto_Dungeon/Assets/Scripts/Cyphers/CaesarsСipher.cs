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
        //foreach (var item in alphabet)
        //{
        //    var res = item + 0;
        //}

        for (int i = 0; i < Message.Length; i++)
        {
            var charIndex = Message[i] - (int)alphabet[0];

            if ((int)Message[i] == 1025)
                charIndex = 6;
            if ((int)Message[i] > 1045)
                charIndex++;

            encodedMessage += alphabet[(charIndex + Shift) % alphabet.Length];
        }

        return encodedMessage;
    }

    public override string Decode(string message)
    {
        throw new System.NotImplementedException();
    }
}
