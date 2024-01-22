using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{

    [SerializeField] private Rigidbody2D myRb;
    
    public void Movement(float valueDirection)
    {

        myRb.velocity = new Vector2(0, valueDirection * Time.deltaTime);

    }

    public void Rotation(float valueRotation)
    {

        myRb.transform.rotation = Quaternion.Euler(myRb.transform.rotation.eulerAngles + Vector3.forward * valueRotation * Time.deltaTime );

    }



}
