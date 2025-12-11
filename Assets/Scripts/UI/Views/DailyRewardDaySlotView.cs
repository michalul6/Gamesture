using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum DailyRewardSlotState
{
    Locked,
    Available,
    Claimed
}

public class DailyRewardDaySlotView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dayLabel;
    [SerializeField] private Image itemsIcon;
    [SerializeField] private GameObject claimedTick; // optional

    public void SetDay(int day)
    {
        if (dayLabel != null)
            dayLabel.text = $"Day {day}";
    }

    public void SetItemsText(string text)
    {
        // if (itemsIcon != null)
            // itemsIcon.text = text;
    }

    public void SetState(DailyRewardSlotState state)
    {
        if (claimedTick != null)
            claimedTick.SetActive(state == DailyRewardSlotState.Claimed);
    }
}