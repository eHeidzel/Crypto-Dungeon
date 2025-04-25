using Assets.Scripts;
using Assets.Scripts.Mechanics.Decoders;
using UnityEngine;

public class PlayerInteracts : MonoBehaviour
{
    [SerializeField] private GameObject _baseComputerMenu, _shipComputerMenu;
    private Raycast _raycast;
    private Movement _movement;
    private Inventory _inventory;

    private void Start()
    {
        _movement = GetComponent<Movement>();
        _raycast = GetComponent<Raycast>();
        _inventory = GetComponent<Inventory>();
    }

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.E))
            return;

		PlayerRaycastTarget prt = _raycast.GetPlayerTarget();

        if (prt == null)
            return;

		if (prt.IsShipComputer)
			ActivateShipComputerCanvas();
		if (prt.IsBaseComputer)
			ActivateBaseComputerCanvas();
		if (prt.IsAutoDecodeMachine || prt.IsManualDecodeMachine)
			ProcessDecodeMachine(prt.Target.GetComponentInChildren<Decoder>());
		if (prt.IsDoor)
			ToggleDoor(prt.Target.GetComponent<Animator>());
        if (prt.IsTeleport)
            prt.Target.GetComponent<Teleport>().TeleportDelayed(gameObject);
        if (prt.IsItem)
        {
            if (_inventory.AddItem(prt.Item))
                prt.Target.SetActive(false);
        }     
    }

    public void ToggleDoor(Animator animator)
    {
        bool isOpen = animator.GetBool("IsDoorOpen");
        animator.SetBool("IsDoorOpen", !isOpen);
    }

    public void ProcessDecodeMachine(Decoder decoder)
    {
        var selectedItem = FindAnyObjectByType<Inventory>().SelectedSlot.HoldingItem;
        var paper = selectedItem == null ? null : selectedItem.GetComponentInChildren<Paper>();

        if (decoder == null)
            return;

        if (paper != null && decoder.Paper == null)
        {
            _inventory.ClearSlot();
            decoder.PaperObj = selectedItem.gameObject;
            decoder.Decode(paper);
            return;
        }

        if (decoder?.Paper != null)
        {        
            if (decoder.IsPaperPickable)
                _inventory.AddItem(decoder.GetPaper());
        }
    }

    public void ActivateBaseComputerCanvas()
    {
        _movement.enabled = false;
        _baseComputerMenu.SetActive(true);
    }

	public void ActivateShipComputerCanvas()
	{
		_movement.enabled = false;
		_shipComputerMenu.SetActive(true);
	}
}
