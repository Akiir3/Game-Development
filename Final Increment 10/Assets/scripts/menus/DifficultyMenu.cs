using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Listens for the OnClick events for the difficulty menu buttons
/// </summary>
public class DifficultyMenu : GameStartingMenu
{
    /// <summary>
    /// Handles the on click event from the easy button
    /// </summary>
    public void HandleEasyButtonOnClickEvent()
    {
        AudioManager.Play(AudioClipName.MenuButtonClick);
        gameStartedEvent.Invoke(GameType.OnePlayer, Difficulty.Easy);
    }

    /// <summary>
    /// Handles the on click event from the medium button
    /// </summary>
    public void HandleMediumButtonOnClickEvent()
    {
        AudioManager.Play(AudioClipName.MenuButtonClick);
        gameStartedEvent.Invoke(GameType.OnePlayer, Difficulty.Medium);
    }

    /// <summary>
    /// Handles the on click event from the hard button
    /// </summary>
    public void HandleHardButtonOnClickEvent()
    {
        AudioManager.Play(AudioClipName.MenuButtonClick);
        gameStartedEvent.Invoke(GameType.OnePlayer, Difficulty.Hard);
    }
}
