using System.Collections.Generic;
using System;
using Assets.Scripts.Save;
using Assets.Scripts.Cyphers;

public class RandomCipherGenerator
{
    private static Dictionary<Localization, string[]> words = new Dictionary<Localization, string[]>
    {
        {Localization.RU,
            new string[]{
                "���", "���", "������", "���", "������", "����", "������", "����", "���", "����",
                "����", "�����", "����", "�����", "����", "����", "����", "���", "�����", "����",
                "����", "�����", "�����", "����", "������", "����", "������", "�����", "��������", "�����",
                "����", "����", "����", "�����", "������", "����", "����", "�����", "����", "����",
                "������", "���", "���", "������", "�����", "�����", "����", "�����", "���", "����",
                "���", "����", "����", "����", "��������", "����", "������", "������", "������", "������",
                "����", "����", "������", "�����", "����", "�������", "������", "����", "�����", "�����",
                "����", "����", "������", "������", "������", "��������", "�����", "������", "�������", "�������",
                "�������", "�������", "��������", "�������", "�����", "������", "�����", "�������", "����", "����"
            }
        },
        {Localization.EN,
            new string[]{
                "house", "cat", "dog", "world", "sun", "moon", "star", "river", "forest", "mountain",
                "water", "rain", "snow", "wind", "mountain", "bridge", "path", "world", "book", "table",
                "chair", "cat", "bird", "fish", "milk", "bread", "apple", "pear", "orange", "banana",
                "color", "light", "shadow", "sand", "stone", "block", "flag", "city", "village", "path",
                "valley", "oak", "fir", "foliage", "grass", "birds", "light", "fog", "smoke", "snow",
                "world", "strength", "soul", "saved", "holiday", "friend", "love", "truth", "fairy tale", "music",
                "light", "eye", "smile", "song", "ring", "delight", "entertainment", "game", "spring", "autumn",
                "summer", "winter", "first", "second", "third", "fourth", "fifth", "sixth", "seventh", "eighth",
                "ninth", "tenth", "holiday", "event", "new", "old", "life", "happiness", "debt", "path"
            }
        }
    };

    public static Cipher GetRandomCipher()
    {
        int enumLen = Enum.GetValues(typeof(CipherType)).Length;
        CipherType type = (CipherType)UnityEngine.Random.Range(2, 5);
        Localization localization = GameSaves.Instance.Localization;
        Alphabet alphabet = AlphabetManager.GetAlphabetType(localization);
        string message = GetRandomWord();
        string key = GetRandomWord();
        int shift = UnityEngine.Random.Range(1, 4);

        switch (type)
        {
            case CipherType.CaesarWithKeyCipher:
                return new CaesarsWithKey�ipher(message, alphabet, key);
            case CipherType.CaesarCipher:
                return new Caesars�ipher(message, alphabet, shift);
            case CipherType.LadderCipher:
                return new LadderCipher(message);
            case CipherType.ReverseCipher:
                return new ReverseCipher(message);
            case CipherType.SkitalaCipher:
                return new SkitalaCipher(message, alphabet, shift);
            case CipherType.VigenereCipher:
                return new VigenereCipher(message, alphabet, key);
            default:
                throw new ArgumentException();
        }
    }

    private static string GetRandomWord()
    {
        var localizedWords = words[GameSaves.Instance.Localization];
        return localizedWords[UnityEngine.Random.Range(0, localizedWords.Length)];
    }
}
