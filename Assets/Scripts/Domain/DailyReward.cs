using System.Collections.Generic;

public class DailyReward
{
    public int Day { get; }

    public IReadOnlyList<ItemAmount> Items { get; }

    public DailyReward(DailyRewardData data)
    {
        Day = data.day;
        Items = data.items;
    }
}
