using UnityEngine;

public class Paper : MonoBehaviour
{
    private Cipher _cipher;

    public Cipher Cipher
    {
        get => _cipher ??= RandomCipherGenerator.GetRandomCipher();
    }

    public bool IsDecoded { get; private set; }

    public void ChangeStateToDecoded() => IsDecoded = true;
}