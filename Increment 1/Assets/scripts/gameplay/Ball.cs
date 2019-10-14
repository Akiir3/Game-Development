using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Movement of the ball
/// </summary>
public class Ball : MonoBehaviour
{
    //const float MoveUnitsPerSecond = 2;

    //BoxCollider collider 
    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start()
	{
        //Vector2 vecMov = new Vector2(Mathf.Cos(Mathf.PI ), Mathf.Sin(Mathf.PI ));
        //GetComponent<Rigidbody2D>().AddForce(vecMov  * 10f, ForceMode2D.Impulse);


        const float MinImpulseForce = 3f;
        const float MaxImpulseForce = 6f;
        //loat angle = Random.Range(0, 2 * Mathf.PI);
        float angle = Random.Range(Mathf.PI / 4, 7 * Mathf.PI/4);
        float angle2 = Random.Range(3 * Mathf.PI / 4, 5 * Mathf.PI / 4);

        Vector2 rightDirection = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        Vector2 leftDirection = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

        float magnitude = Random.Range(MinImpulseForce, MaxImpulseForce);

        GetComponent<Rigidbody2D>().AddForce(rightDirection * magnitude, ForceMode2D.Impulse);
        GetComponent<Rigidbody2D>().AddForce(leftDirection * magnitude, ForceMode2D.Impulse);


    }


    void OnBecameInvisible()
    {
        //this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        //print(GetComponent<Rigidbody2D>().velocity.magnitude);
      Destroy(gameObject);
    }
}
