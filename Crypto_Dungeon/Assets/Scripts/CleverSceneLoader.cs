using Assets.Scripts.Save;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CleverSceneLoader : MonoBehaviour
{
    public void LoadScene(string name)
    {
        GameSaves.Instance.Save();
        SceneManager.LoadScene(name);
    }

    public void LoadScene(int id)
    {
        GameSaves.Instance.Save();
        SceneManager.LoadScene(id);
    }
}
