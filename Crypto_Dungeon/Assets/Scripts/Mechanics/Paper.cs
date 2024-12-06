using UnityEngine;

public class Paper : MonoBehaviour
{ 
    public Cipher Cipher { get; private set; }
    public bool IsDecoded { get; private set; }

    private void Start()
    {
        Cipher = RandomCipherGenerator.GetRandomCipher();
    }

    public void ChangeStateToDecoded() => IsDecoded = true;
}
