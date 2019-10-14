using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// A menu that starts a game
/// </summary>
public class GameStartingMenu : MonoBehaviour
{
    protected GameStartedEvent gameStartedEvent = new GameStartedEvent();

    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start()
    {
        // add invoker to event manager
        EventManager.AddGameStartedInvoker(this);
    }

    /// <summary>
    /// Adds the given listener for the game started event
    /// </summary>
    /// <param name="listener">listener</param>
    public void AddGameStartedListener(UnityAction<GameType, Difficulty> listener)
    {
        gameStartedEvent.AddListener(listener);
    }
}
