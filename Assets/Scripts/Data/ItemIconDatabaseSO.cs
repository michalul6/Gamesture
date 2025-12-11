using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Item Icon Database")]
public class ItemIconDatabaseSO : ScriptableObject
{
    [Serializable]
    public struct Entry
    {
        public ItemType type;
        public Sprite sprite;
    }

    [SerializeField] private List<Entry> entries = new List<Entry>();

    private Dictionary<ItemType, Sprite> _lookup;

    public Sprite GetIcon(ItemType type)
    {
        EnsureLookup();
        return _lookup.TryGetValue(type, out var sprite) ? sprite : null;
    }

    private void EnsureLookup()
    {
        if (_lookup != null)
            return;

        _lookup = new Dictionary<ItemType, Sprite>();
        foreach (var entry in entries)
        {
            if (entry.sprite == null)
                continue;

            _lookup[entry.type] = entry.sprite;
        }
    }

    private void OnValidate()
    {
        _lookup = null;
    }
}
