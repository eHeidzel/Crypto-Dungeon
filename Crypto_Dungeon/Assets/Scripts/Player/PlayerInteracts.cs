using UnityEngine;

public class PlayerInteracts : MonoBehaviour
{
    [SerializeField] private GameObject _computerMenu;
    private Raycast _raycast;
    private Movement _movement;

    private void Start()
    {
        _movement = GetComponent<Movement>();
        _raycast = GetComponent<Raycast>();
    }

    private void Update()
    {
        ActivateComputerIfNeed();
        ActivateFullDecodeMachineIfNeed();
        OpenDoorIfNeed();
    }

    public void OpenDoorIfNeed()
    {
        if (!Input.GetKeyDown(KeyCode.E))
            return;
        if (!_raycast.isDoorTarget)
            return;

        var animator = _raycast.target.GetComponent<Animator>();
        bool isOpen = animator.GetBool("IsDoorOpen");
        animator.SetBool("IsDoorOpen", !isOpen);
    }

    public void ActivateFullDecodeMachineIfNeed()
    {
        if (!Input.GetKeyDown(KeyCode.E))
            return;

        if (!_raycast.isFullDecodeMechineTarget)
            return;

        var selectedItem = FindAnyObjectByType<Inventory>().selectedItem;
        var paper = selectedItem == null ? null : selectedItem.GetComponentInChildren<Paper>();
        var decoder = _raycast.target.GetComponentInChildren<AutoDecoder>();
        var pickUp = FindAnyObjectByType<PickUp>();

        if (paper != null)
        {
            if (decoder.IsFree)
            {
                pickUp.RemoveSelectedItem();
                decoder.PaperObj = selectedItem;
                decoder.Decode(paper);
            }
            return;
        }

        if (decoder.Paper != null)
        {
            if (decoder.IsDecoded)
                pickUp.AddItem(decoder.GetAndClearPaper(), false);
        }  
    }

    public void ActivateComputerIfNeed()
    {
        if (Input.GetKeyDown(KeyCode.E))
            if (_raycast.isComputerTarget)
            {
                _movement.enabled = false;
                _computerMenu.SetActive(true);
            }
    }
}
