using UnityEngine;

public class CiphersLogTest : MonoBehaviour
{
    [SerializeField] string messageRU = "����������������";
    [SerializeField] string messageEN = "THISISTESTINENGLISH";

    [SerializeField] string keyWordRU = "����";
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
        print($"\n�������� �����: {cipher.Message} " +
        $"����������: {cipher.CipherText} " +
        $"������������� ����������: {cipher.Decode(cipher.CipherText)}");
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
        //Test(new CaesarsWithKey�ipher(messageRU, Alphabet.RU, keyWordRU));
    }

    public void CaesarWithKeyEN()
    {
        print("\n���� ������ � ������ �� ����������");
        //Test(new CaesarsWithKey�ipher(messageEN, Alphabet.EN, keyWordEN));
    }

    public void VegeneraRU()
    {
        print("\n���� �������� �� �������");
        //Test(new VigenereCipher(messageRU, Alphabet.RU, keyWordRU));
    }

    public void VegeneraEN()
    {
        print("\n���� �������� �� ����������");
        //Test(new VigenereCipher(messageEN, Alphabet.EN, keyWordEN));
    }

    public void MagicalSquareRU()
    {
        print("\n���� ����������� �������� �� �������");
    }

    public void MagicalSquareEN()
    {
        print("\n���� ����������� �������� �� ����������");
    }

    public void ReverseTest(string message)
    {
        print("\n���� ��������� ������ �� ����� ������");
        Test(new ReverseCipher(message));
    }

    public void Skitala(string message)
    {
        print("\n���� ������� �� ����� ������");
        //Test(new SkitalaCipher(message));
    }

    public void Ladder(string message)
    {
        print("\n���� ������� �� ����� ������");
        //Test(new LadderCipher(message));
    }
}
