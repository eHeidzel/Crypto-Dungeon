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
        SceneManager.LoadScene("Home");
    }
}
