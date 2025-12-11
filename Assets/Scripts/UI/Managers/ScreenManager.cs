using UnityEngine;

public class ScreenManager
{
    private readonly ScreenFactorySO _factory;
    private readonly ScreenPresenterFactory _presenterFactory;
    private readonly Transform _root;
    private readonly GameContext _context;

    private BaseScreenView _current;

    public ScreenManager(
        ScreenFactorySO factory,
        ScreenPresenterFactory presenterFactory,
        Transform root,
        GameContext context)
    {
        _factory = factory;
        _presenterFactory = presenterFactory;
        _root = root;
        _context = context;
    }

    public void Show(ScreenId id)
    {
        _current?.Hide();

        var view = _factory.Create(id, _root);

        var presenter = _presenterFactory.Create(id, view, _context);
        view.SetPresenter(presenter);

        view.Show();

        _current = view;
    }
}