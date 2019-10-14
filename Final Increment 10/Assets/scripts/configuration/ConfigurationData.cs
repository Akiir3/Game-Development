using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// A container for the configuration data
/// </summary>
public class ConfigurationData
{
    #region Fields

    const string ConfigurationDataFileName = "ConfigurationData.csv";

    // difficulty-specific data
    static float easyBallImpulseForce = 3;
    static float mediumBallImpulseForce = 5;
    static float hardBallImpulseForce = 7;
    static float easyMinSpawnDelay = 8;
    static float easyMaxSpawnDelay = 13;
    static float mediumMinSpawnDelay = 5;
    static float mediumMaxSpawnDelay = 10;
    static float hardMinSpawnDelay = 2;
    static float hardMaxSpawnDelay = 7;

    // other configuration data
    static float paddleMoveUnitsPerSecond = 10;
    static float ballLifeSeconds = 10;
    static int standardPoints = 1;
    static int standardHits = 1;
    static int bonusPoints = 2;
    static int bonusHits = 2;
    static float freezerSeconds = 2;
    static float speedupSeconds = 2;
    static float speedupFactor = 2;
    static float standardBallSpawnProbability = 0.6f;
    static float bonusBallSpawnProbability = 0.2f;
    static float freezerPickupSpawnProbability = 0.1f;
    static float speedupPickupSpawnProbability = 0.1f;

    #endregion

    #region Properties

    /// <summary>
    /// Gets the impulse force to apply to move the ball
    /// for easy difficuly
    /// </summary>
    /// <value>easy impulse force</value>
    public float EasyBallImpulseForce
    {
        get { return easyBallImpulseForce; }
    }

    /// <summary>
    /// Gets the impulse force to apply to move the ball
    /// for medium difficuly
    /// </summary>
    /// <value>medium impulse force</value>
    public float MediumBallImpulseForce
    {
        get { return mediumBallImpulseForce; }
    }

    /// <summary>
    /// Gets the impulse force to apply to move the ball
    /// for hard difficuly
    /// </summary>
    /// <value>hard impulse force</value>
    public float HardBallImpulseForce
    {
        get { return hardBallImpulseForce; }
    }

    /// <summary>
    /// Gets the min spawn delay for ball spawning
    /// for easy difficulty
    /// </summary>
    public float EasyMinSpawnDelay
    {
        get { return easyMinSpawnDelay; }
    }

    /// <summary>
    /// Gets the max spawn delay for ball spawning
    /// for easy difficulty
    /// </summary>
    public float EasyMaxSpawnDelay
    {
        get { return easyMaxSpawnDelay; }
    }

    /// <summary>
    /// Gets the min spawn delay for ball spawning
    /// for medium difficulty
    /// </summary>
    public float MediumMinSpawnDelay
    {
        get { return mediumMinSpawnDelay; }
    }

    /// <summary>
    /// Gets the max spawn delay for ball spawning
    /// for medium difficulty
    /// </summary>
    public float MediumMaxSpawnDelay
    {
        get { return mediumMaxSpawnDelay; }
    }

    /// <summary>
    /// Gets the min spawn delay for ball spawning
    /// for hard difficulty
    /// </summary>
    public float HardMinSpawnDelay
    {
        get { return hardMinSpawnDelay; }
    }

    /// <summary>
    /// Gets the max spawn delay for ball spawning
    /// for hard difficulty
    /// </summary>
    public float HardMaxSpawnDelay
    {
        get { return hardMaxSpawnDelay; }
    }

    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public float PaddleMoveUnitsPerSecond
    {
        get { return paddleMoveUnitsPerSecond; }
    }

    /// <summary>
    /// Gets how many seconds a ball stays alive
    /// </summary>
    public float BallLifeSeconds
    {
        get { return ballLifeSeconds; }
    }

    /// <summary>
    /// Gets the number of points a standard ball is worth
    /// </summary>
    public int StandardPoints
    {
        get { return standardPoints; }
    }

    /// <summary>
    /// Gets the number of hits a standard ball is worth
    /// </summary>
    public int StandardHits
    {
        get { return standardHits; }
    }

