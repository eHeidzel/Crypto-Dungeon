using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<Slot> slots;
	public List<Slot> Slots => slots.ToList();

	[SerializeField] private float increase;

	private Slot selectedSlot;
    public Slot SelectedSlot { get => selectedSlot; private set { selectedSlot = value; } }

	public bool AddItem(Item item)
	{
		foreach (var slot in slots)
		{
			if (slot.IsFull)
				continue;

			GameObject gm = new GameObject(item.name);
			gm.transform.SetParent(slot.transform, false);
			var image = (Image)gm.AddComponent(typeof(Image));
			image.overrideSprite = item.slotIcon;

			slot.SetItem(item);
			SelectSlot(slot.Id); //убрать если не хочется, чтобы предмет автоматически выбирался

			return true;
		}

		return false;
	}

	public void SelectSlot(int id)
	{
		SelectedSlot = slots[id];

		foreach (var slot in slots)
			slot.SetDefaultSize();

		SelectedSlot.IncreaseSize(increase);
	}

	public void ClearSlot()
    {
		SelectedSlot.SetItem(null);
		Destroy(SelectedSlot.transform.GetChild(0).gameObject);
	}
}
