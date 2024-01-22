using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    [SerializeField] float baseSpeed;
    [SerializeField] Rigidbody2D myRb;
    
    void Start()
    {
        myRb.velocity = new Vector2(baseSpeed, 0);
    }

    public void TakeVelocity(float speed)
    {
        myRb.velocity = new Vector2(speed, 0);
    }

}
