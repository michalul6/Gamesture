using System;

public class DailyRewardService
{
    readonly Player _player;
    readonly DailyRewardsConfig _config;
    readonly IPlayerStorage _storage;
    DateTime? _simulatedDateUtc;

    public DailyRewardService(Player player, DailyRewardsConfig config, IPlayerStorage storage)
    {
        _player = player;
        _config = config;
        _storage = storage;
    }

    public int GetCurrentDayToShow()
    {
        var nextDay = _player.lastClaimedDay + (HasClaimedToday() ? 0 : 1);
        return HasReward(nextDay) ? nextDay : _player.lastClaimedDay;
    }

    public DailyReward GetReward(int day)
    {
        var data = _config.GetRewardData(day);
        return data == null ? null : new DailyReward(data);
    }

    public bool HasReward(int day) => _config.GetRewardData(day) != null;

    public bool TryClaimToday()
    {
        if (HasClaimedToday())
            return false;

        var dayToClaim = _player.lastClaimedDay + 1;
        if (!HasReward(dayToClaim))
            return false;

        Claim(dayToClaim);
        return true;
    }

    private void Claim(int day)
    {
        var reward = GetReward(day);
        if (reward == null) return;

        foreach (var item in reward.Items)
            _player.wallet.Add(item.type, item.amount);

        _player.lastClaimedDay = day;
        _player.lastClaimedDateUtc = GetToday().ToString("O");
        _storage.Save(_player);
    }

    private bool HasClaimedToday()
    {
        if (string.IsNullOrEmpty(_player.lastClaimedDateUtc))
            return false;

        if (!DateTime.TryParse(_player.lastClaimedDateUtc, null, System.Globalization.DateTimeStyles.RoundtripKind, out var lastClaimed))
            return false;

        var today = GetToday();
        // If the stored claim date is today or in the future (e.g., after simulation),
        // treat it as already claimed to prevent re-claiming after restart.
        return lastClaimed.Date >= today;
    }

    public void AdvanceOneDayForSimulation()
    {
        _simulatedDateUtc = GetToday().AddDays(1);
    }

    public DateTime GetTodayDate() => GetToday();

    public DateTime? GetLastClaimedDate()
    {
        if (string.IsNullOrEmpty(_player.lastClaimedDateUtc))
            return null;

        if (!DateTime.TryParse(_player.lastClaimedDateUtc, null, System.Globalization.DateTimeStyles.RoundtripKind, out var lastClaimed))
            return null;

        return lastClaimed.Date;
    }

    private DateTime GetToday()
    {
        return (_simulatedDateUtc ?? DateTime.UtcNow).Date;
    }
}
