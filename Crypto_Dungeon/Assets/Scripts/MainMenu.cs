using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{ 
    public void ExitApp()
    {
        Application.Quit();
    }

    public void StartNewGame()
    {
        PlayerPrefs.SetString("SceneToLoad", "Home");
        FindAnyObjectByType<CleverSceneLoader>().LoadScene("LoadingScreen 1");
    }
}
