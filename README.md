Small Unity project showcasing a Daily Reward popup: JSON-driven data, one claim per day, day simulation, and atlas-based icons mapped to an enum.

## How it works
- `Claim` grants the reward for the current (UTC/simulated) day, blocks repeat claims that day, and saves progress.
- `Simulate Next Day` moves the internal date forward by one day so you can test the next reward without changing system time.
- Day slots show icon + amount; the state updates after claiming. The popup also shows the last-claim date and the current “today”.

## How to run
- Open the project in Unity, load the entry scene `Assets/Scenes/Game`, and open Daily Popup.
- In the popup: tap `Claim` to collect; tap `Simulate Next Day`, then `Claim` again to see the next reward.

Reward data lives in `Assets/Scripts/Data/Resources/Config/daily_rewards.json`; the `type` fields match the `ItemType` enum and the sprite names in the atlas, resolved via `ItemIconDatabaseSO` + `ItemIconProvider`.

Architecture: `GameRoot` builds a simple composition root with screen/popup managers and a shared context; presenters drive views while services handle rules and persistence. It’s structured to stay maintainable and easy to grow as more screens/popups are added.

Player data (last claimed day/date and wallet) is loaded on game start and saved locally as `player.json`.
