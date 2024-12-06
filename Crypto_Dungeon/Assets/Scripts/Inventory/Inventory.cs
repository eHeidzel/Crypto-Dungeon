using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] public bool[] isFull;
    [SerializeField] public List<Slot> slots;

    public List<GameObject> items;

    public GameObject selectedSlot;
    public GameObject selectedItem;

    private void Start()
    {
        items = new List<GameObject>(new GameObject[4]);
        slots = FindAnyObjectByType<ChooseSlot>().slots;
    }
}
