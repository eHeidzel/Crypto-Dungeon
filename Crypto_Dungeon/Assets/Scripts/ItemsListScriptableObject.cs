using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemsList", menuName = "SO/ItemsList")]
public class ItemsListScriptableObject : ScriptableObject
{
    public List<ItemScriptableObject> Items;
}
