using UnityEngine;

public static class RewardsJsonLoader
{
    public static DailyRewardsConfig LoadConfig(string resourcesPath)
    {
        TextAsset asset = Resources.Load<TextAsset>(resourcesPath);
        return JsonUtility.FromJson<DailyRewardsConfig>(asset.text);
    }
}