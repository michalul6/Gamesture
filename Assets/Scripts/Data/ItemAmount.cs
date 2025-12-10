using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

[Serializable]
public class ItemAmount
{
    [JsonConverter(typeof(StringEnumConverter))]
    public ItemType type;
    public int amount;
}