using UnityEngine;
using Newtonsoft;
using Newtonsoft.Json;

[CreateAssetMenu(fileName = "Item", menuName = "SO/Item")]
public class ItemScriptableObject : ScriptableObject
{
    [JsonIgnore][SerializeField] GameObject prefab;

    [JsonIgnore][HideInInspector] public GameObject Prefab
    {
        get
        {
            if (prefab == null)
                prefab = Resources.Load<GameObject>("Prefabs/Inventory/" + name.ToLower());

            return prefab;
        }
    }
}
