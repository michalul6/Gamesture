public class DailyRewardPopupPresenter : IPresenter
{
    private readonly DailyRewardPopupView _view;
    private readonly DailyRewardService _service;
    private readonly Player _player;

    private int _currentDayToShow;

    public DailyRewardPopupPresenter(GameContext context, DailyRewardPopupView view)
    {
        _view = view;
        _service = context.Resolve<DailyRewardService>();
        _player  = context.Resolve<Player>();

        _view.ClaimClicked += OnClaim;
        _view.CloseClicked += OnClose;
        _view.SimulateNextDayClicked += OnSimulateNextDay;

        _currentDayToShow = _service.GetCurrentDay();
    }

    public void OnShow()
    {
        Refresh();
    }

    public void OnHide()
    {
    }

    private void Refresh()
    {
        _view.RefreshSlots(
            day => _service.GetReward(day),
            _player.lastClaimedDay,
            _currentDayToShow);
    }

    private void OnClaim()
    {
        _service.Claim(_currentDayToShow);
        _currentDayToShow = _service.GetCurrentDay();
        Refresh();
    }

    private void OnClose()
    {
        _view.Hide();
    }

    private void OnSimulateNextDay()
    {
        if (_service.HasReward(_currentDayToShow + 1))
        {
            _currentDayToShow++;
            Refresh();
        }
    }
}