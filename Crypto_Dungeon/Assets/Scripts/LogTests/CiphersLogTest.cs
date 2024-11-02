using UnityEngine;

public class CiphersLogTest : MonoBehaviour
{
    [SerializeField] string messageRU = "ЭТОТЕСТНАРУССКОМ";
    [SerializeField] string messageEN = "THISISTESTINENGLISH";

    [SerializeField] string keyWordRU = "КЛЮЧ";
    [SerializeField] string keyWordEN = "KEY";

    [SerializeField] int shift = 1;

    void Start()
    {
        ReverseTest(messageRU);
        ReverseTest(messageEN);

        CaesarTestRU();
        CaesarTestEN();
    }

    public void Test(Cipher cipher)
    {
        print($"\nИсходный текст: {cipher.Message} " +
        $"Шифротекст: {cipher.CipherText} " +
        $"Дешифрованный шифротекст: {cipher.Decode(cipher.CipherText)}");
    }

    public void CaesarTestRU()
    {
        print("\nШифр Цезаря на русском");
        Test(new CaesarsСipher(messageRU, Alphabet.RU, shift));
    }

    public void CaesarTestEN()
    {
        print("\nШифр Цезаря на английском");
        Test(new CaesarsСipher(messageEN, Alphabet.EN, shift));
    }

    public void CaesarWithKeyRU()
    {
        print("\nШифр Цезаря с ключом на русском");
        //Test(new CaesarsWithKeyСipher(messageRU, Alphabet.RU, keyWordRU));
    }

    public void CaesarWithKeyEN()
    {
        print("\nШифр Цезаря с ключом на английском");
        //Test(new CaesarsWithKeyСipher(messageEN, Alphabet.EN, keyWordEN));
    }

    public void VegeneraRU()
    {
        print("\nШифр Веженера на русском");
        //Test(new VigenereCipher(messageRU, Alphabet.RU, keyWordRU));
    }

    public void VegeneraEN()
    {
        print("\nШифр Веженера на английском");
        //Test(new VigenereCipher(messageEN, Alphabet.EN, keyWordEN));
    }

    public void MagicalSquareRU()
    {
        print("\nШифр магического квадрата на русском");
    }

    public void MagicalSquareEN()
    {
        print("\nШифр магического квадрата на английском");
    }

    public void ReverseTest(string message)
    {
        print("\nШифр разворота текста на обоих языках");
        Test(new ReverseCipher(message));
    }

    public void Skitala(string message)
    {
        print("\nШифр скитала на обоих языках");
        //Test(new SkitalaCipher(message));
    }

    public void Ladder(string message)
    {
        print("\nШифр лесенки на обоих языках");
        //Test(new LadderCipher(message));
    }
}
