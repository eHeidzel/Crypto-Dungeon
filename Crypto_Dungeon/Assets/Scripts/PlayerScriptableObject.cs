using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(fileName = "Player", menuName = "SO/Player")]
    public class PlayerScriptableObject : ScriptableObject
    {
        public string Nickname;
        public int Hp;
    }
}
