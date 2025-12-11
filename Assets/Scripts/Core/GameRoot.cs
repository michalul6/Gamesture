using UnityEngine;

public class GameRoot : MonoBehaviour
{
    [Header("UI Factories")]

    [Header("UI Roots")]
    public Transform screenRoot;
    public Transform popupRoot;

    GameContext _context;

    void Awake()
    {
        // 1. Model + Services
        IPlayerStorage storage = new FilePlayerStorage();
        var player = storage.Load();
        var config = RewardsJsonLoader.LoadConfig("Config/daily_rewards");
        var dailyRewardService = new DailyRewardService(player, config, storage);

        // 2. DI container
        _context = new GameContext();
        _context.Register(player);
        _context.Register(dailyRewardService);

        dailyRewardService.Claim(1);

        Debug.LogWarning($"Player wallet after claiming day 1 reward:");
        foreach (var item in player.wallet.items)
        {
            Debug.Log($"- {item.type}: {item.amount}");
        }

    }
}
