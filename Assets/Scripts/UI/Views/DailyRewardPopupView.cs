using System;
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

    public void RefreshSlots(Func<int, DailyReward> getRewardForDay, int lastClaimedDay, int currentDayToShow)
    {
        if (daySlots == null) return;

        for (int i = 0; i < daySlots.Length; i++)
        {
            int day = i + 1;
            var slot = daySlots[i];
            if (slot == null) continue;

            slot.SetDay(day);

            var reward = getRewardForDay(day);

            if (reward != null)
            {
                string itemsText = "";
                for (int j = 0; j < reward.Items.Count; j++)
                {
                    var it = reward.Items[j];
                    itemsText += it.amount + " " + it.type;

                    if (j < reward.Items.Count - 1)
                        itemsText += ", ";
                }

                slot.SetItemsText(itemsText);
            }
            else
            {
                slot.SetItemsText("No reward");
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
}
