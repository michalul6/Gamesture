public class HomePresenter : IPresenter
{
    private readonly HomeScreenView _view;
    private readonly PopupManager _popupManager;

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
    }

    private void OnOpenDailyRewardClicked()
    {
        _popupManager.Show(PopupId.DailyReward);
    }

    private void OnCloseClicked()
    {
        _view.Hide();
    }
}