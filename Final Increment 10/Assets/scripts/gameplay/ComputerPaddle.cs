using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A computer-controlled paddle
/// </summary>
public class ComputerPaddle : Paddle
{
    /// <summary>
    /// FixedUpdate is called 50 times a second
    /// </summary>
    public override void FixedUpdate()
    {
        if (!frozen)
        {
            // find target and move appropriately
            GameObject target = FindTarget();
            if (target != null)
            {
                float paddleMoveAmount = ConfigurationUtils.PaddleMoveUnitsPerSecond * Time.deltaTime;
                float yDifference = Mathf.Abs(target.transform.position.y - rb2d.position.y);
                if (yDifference > paddleMoveAmount)
                {
                    newPosition = rb2d.position;
                    if (target.transform.position.y > rb2d.position.y)
                    {
                        newPosition.y += paddleMoveAmount;
                    }
                    else if (target.transform.position.y < rb2d.position.y)
                    {
                        newPosition.y -= paddleMoveAmount;
                    }
                    newPosition.y = CalculateClampedY(newPosition.y);
                    rb2d.MovePosition(newPosition);
                }
            }
        }
    }

    /// <summary>
    /// Gets the closest ball or pickup moving toward the
    /// computer paddle. Returns null if there are none
    /// </summary>
    /// <returns>closest ball or pickup moving toward paddle</returns>
    GameObject FindTarget()
    {
        float targetDistance = float.MaxValue;
        GameObject target = null;
        
        // process balls and pickups
        foreach (GameObject ball in GameObject.FindGameObjectsWithTag("Ball"))
        {
            float ballDistance = Vector3.Distance(transform.position,
                ball.transform.position);
            if (ballDistance < targetDistance &&
                ball.GetComponent<Rigidbody2D>().velocity.x > 0)
            {
                targetDistance = ballDistance;
                target = ball;
            }
        }
        foreach (GameObject pickup in GameObject.FindGameObjectsWithTag("Pickup"))
        {
            float pickupDistance = Vector3.Distance(transform.position,
                pickup.transform.position);
            if (pickupDistance < targetDistance &&
                pickup.GetComponent<Rigidbody2D>().velocity.x > 0)
            {
                targetDistance = pickupDistance;
                target = pickup;
            }
        }

        return target;
    }
}
