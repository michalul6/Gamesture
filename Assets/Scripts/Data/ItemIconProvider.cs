using UnityEngine;

public class ItemIconProvider
{
    private readonly ItemIconDatabaseSO _database;

    public ItemIconProvider(ItemIconDatabaseSO database)
    {
        _database = database;
    }

    public Sprite Get(ItemType type)
    {
        return _database != null ? _database.GetIcon(type) : null;
    }
}
