using UnityEngine;
using UnityEngine.UI;

public class HomeScreenView : BaseScreenView
{
    [SerializeField] private Button openDailyRewardButton;
    [SerializeField] private Button closeScreenButton;

    public event System.Action OpenDailyRewardClicked;
    public event System.Action CloseClicked;

    private void Awake()
    {
        if (openDailyRewardButton != null)
            openDailyRewardButton.onClick.AddListener(() => OpenDailyRewardClicked?.Invoke());

        if (closeScreenButton != null)
            closeScreenButton.onClick.AddListener(() => CloseClicked?.Invoke());
    }
}