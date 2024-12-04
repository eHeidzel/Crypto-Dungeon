using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{ 
    public void ExitApp()
    {
        Application.Quit();
    }

    public void StartNeaGame()
    {
        SceneManager.LoadScene("Home");
    }
}
