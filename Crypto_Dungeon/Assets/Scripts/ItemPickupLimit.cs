using System.Collections.Generic;
using System.Linq;
using Assets.Scripts;
using Assets.Scripts.Save;
using UnityEngine;

public class ItemPickupLimit : MonoBehaviour
{
    [SerializeField] public int LimitCount;
    [SerializeField] public string ItemName;
    private ItemPickupLimitModel savedState;

    private void Start()
    {
        LoadState();

        if (LimitCount <= 0)
            gameObject.SetActive(false);
    }

    private void LoadState()
    {
        List<ItemPickupLimitModel> limits = GameSaves.Instance.ItemsPickupLimits.ToList();
        savedState = limits?.Where(x => x.Name == ItemName).FirstOrDefault();

        if (savedState != null)
            LimitCount = savedState.Limit;
    }

    public void UpdateState()
    {
        LimitCount -= 1;
        
        if (savedState != null)
            GameSaves.Instance.RemovePickupItem(savedState);

        var a = GameSaves.Instance.ItemsPickupLimits;
        GameSaves.Instance.AddPickupItem(this);
        this.enabled = false;
    }
}
