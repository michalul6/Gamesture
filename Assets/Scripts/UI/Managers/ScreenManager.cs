using System.Collections.Generic;
using UnityEngine;

public class ScreenManager
{
    readonly ScreenFactorySO _factory;
    readonly ScreenPresenterFactory _presenterFactory;
    readonly Transform _root;
    readonly GameContext _context;

    BaseScreenView _current;
    readonly Dictionary<ScreenId, BaseScreenView> _spawned = new();

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

        if (!_spawned.TryGetValue(id, out var view) || view == null)
        {
            view = _factory.Create(id, _root);
            _spawned[id] = view;
        }

        if (!view.HasPresenter)
        {
            var presenter = _presenterFactory.Create(id, view, _context);
            view.SetPresenter(presenter);
        }

        view.Show();

        _current = view;
    }
}
