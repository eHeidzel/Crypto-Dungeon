using UnityEngine;

public class Slot : MonoBehaviour
{
    private Inventory inventory;
    public int id;
    public bool isSelected;
    private Vector3 defaultScale;

    private void Start()
    {
        defaultScale = transform.localScale;
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    public void IncreaseSize(float mult)
    {
        transform.parent.localScale *= mult;
    }

    public void SetDefaultSize()
    {
        transform.parent.localScale = defaultScale;
    }


    //public void dropitem()
    //{
    //    inventory.isFull[id] = false;
    //    if (transform.childCount > 0)
    //    {
    //        transform.GetChild(0).GetComponent<spawn>().spawndroppeditem();
    //    }
    //}
}

