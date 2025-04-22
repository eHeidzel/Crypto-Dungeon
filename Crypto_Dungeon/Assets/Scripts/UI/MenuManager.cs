using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject 
        _gameMenu = null, 
        _baseComputerMenu = null, 
        _shipComputerMenu = null;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.None;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Disable();
    }

    public void Disable()
    {
        if (DisableMenu(_baseComputerMenu))
            return;
        if (DisableMenu(_shipComputerMenu))
            return;
        if (DisableMenu(_gameMenu))
            return;
        else
        {
            _gameMenu.SetActive(true);
            Cursor.visible = true;
        }
    }

    public static bool DisableMenu(GameObject menu)
    {
        if (menu == null)
            return false;

        bool state = (bool)menu?.activeInHierarchy;

        if (state)
        {
            menu.SetActive(false);
            GameObject.Find("Player").GetComponent<Movement>().enabled = true;
			Cursor.visible = false;
		}

		return state;
	}
}
