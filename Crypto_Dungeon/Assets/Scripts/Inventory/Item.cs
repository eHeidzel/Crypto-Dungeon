using UnityEngine;

public class Item : MonoBehaviour
{
	[SerializeField] public Sprite slotIcon;
	public Sprite SlotIcon => slotIcon;
	[SerializeField] private Vector3 initP, initR, initS;

	public Vector3 InitP => initP;
	public Vector3 InitR => initR;
	public Vector3 InitS => initS;
}
