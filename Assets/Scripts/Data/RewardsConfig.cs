using System;
using System.Collections.Generic;

[Serializable]
public class RewardsConfig
{
    public List<RewardData> rewards;

    public RewardData GetRewardData(int day)
    {
        return rewards.Find(r => r.day == day);
    }
}