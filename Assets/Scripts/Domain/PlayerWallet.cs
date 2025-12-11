using System;
using System.Collections.Generic;

[Serializable]
public class PlayerWallet
{
    public List<ItemAmount> items = new List<ItemAmount>();

    public void Add(ItemType type, int amount)
    {
        var entry = items.Find(i => i.type == type);
        if (entry == null)
        {
            entry = new ItemAmount { type = type, amount = 0 };
            items.Add(entry);
        }
        entry.amount += amount;
    }

    public int GetAmount(ItemType type)
    {
        var entry = items.Find(i => i.type == type);
        return entry?.amount ?? 0;
    }
}