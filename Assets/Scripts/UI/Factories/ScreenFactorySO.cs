using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "UI/Screen Factory")]
public class ScreenFactorySO : ScriptableObject
{
    [System.Serializable]
    public struct Entry
    {
        public ScreenId id;
        public BaseScreenView prefab;
    }

    public List<Entry> entries;

    public BaseScreenView Create(ScreenId id, Transform parent)
    {
        var entry = entries.Find(e => e.id == id);
        return Instantiate(entry.prefab, parent);
    }
}