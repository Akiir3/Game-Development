using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A paddle
/// </summary>
public class Paddle : MonoBehaviour
{
    //variable for the paddles
    private Rigidbody2D rb2d;

    //needed for spawning
    [SerializeField]
    ScreenSide sideOfScreen;

    float colliderHalfWidth;
    float colliderHalfHeight;
    BoxCollider2D collider;


    /// Use this for initialization
    void Start()
	{
        rb2d = GetComponent<Rigidbody2D>();

        //save collider dimension values 
        collider = GetComponent<BoxCollider2D>(); 
        Vector3 diff = collider.bounds.max - collider.bounds.min; 
        colliderHalfWidth = diff.x / 2; 
        colliderHalfHeight = diff.y / 2;

    }

	/// Update is called once per frame

	void FixedUpdate()
	{
        //assigning the sides
        float rightInput = Input.GetAxis("Vertical");
        float leftInput = Input.GetAxis("Vertical2");

         //move base on input
        Vector2 position = transform.position;
       //float verticalInput = Input.GetAxis("Vertical");

        if(sideOfScreen == ScreenSide.Left && leftInput != 0)
        {
            position.y += leftInput * ConfigurationUtils.PaddleMoveUnitsPerSecond * Time.deltaTime;

        }
       
        if (sideOfScreen == ScreenSide.Right && rightInput != 0)
        {
            position.y += rightInput * ConfigurationUtils.PaddleMoveUnitsPerSecond * Time.deltaTime;

        }
     
        transform.position = position;
    }
	
}
