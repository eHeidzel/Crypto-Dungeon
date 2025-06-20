using UnityEngine;

namespace Assets.Scripts.Inventory
{
	internal class ItemRenderer : MonoBehaviour
	{
		[SerializeField] private float minSpeed = 0.5f, maxSpeed = 5f;
		[SerializeField] private float maxDistance = 1;

		public Transform ItemTr { get; private set; }
		private Transform itemTargetTr;

		private MeshCollider collider;
		private MeshFilter filter;
		private MeshRenderer renderer;

		private void Start()
		{
			ItemTr = GameObject.Find("Item").transform;
			itemTargetTr = GameObject.Find("ItemTarget").transform;

			collider = ItemTr.GetComponent<MeshCollider>();
			filter = ItemTr.GetComponent<MeshFilter>();
			renderer = ItemTr.GetComponent<MeshRenderer>();
		}

		private void Update()
		{
			var distance = Vector3.Distance(ItemTr.position, itemTargetTr.position);
			var speed = Mathf.Lerp(minSpeed, maxSpeed, distance / maxDistance);
			var stabilizationTime = Time.deltaTime * speed;

			ItemTr.position = Vector3.Lerp(ItemTr.position, 
				itemTargetTr.position, 
				stabilizationTime);

			ItemTr.rotation = Quaternion.Lerp(ItemTr.rotation, 
				itemTargetTr.rotation, 
				stabilizationTime);
		}

		public void UpdateMesh(Mesh newMesh, Material newMaterial)
		{
			filter.sharedMesh = newMesh;
			collider.sharedMesh = newMesh;

			renderer.sharedMaterial = newMaterial;
		}

		internal void SetInitTransform(Vector3 p, Vector3 r, Vector3 s)
		{
			ItemTr.transform.localScale = s;
			itemTargetTr.localPosition = p;
			itemTargetTr.localRotation = Quaternion.Euler(r);
		}
	}
}
