using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] public bool[] isFull;
    [SerializeField] public GameObject[] slots;
    private Slot slot;


    private void Start()
    {
        slot = GetComponent<Slot>();
    }


    public void Update()
    {
        
    }
}
