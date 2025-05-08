using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlanetButtons : MonoBehaviour
{
    [SerializeField] private GameObject computer;

    private void OnEnable()
    {
        Cursor.visible = true;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
                Return();
        }
    }

    public void ChoosePlanet(string name)
    {
        SceneManager.LoadScene(name);
    }


    //TODO ���������� �� ����� ���������� ��������� ���� ������������, ������� ���������� �����������
    public void Return()
    {
        computer.SetActive(false);
        foreach (var item in Transform.FindObjectsByType<Movement>(FindObjectsSortMode.None))
            item.enabled = true;

        Cursor.visible = false;
    }
}
