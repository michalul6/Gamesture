public class DailyRewardService
{
    readonly Player _player;
    readonly DailyRewardsConfig _config;
    readonly IPlayerStorage _storage;

    public DailyRewardService(Player player, DailyRewardsConfig config, IPlayerStorage storage)
    {
        _player = player;
        _config = config;
        _storage = storage;
    }

    public int GetCurrentDay() => _player.lastClaimedDay + 1;

    public DailyReward GetReward(int day)
    {
        var data = _config.GetRewardData(day);
        return data == null ? null : new DailyReward(data);
    }

    public bool HasReward(int day) => _config.GetRewardData(day) != null;

    public void Claim(int day)
    {
        var reward = GetReward(day);
        if (reward == null) return;

        foreach (var item in reward.Items)
            _player.wallet.Add(item.type, item.amount);

        _player.lastClaimedDay = day;
        _storage.Save(_player);
    }
}
