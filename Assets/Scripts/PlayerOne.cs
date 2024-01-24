using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerOne : MonoBehaviour
{

    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed;

    [SerializeField] private float ballSpeed;
    [SerializeField] private Color color;

    [SerializeField] private MovementController moveControl;

    private float vectorDeplacement = 0f;
    private float vectorRotation = 0f;

    private int score = 0;
    private int nbCase = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if (vectorDeplacement <= movementSpeed) { }
            vectorDeplacement = movementSpeed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (vectorDeplacement >= movementSpeed) { }
            vectorDeplacement = -movementSpeed;
        }
        if ((!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S)) || (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S)))
        {
            vectorDeplacement = 0;
        }



        if (Input.GetKey(KeyCode.A))
        {
            if (vectorRotation <= rotationSpeed) { }
            vectorRotation = rotationSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (vectorRotation >= rotationSpeed) { }
            vectorRotation = -rotationSpeed;
        }
        if ((!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D)) || (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D)))
        {
            vectorRotation = 0;
        }


        moveControl.Movement(vectorDeplacement);
        moveControl.Rotation(vectorRotation);
    }

    public void AddScore()
    {
        score++;
        Debug.Log("Score Joueur 1 : " + score);
        // Update L'ui 
    }

    public void AddNbCase()
    {
        nbCase++;
        ballSpeed+= 0.1f;
        FindAnyObjectByType<Ball>().TakeVelocity(ballSpeed);
    }

    public void RemoveNbCase()
    {
        nbCase--;
        ballSpeed -= 0.1f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball") 
        {
            Ball scriptBall = collision.gameObject.GetComponent<Ball>();
            scriptBall.TakeVelocity(ballSpeed);
            scriptBall.isPlayerOne = true;
            //scriptBall.ChangeColor(color);
        }
    }

}
