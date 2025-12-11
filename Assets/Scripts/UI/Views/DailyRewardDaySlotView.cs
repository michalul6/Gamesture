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
    [SerializeField] TextMeshProUGUI dayLabel;
    [SerializeField] TextMeshProUGUI amount;
    [SerializeField] Image itemsIcon;
    [SerializeField] GameObject claimedTick;

    public void SetDay(int day)
    {
        if (dayLabel != null)
            dayLabel.text = $"Day {day}";
    }

    public void SetAmount(int value)
    {
        if (amount != null)
            amount.text = "x" + value.ToString();
    }

    public void SetItemIcon(Sprite icon)
    {
        if (itemsIcon != null)
            itemsIcon.sprite = icon;
    }

    public void SetState(DailyRewardSlotState state)
    {
        if (claimedTick != null)
            claimedTick.SetActive(state == DailyRewardSlotState.Claimed);
        if (amount != null)
            amount.gameObject.SetActive(state != DailyRewardSlotState.Claimed);
    }
}