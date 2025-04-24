using UnityEngine;

public class IgnoreCollisions : MonoBehaviour
{
	[SerializeField] private Collider[] collidersToIgnore;

	private void Start()
	{
		Collider thisCollider = GetComponent<Collider>();

		foreach (var otherCollider in collidersToIgnore)
			Physics.IgnoreCollision(thisCollider, otherCollider, true);
	}
}
