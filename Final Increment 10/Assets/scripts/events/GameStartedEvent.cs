using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// An event indicating that a game has been started
/// </summary>
public class GameStartedEvent : UnityEvent<GameType, Difficulty>
{
}
