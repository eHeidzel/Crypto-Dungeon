using UnityEngine;

public class PlayerInteracts : MonoBehaviour
{
    [SerializeField] private GameObject _computerMenu;
    private Raycast _raycast;
    private Movement _movement;

    private void Start()
    {
        _movement = GetComponent<Movement>();
        _raycast = GetComponent<Raycast>();
    }

    private void Update()
    {
        ActivateComputerMenuIfTarget(_raycast);
    }

    public void ActivateComputerMenuIfTarget(Raycast raycast)
    {
        if (Input.GetKeyDown(KeyCode.E))
            if (raycast.isComputerTarget)
            {
                _movement.enabled = false;
                _computerMenu.SetActive(true);
            }
    }
}
