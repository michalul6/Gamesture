using System;
using System.Text;
using Newtonsoft.Json;
using UnityEngine;

[Serializable]
public class Player
{
    public int lastClaimedDay = 0;
    public string lastClaimedDateUtc; // ISO string of last claim date (UTC)
    public PlayerWallet wallet = new PlayerWallet();

    public string ToJson() => JsonConvert.SerializeObject(this, Formatting.Indented);
    public byte[] ToBytes() => Encoding.UTF8.GetBytes(ToJson());
    public static Player FromJson(string json) => JsonConvert.DeserializeObject<Player>(json);
}
