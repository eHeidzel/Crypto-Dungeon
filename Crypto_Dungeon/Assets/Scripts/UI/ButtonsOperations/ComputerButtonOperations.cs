using Assets.Scripts.Save;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ComputerButtonOperations : MonoBehaviour
{
    [SerializeField] GameObject computer;
    [SerializeField] GameObject shop;
    [SerializeField] GameObject menu;
    [SerializeField] GameObject tutorial;

    private void OnEnable()
    {
        Cursor.visible = true;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (shop.activeInHierarchy || tutorial.activeInHierarchy)
                ReturnToMenu();
            else
                Return(); 
        }
    }

    public void ShowMenu()
    {
        shop.SetActive(false);
        tutorial.SetActive(false);
        menu.SetActive(true);
    }

    public void ShowShop()
    {
        tutorial.SetActive(false);
        menu.SetActive(false);
        shop.SetActive(true);
    }

    public void ShowTutorial()
    {
        menu.SetActive(false);
        shop.SetActive(false);
        tutorial.SetActive(true);
    }

    public void LoadTutorial(int index)
    {
        GameSaves.PresentedCipher = (CipherType)index;
        SceneManager.LoadScene("Tutorial");
    }

    public void ReturnToMenu()
    {
        ShowMenu();
    }

    //TODO переписать на поиск компонента конкретно того пользователя, который пользуется компьютером
    //В мультиплеере
    public void Return()
    {
        computer.SetActive(false);
        foreach (var item in FindObjectsByType<Movement>(FindObjectsSortMode.None))
            item.enabled = true;

        Cursor.visible = false;
    }
}
