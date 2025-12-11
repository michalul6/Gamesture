using UnityEngine;

public class ScreenPresenterFactory
{
    public IPresenter Create(ScreenId id, BaseScreenView view, GameContext context)
    {
        switch (id)
        {
            case ScreenId.Home:
                return new HomePresenter(context, (HomeScreenView)view);
            
            default:
                Debug.LogError($"No presenter for ScreenId: {id}");
                return null;
        }
    }
}
