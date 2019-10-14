using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : Ball
{
    // freezer timer
    float freezerTimer;


    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        freezerTimer = ConfigurationUtils.FreezeTimer;
    }


    /// <summary>
    /// Detects collision with a ball to aim the ball
    /// </summary>
    /// <param name="coll">collision info</param>
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (balltype == BallType.Freeze && (coll.gameObject.CompareTag("LeftPaddle") || coll.gameObject.CompareTag("RightPaddle")))
        {
            if (coll.gameObject.CompareTag("LeftPaddle"))
            {
                GameObject.FindGameObjectWithTag("RightPaddle").GetComponent<Paddle>().Freeze(ScreenSide.Right, freezerTimer);
            }
            else if (coll.gameObject.CompareTag("RightPaddle"))
            {
                GameObject.FindGameObjectWithTag("LeftPaddle").GetComponent<Paddle>().Freeze(ScreenSide.Left, freezerTimer);
            }
            // spawn new one
            Camera.main.GetComponent<BallSpawner>().SpawnBall();
            Destroy(gameObject);
        }
    }
}
