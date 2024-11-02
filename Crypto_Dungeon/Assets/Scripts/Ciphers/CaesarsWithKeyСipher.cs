using System.Security.Cryptography;
using UnityEditor.VersionControl;

public class CaesarsWithKeyСipher : CaesarsСipher
{
    public readonly string Key;

    public CaesarsWithKeyСipher(string message, Alphabet alphabet, string key) : base(message, alphabet) 
    { 
        Key = key;
    }

    public override string Encode(string message)
    {
        string res = "";
        string fullKey = GenerateFullKey(message);

        for (int i = 0; i < message.Length; i++)
            res += EncodeSym(message[i], GetCharIndexInAlphabet(fullKey[i]));

        return res;
    }

    public override string Decode(string message)
    {
        string res = "";
        string fullKey = GenerateFullKey(message);

        for (int i = 0; i < message.Length; i++)
            res += EncodeSym(message[i], -GetCharIndexInAlphabet(fullKey[i]));

        return res;
    }

    private string GenerateFullKey(string message)
    {
        string fullKey = "";

        for (int i = 0; i < message.Length; i++)
            fullKey += Key[i % Key.Length];

        return fullKey;
    }
}
