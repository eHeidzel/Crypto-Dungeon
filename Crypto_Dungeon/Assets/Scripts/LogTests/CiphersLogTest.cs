using TMPro;
using UnityEngine;

public class CiphersLogTest : MonoBehaviour
{
    [SerializeField] string messageRU = "����������������";
    [SerializeField] string messageEN = "THISISTESTINENGLISH";

    [SerializeField] string keyRU = "����";
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
        print($"\n�������� �����: {cipher.Message} " +
        $"����������: {cipher.EncodedText} " +
        $"������������� ����������: {cipher.Decode(cipher.EncodedText)}");
    }

    public void CaesarTestRU()
    {
        print("\n���� ������ �� �������");
        Test(new Caesars�ipher(messageRU, Alphabet.RU, shift));
    }

    public void CaesarTestEN()
    {
        print("\n���� ������ �� ����������");
        Test(new Caesars�ipher(messageEN, Alphabet.EN, shift));
    }

    public void CaesarWithKeyRU()
    {
        print("\n���� ������ � ������ �� �������");
        Test(new CaesarsWithKey�ipher(messageRU, Alphabet.RU, keyRU));
    }

    public void CaesarWithKeyEN()
    {
        print("\n���� ������ � ������ �� ����������");
        Test(new CaesarsWithKey�ipher(messageEN, Alphabet.EN, keyEN));
    }

    public void VegeneraRU()
    {
        print("\n���� �������� �� �������");
        Test(new VigenereCipher(messageRU, Alphabet.RU, keyRU));
    }

    public void VegeneraEN()
    {
        print("\n���� �������� �� ����������");
        Test(new VigenereCipher(messageEN, Alphabet.EN, keyEN));
    }

    public void ReverseTest(string message)
    {
        print("\n���� ��������� ������ �� ����� ������");
        Test(new ReverseCipher(message));
    }

    public void SkitalaRU()
    {
        print("\n���� ������� �� �������");
        Test(new SkitalaCipher(messageRU, Alphabet.RU, shift));
    }

    public void SkitalaEN()
    {
        print("\n���� ������� �� ����������");
        Test(new SkitalaCipher(messageEN, Alphabet.EN, shift));
    }

    public void Ladder(string message)
    {
        print("\n���� ������� �� ����� ������");
        Test(new LadderCipher(message));
    }
}
