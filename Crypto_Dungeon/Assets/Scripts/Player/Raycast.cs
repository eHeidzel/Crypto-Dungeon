using UnityEngine;

public class Raycast : MonoBehaviour
{
    [HideInInspector] public GameObject target;
    [HideInInspector] public Items items;
    [HideInInspector] public bool isComputerTarget;
    [HideInInspector] public bool isDoorTarget;
    [HideInInspector] public bool isAutoDecodeMechineTarget;
    [HideInInspector] public bool isMiniGameDecodeMechineTarget;

    Vector3 cameraCenterVector = new Vector3(Screen.width / 2, Screen.height / 2, 0);

    public void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(cameraCenterVector);

        if (Physics.Raycast(ray, out RaycastHit hit, 1.8f))
        {
            target = hit.collider.gameObject;
            items = target.GetComponent<Items>();

            isDoorTarget = target.tag == "Door";
            isAutoDecodeMechineTarget = target.tag == "FullDecodeMechineTarget";
            isMiniGameDecodeMechineTarget = target.tag == "MiniGameDecodeMechineTarget";
            isComputerTarget = target.tag == "Computer";
        }
    }
}
    
