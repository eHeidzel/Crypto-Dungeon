using TMPro;
using UnityEngine;

public class CiphersLogTest : MonoBehaviour
{
    [SerializeField] string messageRU = "ЭТОТЕСТНАРУССКОМ";
    [SerializeField] string messageEN = "THISISTESTINENGLISH";

    [SerializeField] string keyRU = "КЛЮЧ";
    [SerializeField] string keyEN = "KEY";

    [SerializeField] int shift = 1;
    [SerializeField] TextMeshProUGUI vegenereOutputRU, vegenereOutputEN;

    void Start()
    {
        ReverseTest(messageRU);
        ReverseTest(messageEN);

        CaesarTestRU();
        CaesarTestEN();

        Ladder(messageRU);
        Ladder(messageEN);

        CaesarWithKeyRU();
        CaesarWithKeyEN();

        VegeneraRU();
        VegeneraEN();

        SkitalaRU();
        SkitalaEN();
    }

    public void Test(Cipher cipher)
    {
        print($"\nИсходный текст: {cipher.Message} " +
        $"Шифротекст: {cipher.EncodedText} " +
        $"Дешифрованный шифротекст: {cipher.Decode(cipher.EncodedText)}");
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
        Test(new CaesarsWithKeyСipher(messageRU, Alphabet.RU, keyRU));
    }

    public void CaesarWithKeyEN()
    {
        print("\nШифр Цезаря с ключом на английском");
        Test(new CaesarsWithKeyСipher(messageEN, Alphabet.EN, keyEN));
    }

    public void VegeneraRU()
    {
        print("\nШифр Веженера на русском");
        Test(new VigenereCipher(messageRU, Alphabet.RU, keyRU));
    }

    public void VegeneraEN()
    {
        print("\nШифр Веженера на английском");
        Test(new VigenereCipher(messageEN, Alphabet.EN, keyEN));
    }

    public void ReverseTest(string message)
    {
        print("\nШифр разворота текста на обоих языках");
        Test(new ReverseCipher(message));
    }

    public void SkitalaRU()
    {
        print("\nШифр скитала на русском");
        Test(new SkitalaCipher(messageRU, Alphabet.RU, shift));
    }

    public void SkitalaEN()
    {
        print("\nШифр скитала на английском");
        Test(new SkitalaCipher(messageEN, Alphabet.EN, shift));
    }

    public void Ladder(string message)
    {
        print("\nШифр лесенки на обоих языках");
        Test(new LadderCipher(message));
    }
}
