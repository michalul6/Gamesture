using UnityEngine;

public class PopupManager
{
    readonly PopupFactorySO _factory;
    readonly PopupPresenterFactory _presenterFactory;
    readonly Transform _root;
    readonly GameContext _context;

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