using Assets.Scripts.Ciphers.Additional;

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
        string fullKey = Helper.GenerateFullKey(Key, message);

        for (int i = 0; i < message.Length; i++)
            res += EncodeSym(message[i], Helper.GetCharIndexInAlphabet(fullKey[i], AlphabetChars[0]));

        return res;
    }

    public override string Decode(string message)
    {
        string res = "";
        string fullKey = Helper.GenerateFullKey(Key, message);

        for (int i = 0; i < message.Length; i++)
            res += EncodeSym(message[i], -Helper.GetCharIndexInAlphabet(fullKey[i], AlphabetChars[0]));

        return res;
    }
}
