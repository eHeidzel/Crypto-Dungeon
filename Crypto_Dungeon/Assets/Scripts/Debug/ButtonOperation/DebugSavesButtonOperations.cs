using Assets.Scripts.Save;
using UnityEngine;

namespace Assets.Scripts.Debug
{
    internal class DebugSavesButtonOperations : MonoBehaviour
    {
        public void SaveWithBalanceSet(float newBalance)
        {
            print(SaveManager.Instance.IP_Address);
            print(SaveManager.Instance.IP_Port);
            SaveManager.Instance.Balance = newBalance;
            SaveManager.Instance.Save();
            print(SaveManager.Instance.IP_Address);
            print(SaveManager.Instance.IP_Port);
        }
    }
}
