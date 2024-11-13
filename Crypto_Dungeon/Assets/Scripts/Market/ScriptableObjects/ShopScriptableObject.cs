using UnityEngine;

[CreateAssetMenu(fileName = "Shop", menuName = "SO/Shop")]
public class ShopScriptableObject : ScriptableObject
{
    public ShopItemScriptableObject[] ItemsToRender;
}
