using UnityEngine;

public static class RewardsJsonLoader
{
    public static RewardsConfig LoadConfig(string resourcesPath)
    {
        TextAsset asset = Resources.Load<TextAsset>(resourcesPath);
        return JsonUtility.FromJson<RewardsConfig>(asset.text);
    }
}