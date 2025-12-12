using System.Collections.Generic;
using UnityEngine;

public class PopupManager
{
    readonly PopupFactorySO _factory;
    readonly PopupPresenterFactory _presenterFactory;
    readonly Transform _root;
    readonly GameContext _context;
    readonly Dictionary<PopupId, BasePopupView> _spawned = new();

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
    }
}
