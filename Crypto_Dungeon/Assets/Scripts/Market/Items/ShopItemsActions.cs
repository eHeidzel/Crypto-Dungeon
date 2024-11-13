using Assets.Scripts.Save;

namespace Assets.Scripts.Market.Items
{
    internal class ShopItemsActions
    {
        public static void OnBoughtOnceItemAddToBasket(ShopItem item)
        {
            item.gameObject.SetActive(false);
        }

        public static void OnBoughtManyItemAddToBasket(ShopItem item)
        {
            
        }

        public static void OnBoughtOnceItemBuy(ShopItem item)
        {
            WriteOffFunds(item);
            item.IncBoughtCount();
        }

        public static void OnBoughtManyItemBuy(ShopItem item)
        {
            WriteOffFunds(item);
            item.IncBoughtCount();
        }

        private static void WriteOffFunds(ShopItem item)
        {
            SaveManager.Instance.Balance -= item.Price;
        }

        public static void OnBoughtOnceItemBasketDecline(ShopItem item)
        {
            item.gameObject.SetActive(true);
        }

        public static void OnBoughtManyItemBasketDecline(ShopItem item)
        {

        }
    }
}
