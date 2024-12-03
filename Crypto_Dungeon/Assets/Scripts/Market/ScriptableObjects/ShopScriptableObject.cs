using UnityEngine;

[CreateAssetMenu(fileName = "Shop", menuName = "SO/Market/Shop")]
public class ShopScriptableObject : ScriptableObject
{
    public ShopItemScriptableObject[] ItemsToRender;
}
