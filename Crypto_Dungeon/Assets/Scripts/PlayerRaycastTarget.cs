using UnityEngine;

namespace Assets.Scripts
{
	public class PlayerRaycastTarget
	{
		private GameObject target;
		public GameObject Target => target;

		private string tag;

		public Item Item { get; private set; }
		public bool IsDoor => tag == "Door";
		public bool IsAutoDecodeMachine => tag == "AutoDecodeMachine";
		public bool IsManualDecodeMachine => tag == "ManualDecodeMachine";
		public bool IsComputer => tag == "Computer";
		public bool IsItem { get => Item != null; }

		public PlayerRaycastTarget(GameObject target)
		{
			this.target = target;
			tag = target.tag;
			Item = target.GetComponent<Item>();
		}
	}
}
