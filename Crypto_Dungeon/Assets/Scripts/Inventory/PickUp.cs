using UnityEngine;

public class PickUp : MonoBehaviour
{
    private Inventory inventory;
    private ChooseSlot chooseSlot;
    private Raycast raycast;

    void Start()
    {
        raycast = GetComponent<Raycast>();
        inventory = GetComponent<Inventory>();
        chooseSlot = FindAnyObjectByType<ChooseSlot>();
    }

    public void Update()
    {
        if (raycast.target == null)
            return;

        if (Input.GetKeyUp(KeyCode.E) && raycast.target.CompareTag("Items"))
        {
            Items item = raycast.items;
            if (item == null)
                return;

            AddItem(item);
        }      
    }

    public bool AddItem(Items item, bool needToDelete=true)
    {
        for (int i = 0; i < inventory.slots.Count; i++)
        {
            if (inventory.isFull[i] == false)
            {
                Instantiate(item.slotButton, inventory.slots[i].transform);
                //с глаз подальше
                if (needToDelete)
                    raycast.target.transform.position = new Vector3(10000, 10000);

                inventory.isFull[i] = true;
                inventory.items[i] = item.gameObject;
                inventory.slots[i].holdingItem = item.gameObject;
                chooseSlot.Increaser(i);
                
                raycast.items = null;
                return true;
            }
        }

        return false;
    }

    public void RemoveSelectedItem()
    {
        var selectedSlot = inventory.selectedSlot.GetComponent<Slot>();
        selectedSlot.holdingItem = null;
        inventory.selectedItem = null;
        inventory.isFull[selectedSlot.id] = false;
        Destroy(inventory.selectedSlot.transform.GetChild(0).gameObject);
    }
}
