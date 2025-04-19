using UnityEngine;

[RequireComponent(typeof(Camera)), ExecuteInEditMode]
[AddComponentMenu("Effects/Crepuscular Rays", -1)]
public class Crepuscular : MonoBehaviour
{
	public Material material;
	public GameObject light;

	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		material.SetVector("_LightPos", GetComponent<Camera>().WorldToViewportPoint(transform.position - light.transform.forward));
		Graphics.Blit(source, destination, material);
	}
}
