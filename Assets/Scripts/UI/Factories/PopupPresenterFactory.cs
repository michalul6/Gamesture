using UnityEngine;

public class PopupPresenterFactory
{
    public IPresenter Create(PopupId id, BasePopupView view, GameContext context)
    {
        switch (id)
        {
            case PopupId.DailyReward:
                return new DailyRewardPopupPresenter(context, (DailyRewardPopupView)view);
            
            default:
                Debug.LogError($"No presenter for PopupId: {id}");
                return null;
        }
    }
}
