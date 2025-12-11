using UnityEngine;

public abstract class BasePopupView : MonoBehaviour, IPopup
{
    protected IPresenter presenter;

    public void SetPresenter(IPresenter p) => presenter = p;

    public virtual void Show()
    {
        gameObject.SetActive(true);
        presenter?.OnShow();
    }

    public virtual void Hide()
    {
        presenter?.OnHide();
        gameObject.SetActive(false);
    }
}