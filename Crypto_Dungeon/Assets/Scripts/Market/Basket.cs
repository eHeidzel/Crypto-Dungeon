using Assets.Scripts.Market.Items;
using Assets.Scripts.Save;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts.Market
{
    internal class Basket
    {
        public static readonly List<ShopItem> Items = new List<ShopItem>();
        public static Shop Shop { get => Transform.FindAnyObjectByType(typeof(Shop)).GetComponent<Shop>(); }

        public static void AddItem(ShopItem item)
        {
            Items.Add(item);
            item.OnAddToBasket.Invoke(item);
            Shop.UpdateMarket();
        }

        /// <summary>
        /// Returns true if balance enought to buy and false if not
        /// </summary>
        /// <param name="item"></param>
        public static bool RemoveItem(ShopItem item)
        {
            if (item.Price > GameSaves.Instance.Balance)
                return false;

            Items.Remove(item);
            item.OnBuy.Invoke(item);
            Shop.UpdateMarket();
            return true;
        }

        public static void RemoveItemDecline(ShopItem item)
        {
            Items.Remove(item);
            item.OnDecline.Invoke(item);
            Shop.UpdateMarket();
        }

        public static void BuyAll()
        {
            var itemsCopy = Items.ToList();
            var totalPrice = itemsCopy.Sum(item => item.Price);

            if (totalPrice <= GameSaves.Instance.Balance)
                foreach (ShopItem item in itemsCopy)
                    RemoveItem(item);
        }

        public static void DeclineAll()
        {
            foreach (ShopItem item in Items.ToList())
                RemoveItemDecline(item);
        }
    }
}
