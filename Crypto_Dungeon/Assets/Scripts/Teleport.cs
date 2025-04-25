using System.Collections;
using UnityEngine;

public class Teleport : MonoBehaviour
{
	[SerializeField] private Transform teleportTo;
	[SerializeField] private float delayInSeconds, delayStep;
	private float currDelay;

	public void TeleportDelayed(GameObject gm)
	{
		StartCoroutine(TeleportDelay());
	}

	private IEnumerator TeleportDelay()
	{
		yield return new WaitForSeconds(0.1f);
	}

	private void TeleportImmidiately(GameObject gm)
	{
		var playerMovement = FindAnyObjectByType<Movement>();
		playerMovement.enabled = false;
		gm.transform.position = teleportTo.position;
		gm.transform.rotation = teleportTo.rotation;

		playerMovement.enabled = true;
	}
}
