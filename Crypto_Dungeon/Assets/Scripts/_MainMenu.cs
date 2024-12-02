using UnityEngine;
using UnityEngine.SceneManagement;

public class _MainMenu : MonoBehaviour
{ 
    public void ExitApp()
    {
        Application.Quit();
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(1);
    }
}
