using Assets.Scripts.Save;
using UnityEngine;

public class GameBasics : MonoBehaviour
{
    private void OnApplicationQuit()
    {
        GameSaves.Instance.Save();
    }
}
