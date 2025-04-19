using System;
using UnityEngine;

public class ChooseSlot : MonoBehaviour
{
    private Inventory inventory;
    private readonly Array keyCodes = Enum.GetValues(typeof(KeyCode));

    private void Start()
    {
        inventory = FindAnyObjectByType<Inventory>();
    }

    void Update()
    {
        foreach (KeyCode keyCode in keyCodes)
        {
            if (Input.GetKeyDown(keyCode))
                switch (keyCode)
                {
                    case KeyCode.Alpha1:
                        SelectSlot(0);                     
                        break;
                    case KeyCode.Alpha2:                      
                        SelectSlot(1);                      
                        break;
                    case KeyCode.Alpha3:                      
                        SelectSlot(2);                     
                        break;
                    case KeyCode.Alpha4:
                        SelectSlot(3);                                              
                        break;
                    default:
                        return;
                }
        }
    }

    public void SelectSlot(int id) => inventory.SelectSlot(id);
}
