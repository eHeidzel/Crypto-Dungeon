using UnityEngine;

public class Teleport : MonoBehaviour
{
	[SerializeField] private Transform teleportTo;

	public void TeleportGm(GameObject gm)
	{
		var playerMovement = FindAnyObjectByType<Movement>();
		playerMovement.enabled = false;

		gm.transform.position = teleportTo.position;
		gm.transform.rotation = teleportTo.rotation;

		playerMovement.enabled = true;
	}
}