    /// <summary>
    /// Gets the number of points a bonus ball is worth
    /// </summary>
    public int BonusPoints
    {
        get { return bonusPoints; }
    }

    /// <summary>
    /// Gets the number of hits a bonus ball is worth
    /// </summary>
    public int BonusHits
    {
        get { return bonusHits; }
    }

    /// <summary>
    /// Gets the number of seconds the freezer effect lasts
    /// </summary>
    public float FreezerSeconds
    {
        get { return freezerSeconds; }
    }

    /// <summary>
    /// Gets the number of seconds the speedup effect lasts
    /// </summary>
    public float SpeedupSeconds
    {
        get { return speedupSeconds; }
    }

    /// <summary>
    /// Gets the speedup multiplier
    /// </summary>
    public float SpeedupFactor
    {
        get { return speedupFactor; }
    }

    /// <summary>
    /// Gets the probability of spawning a standard ball
    /// </summary>
    public float StandardBallSpawnProbability
    {
        get { return standardBallSpawnProbability; }
    }

    /// <summary>
    /// Gets the probability of spawning a bonus ball
    /// </summary>
    public float BonusBallSpawnProbability
    {
        get { return bonusBallSpawnProbability; }
    }

    /// <summary>
    /// Gets the probability of spawning a freezer pickup
    /// </summary>
    public float FreezerPickupSpawnProbability
    {
        get { return freezerPickupSpawnProbability; }
    }

    /// <summary>
    /// Gets the probability of spawning a speedup pickup
    /// </summary>
    public float SpeedupPickupSpawnProbability
    {
        get { return speedupPickupSpawnProbability; }
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Constructor
    /// Reads configuration data from a file. If the file
    /// read fails, the object contains default values for
    /// the configuration data
    /// </summary>
    public ConfigurationData()
    {
        // read and save configuration data from file
        StreamReader input = null;
        try
        {
            // create stream reader object
            input = File.OpenText(Path.Combine(
                Application.streamingAssetsPath, ConfigurationDataFileName));

            // read in names and values
            string names = input.ReadLine();
            string values = input.ReadLine();

            // set configuration data fields
            SetConfigurationDataFields(values);
        }
        catch (Exception e)
        {
        }
        finally
        {
            // always close input file
            if (input != null)
            {
                input.Close();
            }
        }
    }

    #endregion

    /// <summary>
    /// Sets the configuration data fields from the provided
    /// csv string
    /// </summary>
    /// <param name="csvValues">csv string of values</param>
    void SetConfigurationDataFields(string csvValues)
    {
        // the code below assumes we know the order in which the
        // values appear in the string. We could do something more
        // complicated with the names and values, but that's not
        // necessary here
        string[] values = csvValues.Split(',');
        easyBallImpulseForce = float.Parse(values[0]);
        mediumBallImpulseForce = float.Parse(values[1]);
        hardBallImpulseForce = float.Parse(values[2]);
        easyMinSpawnDelay = float.Parse(values[3]);
        easyMaxSpawnDelay = float.Parse(values[4]);
        mediumMinSpawnDelay = float.Parse(values[5]);
        mediumMaxSpawnDelay = float.Parse(values[6]);
        hardMinSpawnDelay = float.Parse(values[7]);
        hardMaxSpawnDelay = float.Parse(values[8]);
        paddleMoveUnitsPerSecond = float.Parse(values[9]);
        ballLifeSeconds = float.Parse(values[10]);
        standardPoints = int.Parse(values[11]);
        standardHits = int.Parse(values[12]);
        bonusPoints = int.Parse(values[13]);
        bonusHits = int.Parse(values[14]);
        freezerSeconds = float.Parse(values[15]);
        speedupSeconds = float.Parse(values[16]);
        speedupFactor = float.Parse(values[17]);
        standardBallSpawnProbability = float.Parse(values[18]) / 100;
        bonusBallSpawnProbability = float.Parse(values[19]) / 100;
        freezerPickupSpawnProbability = float.Parse(values[20]) / 100;
        speedupPickupSpawnProbability = float.Parse(values[21]) / 100;
    }
}
