using UnityEngine;

public abstract class BaseScreenView : MonoBehaviour, IScreen
{
    protected IPresenter presenter;

    public void SetPresenter(IPresenter p) => presenter = p;
    public bool HasPresenter => presenter != null;

    public virtual void Show()
    {
        gameObject.SetActive(true);
        presenter?.OnShow();
    }

    public virtual void Hide()
    {
        presenter?.OnHide();
        presenter = null; // ensure presenter recreated on next show
        gameObject.SetActive(false);
    }
}
