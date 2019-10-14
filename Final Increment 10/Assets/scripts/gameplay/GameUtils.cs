using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Provides difficulty-specific utilities
/// </summary>
public static class GameUtils
{
    #region Fields

    static GameType type;
    static Difficulty difficulty;

    #endregion

    #region Properties

    /// <summary>
    /// Gets the game type of the current game
    /// </summary>
    public static GameType GameType
    {
        get { return type; }
    }

    /// <summary>
    /// Gets the impulse force for balls
    /// </summary>
    /// <value>impulse force</value>
    public static float BallImpulseForce
    {
        get
        {
            switch (difficulty)
            {
                case Difficulty.Easy:
                    return ConfigurationUtils.EasyBallImpulseForce;
                case Difficulty.Medium:
                    return ConfigurationUtils.MediumBallImpulseForce;
                case Difficulty.Hard:
                    return ConfigurationUtils.HardBallImpulseForce;
                default:
                    return ConfigurationUtils.EasyBallImpulseForce;
            }
        }
    }

    /// <summary>
    /// Gets the min spawn delay for ball spawning
    /// </summary>
    /// <value>minimum spawn delay</value>
    public static float MinSpawnDelay
    {
        get
        {
            switch (difficulty)
            {
                case Difficulty.Easy:
                    return ConfigurationUtils.EasyMinSpawnDelay;
                case Difficulty.Medium:
                    return ConfigurationUtils.MediumMinSpawnDelay;
                case Difficulty.Hard:
                    return ConfigurationUtils.HardMinSpawnDelay;
                default:
                    return ConfigurationUtils.EasyMinSpawnDelay;
            }
        }
    }

    /// <summary>
    /// Gets the max spawn delay for ball spawning
    /// </summary>
    /// <value>maximum spawn delay</value>
    public static float MaxSpawnDelay
    {
        get
        {
            switch (difficulty)
            {
                case Difficulty.Easy:
                    return ConfigurationUtils.EasyMaxSpawnDelay;
                case Difficulty.Medium:
                    return ConfigurationUtils.MediumMaxSpawnDelay;
                case Difficulty.Hard:
                    return ConfigurationUtils.HardMaxSpawnDelay;
                default:
                    return ConfigurationUtils.EasyMaxSpawnDelay;
            }
        }
    }

    #endregion

    #region Public methods

    /// <summary>
    /// Initializes the difficulty utils
    /// </summary>
    public static void Initialize()
    {
        EventManager.AddGameStartedListener(HandleGameStartedEvent);
    }

    #endregion

    #region Private methods

    /// <summary>
    /// Sets the difficulty and starts the game
    /// </summary>
    /// <param name="gameType">game type</param>
    /// <param name="gameDifficulty">game difficulty</param>
    static void HandleGameStartedEvent(GameType gameType, Difficulty gameDifficulty)
    {
        type = gameType;
        difficulty = gameDifficulty;
        SceneManager.LoadScene("gameplay");
    }

    #endregion
}
