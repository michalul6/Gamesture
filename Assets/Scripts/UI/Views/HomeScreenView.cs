using UnityEngine;
using UnityEngine.UI;

public class HomeScreenView : BaseScreenView
{
    [SerializeField] Button openDailyRewardButton;
    [SerializeField] Button closeScreenButton;

    public event System.Action OpenDailyRewardClicked;
    public event System.Action CloseClicked;

    void Awake()
    {
        if (openDailyRewardButton != null)
            openDailyRewardButton.onClick.AddListener(() => OpenDailyRewardClicked?.Invoke());

        if (closeScreenButton != null)
            closeScreenButton.onClick.AddListener(() => CloseClicked?.Invoke());
    }
}