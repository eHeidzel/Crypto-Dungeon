using UnityEngine;

public class Slot : MonoBehaviour
{
    public Item HoldingItem { get; private set; }
    [SerializeField] private int id;
	public int Id { get => id; }
	public bool IsFull { get => HoldingItem != null; }

    private Vector3 defaultScale;

    private void Start()
    {
        defaultScale = transform.localScale;
    }

    public void IncreaseSize(float multiplier)
    {
        if (transform.parent.localScale == defaultScale)
            transform.parent.localScale *= multiplier;
    }

    public void SetDefaultSize()
    {
        transform.parent.localScale = defaultScale;
    }

	internal void SetItem(Item item)
	{
		HoldingItem = item;
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

