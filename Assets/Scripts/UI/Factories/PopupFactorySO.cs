using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "UI/Popup Factory")]
public class PopupFactorySO : ScriptableObject
{
    [System.Serializable]
    public struct Entry
    {
        public PopupId id;
        public BasePopupView prefab;
    }

    public List<Entry> entries;

    public BasePopupView Create(PopupId id, Transform parent)
    {
        var entry = entries.Find(e => e.id == id);
        return Instantiate(entry.prefab, parent);
    }
}