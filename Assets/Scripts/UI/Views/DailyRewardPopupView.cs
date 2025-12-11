using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DailyRewardPopupView : BasePopupView
{
    [Header("Buttons")]
    [SerializeField] private Button claimButton;
    [SerializeField] private Button closeButton;
    [SerializeField] private Button simulateNextDayButton;

    [Header("Slots")]
    [SerializeField] private DailyRewardDaySlotView[] daySlots; // size 7 in inspector

    [Header("Dates")]
    [SerializeField] private TextMeshProUGUI lastClaimedDate;
    [SerializeField] private TextMeshProUGUI todayDate;

    public event Action ClaimClicked;
    public event Action CloseClicked;
    public event Action SimulateNextDayClicked;

    private void Awake()
    {
        if (claimButton != null)
            claimButton.onClick.AddListener(() => ClaimClicked?.Invoke());

        if (closeButton != null)
            closeButton.onClick.AddListener(() => CloseClicked?.Invoke());

        if (simulateNextDayButton != null)
            simulateNextDayButton.onClick.AddListener(() => SimulateNextDayClicked?.Invoke());
    }

    public void RefreshSlots(
        Func<int, DailyReward> getRewardForDay,
        Func<ItemType, Sprite> getIcon,
        int lastClaimedDay,
        int currentDayToShow)
    {
        if (daySlots == null) return;

        for (int i = 0; i < daySlots.Length; i++)
        {
            int day = i + 1;
            var slot = daySlots[i];
            if (slot == null) continue;

            slot.SetDay(day);

            var reward = getRewardForDay(day);

            var itemIndex = 0;//for simplicity lets assume we always show first item if multiple

            if (reward != null)
            {
                if (getIcon != null && reward.Items.Count > 0)
                {
                    var icon = getIcon(reward.Items[itemIndex].type);
                    slot.SetItemIcon(icon);
                    slot.SetAmount(reward.Items[itemIndex].amount);
                }
            }
            else
            {
                slot.SetItemIcon(null);
            }

            DailyRewardSlotState state;
            if (day <= lastClaimedDay)
                state = DailyRewardSlotState.Claimed;
            else if (day == currentDayToShow)
                state = DailyRewardSlotState.Available;
            else
                state = DailyRewardSlotState.Locked;

            slot.SetState(state);
        }
    }

    public void SetDates(DateTime? lastClaimed, DateTime today)
    {
        if (lastClaimedDate != null)
            lastClaimedDate.text = lastClaimed.HasValue ? $"Last claimed: {lastClaimed.Value:yyyy-MM-dd}" : "Last claimed: never";

        if (todayDate != null)
            todayDate.text = $"Today: {today:yyyy-MM-dd}";
    }
}
