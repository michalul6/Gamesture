using System;

public class DailyRewardPopupPresenter : IPresenter
{
    private readonly DailyRewardPopupView _view;
    private readonly DailyRewardService _service;
    private readonly Player _player;
    private readonly ItemIconProvider _itemIcons;

    private int _currentDayToShow;

    public DailyRewardPopupPresenter(GameContext context, DailyRewardPopupView view)
    {
        _view = view;
        _service = context.Resolve<DailyRewardService>();
        _player  = context.Resolve<Player>();
        _itemIcons = context.Resolve<ItemIconProvider>();

        _view.ClaimClicked += OnClaim;
        _view.CloseClicked += OnClose;
        _view.SimulateNextDayClicked += OnSimulateNextDay;

        _currentDayToShow = _service.GetCurrentDayToShow();
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
        var lastClaimedDate = _service.GetLastClaimedDate();
        var today = _service.GetTodayDate();

        _view.RefreshSlots(
            day => _service.GetReward(day),
            type => _itemIcons.Get(type),
            _player.lastClaimedDay,
            _currentDayToShow);

        _view.SetDates(lastClaimedDate, today);
    }

    private void OnClaim()
    {
        if (_service.TryClaimToday())
        {
            _currentDayToShow = _service.GetCurrentDayToShow();
            Refresh();
        }
    }

    private void OnClose()
    {
        _view.Hide();
    }

    private void OnSimulateNextDay()
    {
        _service.AdvanceOneDayForSimulation();
        _currentDayToShow = _service.GetCurrentDayToShow();
        Refresh();
    }
}
