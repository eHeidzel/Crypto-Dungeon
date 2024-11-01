using System;
using System.Linq;
using System.Text;
using static UnityEngine.UI.Image;

public class ReverseCypher : Cipher
{
    public ReverseCypher(string message) : base(message) { }

    public override string Decode(string message) => Reverse(message);
    public override string Encode(string message) => Reverse(message);
    public string Reverse(string message) => new string(message.Reverse().ToArray());
}
