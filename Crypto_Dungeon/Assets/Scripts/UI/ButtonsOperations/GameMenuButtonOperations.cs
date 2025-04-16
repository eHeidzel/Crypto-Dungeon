using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuButtonOperations : MonoBehaviour
{
    [SerializeField] private GameObject _gameMenu;
    [SerializeField] private GameObject _computerMenu;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.None;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            ToggleMainMenuIfNeed();
    }

    public void ToggleMainMenuIfNeed()
    {
        bool isNeedToActivate = !_gameMenu.activeSelf;

        if (_computerMenu == null || !_computerMenu.activeInHierarchy)
            _gameMenu.SetActive(isNeedToActivate);

        Cursor.visible = isNeedToActivate;
    }

    public void ChangeSceneToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ContinueGame()
    {
        _gameMenu.SetActive(false);
        Cursor.visible = false;
    }
}
