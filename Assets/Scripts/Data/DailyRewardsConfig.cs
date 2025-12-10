using System;
using System.Collections.Generic;

[Serializable]
public class DailyRewardsConfig
{
    public List<DailyRewardData> rewards;

    public DailyRewardData GetRewardData(int day)
    {
        return rewards.Find(r => r.day == day);
    }
}