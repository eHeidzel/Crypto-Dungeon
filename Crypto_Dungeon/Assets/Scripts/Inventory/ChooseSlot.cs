using System;
using System.Collections.Generic;
using UnityEngine;

public class ChooseSlot : MonoBehaviour
{
    [SerializeField] public List<Slot> slots;
    
    private Inventory inventory;
    private readonly Array keyCodes = Enum.GetValues(typeof(KeyCode));
    public float increase;

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
                        Increaser(0);                     
                        break;
                    case KeyCode.Alpha2:                      
                        Increaser(1);                      
                        break;
                    case KeyCode.Alpha3:                      
                        Increaser(2);                     
                        break;
                    case KeyCode.Alpha4:
                        Increaser(3);                                              
                        break;
                    default:
                        return;

                }
        }
    }

    public void Increaser(int id)
    {
        Slot chosenSlot = slots[id];

        foreach (var slot in slots)
        {
            slot.isSelected = false;
            slot.SetDefaultSize();
        }

        chosenSlot.isSelected = true;
        inventory.selectedSlot = chosenSlot.gameObject;
        inventory.selectedItem = chosenSlot.holdingItem;

        chosenSlot.IncreaseSize(increase);
    }
}
