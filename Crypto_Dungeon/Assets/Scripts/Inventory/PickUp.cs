using UnityEngine;

public class PickUp : MonoBehaviour
{
    private Inventory inventory;
    private Raycast raycast;

    void Start()
    {
        raycast = GetComponent<Raycast>();
        inventory = GetComponent<Inventory>();
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

            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == false)
                {
                    Instantiate(item.slotButton, inventory.slots[i].transform);
                    Destroy(raycast.target);
                    inventory.isFull[i] = true;
                    break;
                }
            }
        }      
    }
}
