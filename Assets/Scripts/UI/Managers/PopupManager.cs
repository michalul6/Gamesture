using UnityEngine;

public class PopupManager
{
    private readonly PopupFactorySO _factory;
    private readonly PopupPresenterFactory _presenterFactory;
    private readonly Transform _root;
    private readonly GameContext _context;

    public PopupManager(
        PopupFactorySO factory,
        PopupPresenterFactory presenterFactory,
        Transform root,
        GameContext context)
    {
        _factory = factory;
        _presenterFactory = presenterFactory;
        _root = root;
        _context = context;
    }

    public void Show(PopupId id)
    {
        var view = _factory.Create(id, _root) as BasePopupView;

        var presenter = _presenterFactory.Create(id, view, _context);
        view.SetPresenter(presenter);

        view.Show();
    }
}