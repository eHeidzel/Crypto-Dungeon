using Assets.Scripts.Inventory;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<Slot> slots;
	public List<Slot> Slots => slots.ToList();

	[SerializeField] private float increase;

	private ItemRenderer itemRenderer;
	private Slot selectedSlot;
    public Slot SelectedSlot { get => selectedSlot; private set { selectedSlot = value; } }
	public bool HasFreeSlots => slots.Any(slot => slot.HoldingItem == null);

	void Start()
	{
		itemRenderer = FindAnyObjectByType<ItemRenderer>();
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Q))
			DropItem();
	}

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

		RenderItem();
	}

	private void RenderItem()
	{
		var gm = selectedSlot.HoldingItem?.gameObject;

		if (gm == null)
		{
			itemRenderer.UpdateMesh(null, null);
			return;
		}

		var meshFilter = gm.GetComponentInChildren<MeshFilter>();
		if (meshFilter == null || meshFilter.sharedMesh == null)
			return;

		Mesh copiedMesh = Instantiate(meshFilter.sharedMesh);
		var mat = gm.GetComponentInChildren<Renderer>().material;

		itemRenderer.UpdateMesh(copiedMesh, mat);

		Vector3 pos = selectedSlot.HoldingItem.InitP;
		Vector3 rot = selectedSlot.HoldingItem.InitR;
		Vector3 sca = selectedSlot.HoldingItem.InitS;

		itemRenderer.SetInitTransform(pos, rot, sca);
	}

	public void ClearSlot()
    {
		if (selectedSlot == null) return;

		selectedSlot.SetItem(null);
		SelectSlot(selectedSlot.Id);
		Destroy(selectedSlot.transform.GetChild(0).gameObject);
	}

	public void DropItem()
	{
		if (selectedSlot?.HoldingItem == null) return;

		var itemToDropTr = selectedSlot.HoldingItem.transform;
		itemToDropTr.position = itemRenderer.ItemTr.position;
		itemToDropTr.rotation = itemRenderer.ItemTr.rotation;

		var gm = itemToDropTr.gameObject;

		gm.SetActive(true);
		var force = -Camera.main.transform.up;
		gm.GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);

		ClearSlot();
	}
}
