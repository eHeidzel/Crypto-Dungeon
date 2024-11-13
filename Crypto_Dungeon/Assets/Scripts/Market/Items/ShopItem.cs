using Assets.Scripts.Market;
using Assets.Scripts.Market.Items;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopItem : Item, IPointerClickHandler, IPointerEnterHandler
{
    [SerializeField] private ShopItemScriptableObject _characteristics;
    public string Name { get => _characteristics.Name; }
    public string Description { get => _characteristics.Description; }
    public float Price { get => _characteristics.Price; }

    public Action<ShopItem> OnBuy { get; private set; }
    public Action<ShopItem> OnDecline { get; private set; }
    public Action<ShopItem> OnAddToBasket { get; private set; }

    public void IncBoughtCount() => _characteristics.BoughtCount++;

    public void InitValues(ShopItemScriptableObject characteristics)
    {
        _characteristics = characteristics;
        gameObject.name = _characteristics.GetNameInGmFormat();
        GetComponentInChildren<TextMeshProUGUI>().text = _characteristics.Name;
        GetComponent<Image>().overrideSprite = _characteristics.Sprite;
        InitActions(characteristics);
    }

    private void InitActions(ShopItemScriptableObject characteristics)
    {
        if (characteristics.IsBoughtOnce)
        {
            OnAddToBasket += ShopItemsActions.OnBoughtOnceItemAddToBasket;
            OnBuy += ShopItemsActions.OnBoughtOnceItemBuy;
            OnDecline += ShopItemsActions.OnBoughtOnceItemBasketDecline;
        }
        else
        {
            OnAddToBasket += ShopItemsActions.OnBoughtManyItemAddToBasket;
            OnBuy += ShopItemsActions.OnBoughtManyItemBuy;
            OnDecline += ShopItemsActions.OnBoughtManyItemBasketDecline;
        }
    }

    public void OnPointerClick(PointerEventData eventData) => Basket.AddItem(this);

    public void OnPointerEnter(PointerEventData eventData)
    {
        //ShowHint();
    }
}
