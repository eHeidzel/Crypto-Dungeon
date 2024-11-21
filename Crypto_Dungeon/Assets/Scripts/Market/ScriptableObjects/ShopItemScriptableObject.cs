using UnityEngine;

[CreateAssetMenu(fileName = "Shop Item", menuName = "SO/Market/ShopItem")]
public class ShopItemScriptableObject : ScriptableObject
{
    public string Name;
    public string Description;
    public float Price;
    public MarketCategory MarketCategory;
    public bool IsBoughtOnce;
    public int BoughtCount;
    public Sprite Sprite;

    public string GetNameInGmFormat() => name + "ShopItem";
}
