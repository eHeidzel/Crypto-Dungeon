using Assets.Scripts.Mechanics.Decoders;
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
        if (!Input.GetKeyDown(KeyCode.E))
            return;

        ActivateComputerIfNeed();
        ProcessDecodeMachine();
        OpenDoorIfNeed();
    }

    public void OpenDoorIfNeed()
    {
        if (!_raycast.isDoorTarget)
            return;

        var animator = _raycast.target.GetComponent<Animator>();
        bool isOpen = animator.GetBool("IsDoorOpen");
        animator.SetBool("IsDoorOpen", !isOpen);
    }

    public void ProcessDecodeMachine()
    {
        if (!(_raycast.isAutoDecodeMechineTarget || _raycast.isMiniGameDecodeMechineTarget))
            return;

        var selectedItem = FindAnyObjectByType<Inventory>().selectedItem;
        var paper = selectedItem == null ? null : selectedItem.GetComponentInChildren<Paper>();
        Decoder decoder = _raycast.target.GetComponentInChildren<Decoder>();

        var pickUp = FindAnyObjectByType<PickUp>();

        if (decoder == null)
            return;

        if (paper != null)
        {
            if (decoder is AutoDecoder autoDecoder)
            {
                if (autoDecoder.IsFree)
                {
                    pickUp.RemoveSelectedItem();
                    autoDecoder.PaperObj = selectedItem;
                    autoDecoder.Decode(paper);
                    return;
                }
            }   
            else if (decoder is MiniGameDecoder miniGameDecoder)
            {
                if (miniGameDecoder.IsFree)
                {
                    pickUp.RemoveSelectedItem();
                    miniGameDecoder.PaperObj = selectedItem;
                    miniGameDecoder.Decode(paper);
                    return;
                }
            }
        }

        if (decoder?.Paper != null)
        {
            if (decoder is AutoDecoder autoDecoder)
            {
                if (autoDecoder.IsDecodingDone)
                    pickUp.AddItem(autoDecoder.GetAndClearPaper(), false);
            }
            else if (decoder is MiniGameDecoder miniGameDecoder)
            {
                if (miniGameDecoder.IsPaperPickable)
                    pickUp.AddItem(miniGameDecoder.GetAndClearPaper(), false);
            }
        }
    }

    public void ActivateComputerIfNeed()
    {
        if (_raycast.isComputerTarget)
        {
            _movement.enabled = false;
            _computerMenu.SetActive(true);
        }
    }
}
