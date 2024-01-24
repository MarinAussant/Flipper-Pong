using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Ball : MonoBehaviour
{

    [SerializeField] float ballSpeed;
    [SerializeField] Rigidbody2D myRb;

    [SerializeField]  private int[] directionChoice;

    public Color color;
    public bool isPlayerOne;

    public void BallInit(bool forPlayerOne)
    {
        if(forPlayerOne)
        {
            isPlayerOne = true;
            myRb.velocity = new Vector2(-ballSpeed, 0);
        }
        else
        {
            isPlayerOne = false;
            myRb.velocity = new Vector2(ballSpeed, 0);
        }
    }

    void FixedUpdate()
    {
        
        if (myRb.velocity.magnitude < ballSpeed || myRb.velocity.magnitude > ballSpeed) 
        {
            myRb.velocity = myRb.velocity.normalized * ballSpeed;
        }
        
    }

    public void TakeVelocity(float speed)
    {
        ballSpeed = speed;
    }

    public void ChangeColor(Color newColor)
    {
        color = newColor;
        GetComponent<SpriteRenderer>().color = newColor;
    }

}
