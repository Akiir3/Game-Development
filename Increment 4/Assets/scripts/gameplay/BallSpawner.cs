using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A ball spawner
/// </summary>
public class BallSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject ballPrefab;

    #region Unity methods

    //timer to check the time
    Timer spawnTimer;

    //spawn location support
    const int spawnBorderSize = 100;
    int minSpawnX;
    int maxSpawnX;
    int minSpawnY;
    int maxSpawnY;

    //collision-free support
    const int maxSpawnTries = 20;
    float ballColliderHalfWith;
    float ballColliderHalfHeight;
    Vector2 min = new Vector2();
    Vector2 max = new Vector2();

    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start()
    {
        //save spawn boundaries for efficiency
        minSpawnX = spawnBorderSize;
        maxSpawnX = Screen.width - spawnBorderSize;
        minSpawnY = spawnBorderSize;
        maxSpawnY = Screen.height - spawnBorderSize;

        // add spawn timer
        spawnTimer = gameObject.AddComponent<Timer>();
        spawnTimer.Duration = Random.Range(ConfigurationUtils.minSpawnDelayed, ConfigurationUtils.maxSpawnDelayed);
        spawnTimer.Run();

    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        // spawn ball and restart timer as appropriate
        if (spawnTimer.Finished)
        {
            SpawnBall();

            //change spawntimer to random duration
            spawnTimer.Duration = Random.Range(ConfigurationUtils.minSpawnDelayed, ConfigurationUtils.maxSpawnDelayed);
            spawnTimer.Run();
        }
    }

    #endregion

    #region Public methods

    /// <summary>
    /// Spawns a ball in the center of the screen
    /// </summary>
    public void SpawnBall()
    {
        //generate random location and create a new ball
        //Vector3 location = new Vector3(Random.Range(minSpawnX, maxSpawnX), 
        //    Random.Range(minSpawnY, maxSpawnY), -Camera.main.transform.position.z);
        //Vector3 worldLocation = Camera.main.ScreenToWorldPoint(location);
        //GameObject ball = Instantiate(ballPrefab) as GameObject;
        //ball.transform.position = worldLocation;

        if (Physics2D.OverlapArea(min, max) == null)
        {
            Instantiate(ballPrefab, Vector3.zero, Quaternion.identity);
        }
    }

    #endregion
}
