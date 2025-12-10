using System;
using System.Text;
using UnityEngine;

[Serializable]
public class Player
{
    public int lastClaimedDay = 0;
    public PlayerWallet wallet = new PlayerWallet();

    public string ToJson() => JsonUtility.ToJson(this, true);
    public byte[] ToBytes() => Encoding.UTF8.GetBytes(ToJson());
    public static Player FromJson(string json) => JsonUtility.FromJson<Player>(json);
}