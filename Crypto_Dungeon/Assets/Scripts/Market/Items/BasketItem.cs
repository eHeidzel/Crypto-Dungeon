using Assets.Scripts.Market.Items;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Market
{
    public class BasketItem : Item
    {
        [SerializeField] private Button _cancelBtn, _buyBtn;

        private ShopItem _orderedItem;

        public void InitValues(ShopItem item)
        {
            _orderedItem = item;

            transform.GetChild(0).GetComponent<Image>().overrideSprite = item.Sprite;
            var tmps = transform.GetComponentsInChildren<TextMeshProUGUI>();
            tmps[0].text = _orderedItem.Name;
            tmps[1].text = _orderedItem.Price.ToString();
            tmps[2].text = _orderedItem.Description;

            _cancelBtn.onClick.AddListener(() => Basket.RemoveItemDecline(_orderedItem));
            _buyBtn.onClick.AddListener(() => Basket.RemoveItem(_orderedItem));
        }
    }
}
