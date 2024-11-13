using Assets.Scripts.Market;
using Assets.Scripts.Save;
using System;
using System.Linq;
using TMPro;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _moneyText;
    [SerializeField] private ShopScriptableObject _shopState;

    [SerializeField] private GameObject _weaponsContent;
    [SerializeField] private GameObject _equipmentContent;
    [SerializeField] private GameObject _consumablesContent;
    [SerializeField] private GameObject _basketContent;

    [SerializeField] private GameObject _basketItemPrefab, _shopItemPrefab;

    private void OnEnable()
    {
        UpdateMarket();
    }

    public void UpdateMarket()
    {
        _moneyText.text = SaveManager.Instance.Balance.ToString();
        UpdateItems();
        UpdateBasket();
    }

    private void UpdateItems()
    {
        foreach (var characteristics in _shopState.ItemsToRender)
            if (IsNeedToRender(characteristics))
                RenderItem(characteristics);
    }

    private bool IsNeedToRender(ShopItemScriptableObject characteristics)
    {
        if (characteristics.IsBoughtOnce && characteristics.BoughtCount > 0)
            return false;

        var items = FindObjectsOfType<ShopItem>(true);

        if (items.Where(gm => gm.name == characteristics.GetNameInGmFormat()).Count() > 0)
            return false;

        return true;
    }

    private void RenderItem(ShopItemScriptableObject characteristics)
    {
        var content = GetContentToRenderItem(characteristics.MarketCategory);
        var itemGm = Instantiate(_shopItemPrefab, content);
        itemGm.name = characteristics.name;
        itemGm.GetComponent<ShopItem>().InitValues(characteristics); 
    }

    private Transform GetContentToRenderItem(MarketCategory category)
    {
        switch (category)
        {
            case MarketCategory.Weapons: return _weaponsContent.transform;
            case MarketCategory.Equipment: return _equipmentContent.transform;
            case MarketCategory.Consumables: return _consumablesContent.transform;
            default: throw new ArgumentException();
        }
    }

    private void UpdateBasket()
    {
        for (int i = 0; i < _basketContent.transform.childCount; i++)
            Destroy(_basketContent.transform.GetChild(i).gameObject);

        foreach (var item in Basket.Items)
        {
            var basketItemGm = Instantiate(_basketItemPrefab, _basketContent.transform);
            BasketItem basketItem = basketItemGm.GetComponentInChildren<BasketItem>();
            basketItem.InitValues(item as ShopItem);
        }
    }
}
