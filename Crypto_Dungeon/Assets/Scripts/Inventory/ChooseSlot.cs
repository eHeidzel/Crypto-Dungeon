using System;
using Unity.VisualScripting;
using UnityEngine;

public class ChooseSlot : MonoBehaviour
{
    private Inventory inventory;
    //private Slot slot;
    [SerializeField] public Slot[] slots;
    private readonly Array keyCodes = Enum.GetValues(typeof(KeyCode));
    public float increase;
    private KeyCode inputedKey;

    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        //slot = GetComponent<Slot>();
    }


    void Update()
    {
        foreach (KeyCode keyCode in keyCodes)
        {
            inputedKey = keyCode;
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

        if (chosenSlot.isSelected)
            return;

        foreach (var slot in slots)
        {
            slot.isSelected = false;
            slot.SetDefaultSize();
        }

        chosenSlot.isSelected = true;
        chosenSlot.IncreaseSize(increase);
    }
}
