using Assets.Scripts;
using UnityEngine;

public class Raycast : MonoBehaviour
{
	private Vector3 raycastOriginPosition => GameObject.Find("EyesRaycastOrigin").transform.position;

	public PlayerRaycastTarget GetPlayerTarget()
    {
        Transform mainCameraTr = Camera.main.transform;
        Ray ray = new Ray(raycastOriginPosition, mainCameraTr.forward);
		GameObject target = null;

		Debug.DrawRay(ray.origin, ray.direction * 1.8f, Color.red, 1f);

		if (Physics.Raycast(ray, out RaycastHit hit, 1.8f))
			target = hit.collider.gameObject;

        PlayerRaycastTarget prt = target == null ? null : new PlayerRaycastTarget(target);

		return prt;
	}
}
    
