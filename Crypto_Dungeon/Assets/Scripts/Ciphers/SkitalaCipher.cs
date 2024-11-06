using Assets.Scripts.Cyphers;
using System;

public class SkitalaCipher : Cipher
{
    public readonly Alphabet Alphabet;
    public readonly char[] AlphabetChars;
    public readonly int Shift;

    private Random _random = new Random();

    public SkitalaCipher(string message, Alphabet alphabet, int shift) : base(message)
    {
        Shift = shift;
        Alphabet = alphabet;
        AlphabetChars = AlphabetManager.GetAlphabet(alphabet);
    }

    public override string Encode(string message)
    {
        string res = "";

        for (int i = 0; i < message.Length; i++)
        {
            for (int j = 0; j < Shift; j++)
                res += GenerateRandomLetter();
            res += message[i];
        }

        return res;
    }

    public override string Decode(string message)
    {
        string res = "";
        int counter = 0;
        for (int i = 0; i < message.Length; i++)
            if (counter == Shift)
            {
                counter = 0;
                res += message[i];
            }
            else
                counter++;

       return res;
    }

    private char GenerateRandomLetter() => AlphabetChars[_random.Next(0, AlphabetChars.Length)];
}
