using UnityEngine;

public class Raycast : MonoBehaviour
{
    [HideInInspector] public GameObject target;
    [HideInInspector] public Items items;

    public void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1.8f))
        {
            target = hit.collider.gameObject;
            items = target.GetComponent<Items>();
        }
    }
}
    
