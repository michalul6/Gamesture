public class HomePresenter : IPresenter
{
    readonly HomeScreenView _view;
    readonly PopupManager _popupManager;

    public HomePresenter(GameContext context, HomeScreenView view)
    {
        _view = view;
        _popupManager = context.Resolve<PopupManager>();

        _view.OpenDailyRewardClicked += OnOpenDailyRewardClicked;
        _view.CloseClicked += OnCloseClicked;
    }

    public void OnShow()
    {

    }

    public void OnHide()
    {
        _view.OpenDailyRewardClicked -= OnOpenDailyRewardClicked;
        _view.CloseClicked -= OnCloseClicked;
    }

    void OnOpenDailyRewardClicked()
    {
        _popupManager.Show(PopupId.DailyReward);
    }

    void OnCloseClicked()
    {
        _view.Hide();
    }
}
