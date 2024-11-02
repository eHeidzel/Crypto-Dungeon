using System;
using System.Linq;

public class ReverseCipher : Cipher
{
    public ReverseCipher(string message) : base(message) { }

    public override string Decode(string message) => Reverse(message);
    public override string Encode(string message) => Reverse(message);
    public string Reverse(string message) => new string(message.Reverse().ToArray());
}
