using Assets.Scripts.Ciphers.Additional;
using Assets.Scripts.Cyphers;

public class VegenereCipher : Cipher
{
    public readonly Alphabet Alphabet;
    public readonly string Key;

    public VegenereCipher(string message, Alphabet alphabet, string key) : base(message)
    {
        Alphabet = alphabet;
        Key = key;
    }

    public override string Encode(string message)
    {
        char[] alphabetChars = AlphabetManager.GetAlphabet(Alphabet);
        string fullKey = Helper.GenerateFullKey(Key, message);
        string res = "";
        int mIndex, kIndex;

        for (int i = 0; i < message.Length; i++)
        {
            mIndex = Helper.GetCharIndexInAlphabet(message[i], alphabetChars[0]);
            kIndex = Helper.GetCharIndexInAlphabet(fullKey[i], alphabetChars[0]);
            res += alphabetChars[(mIndex + kIndex) % alphabetChars.Length];
        }

        return res;
    }

    public override string Decode(string message)
    {
        char[] alphabetChars = AlphabetManager.GetAlphabet(Alphabet);
        string fullKey = Helper.GenerateFullKey(Key, message);
        string res = "";
        int mIndex, kIndex, index;

        for (int i = 0; i < message.Length; i++)
        {
            mIndex = Helper.GetCharIndexInAlphabet(message[i], alphabetChars[0]);
            kIndex = Helper.GetCharIndexInAlphabet(fullKey[i], alphabetChars[0]);
            index = mIndex - kIndex;
            index = index > 0 ? index : index + alphabetChars.Length;

            res += alphabetChars[index % alphabetChars.Length];
        }

        return res;
    }
}
