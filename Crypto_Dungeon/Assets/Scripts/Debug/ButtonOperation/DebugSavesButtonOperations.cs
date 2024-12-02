using Assets.Scripts.Save;
using UnityEngine;

namespace Assets.Scripts.Debug
{
    internal class DebugSavesButtonOperations : MonoBehaviour
    {
        public void SaveWithBalanceSet(float newBalance)
        {
            print(GameSaves.Instance.IP_Address);
            print(GameSaves.Instance.IP_Port);
            GameSaves.Instance.Balance = newBalance;
            GameSaves.Instance.Save();
            print(GameSaves.Instance.IP_Address);
            print(GameSaves.Instance.IP_Port);
        }
    }
}
