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
        SceneManager.LoadScene("LoadingScreen 1");
    }
}
