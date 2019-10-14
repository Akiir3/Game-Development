using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides access to configuration data
/// </summary>
public static class ConfigurationUtils
{
    #region Properties

    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    public static float PaddleMoveUnitsPerSecond
    {
        get { return 10; }
    }

    /// <summary>
    /// Gets the impulse force to apply to a ball
    /// to get it moving
    /// </summary>
    public static float BallImpulseForce
    {
        get { return 5; }
    }

    /// <summary>
    /// Gets how many seconds a ball stays alive
    /// </summary>
    public static float BallLifeSeconds
    {
        get { return 10; }
    }

    #endregion

    /// <summary>
    /// Initializes the configuration utils
    /// </summary>
    public static void Initialize()
    {

    }

    public static int BallPoints //Gonna use this one for the score points
    {
        get { return 1; }
    }

    public static int HitPoints  //This one for the hit points
    {
        get { return 1; }
    }
}
