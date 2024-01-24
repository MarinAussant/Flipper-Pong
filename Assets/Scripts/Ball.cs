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
    
    void Start()
    {
        myRb.velocity = new Vector2(ballSpeed * directionChoice[Random.Range(0,1)], 0);
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
