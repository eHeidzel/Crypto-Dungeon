using System.Collections.Generic;
using Assets.Scripts.Save;
using UnityEngine;

public class InventoryItemsSaver : MonoBehaviour
{
    public static void SaveItems(ItemsListScriptableObject itemsList, List<Item> items)
    {
        List<ItemScriptableObject> converted = ConvertItemsToSOs(itemsList, items);

        GameSaves.Instance.SavedItems = converted;
    }

    private static List<ItemScriptableObject> ConvertItemsToSOs(ItemsListScriptableObject itemsList, List<Item> items)
    {
        List<ItemScriptableObject> converted = new List<ItemScriptableObject>();

        foreach (var item in items)
        {
            ItemScriptableObject itemSo = ConvertItemToSO(itemsList, item);

            if (itemSo != null)
                converted.Add(itemSo);
        }

        return converted;
    }


    private static ItemScriptableObject ConvertItemToSO(ItemsListScriptableObject itemsList, Item item)
    {
        foreach (var soItem in itemsList.Items)
            if (item.gameObject.name.ToLower().Contains(soItem.Prefab.name.ToLower()))
                return soItem;

        return null;
    }
}
