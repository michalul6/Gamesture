using UnityEngine;
using Newtonsoft.Json;

public static class RewardsJsonLoader
{
    public static DailyRewardsConfig LoadConfig(string resourcesPath)
    {
        TextAsset asset = Resources.Load<TextAsset>(resourcesPath);
        return JsonConvert.DeserializeObject<DailyRewardsConfig>(asset.text);
    }
}