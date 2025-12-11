using UnityEngine;

public class GameRoot : MonoBehaviour
{
    [Header("Factories")]
    public ScreenFactorySO screenFactory;
    public PopupFactorySO popupFactory;

    [Header("Databases")]
    public ItemIconDatabaseSO itemIconDatabase;

    [Header("UI Roots")]
    public Transform screenRoot;
    public Transform popupRoot;

    GameContext _context;

    void Awake()
    {
        // Domain
        IPlayerStorage storage = new FilePlayerStorage();
        var player = storage.Load();
        var config = RewardsJsonLoader.LoadConfig("Config/daily_rewards");
        var dailyRewardService = new DailyRewardService(player, config, storage);
        var itemIconProvider = new ItemIconProvider(itemIconDatabase);

        // DI
        _context = new GameContext();
        _context.Register(storage);
        _context.Register(player);
        _context.Register(dailyRewardService);
        _context.Register(itemIconProvider);

        var screenPresenterFactory = new ScreenPresenterFactory();
        var popupPresenterFactory = new PopupPresenterFactory();

        var screenManager = new ScreenManager(
            screenFactory,
            screenPresenterFactory,
            screenRoot,
            _context);

        var popupManager = new PopupManager(
            popupFactory,
            popupPresenterFactory,
            popupRoot,
            _context);

        _context.Register(screenManager);
        _context.Register(popupManager);

        // Start UI
        screenManager.Show(ScreenId.Home);
    }
}