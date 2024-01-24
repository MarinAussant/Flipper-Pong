using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerTwo : MonoBehaviour
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
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (vectorDeplacement <= movementSpeed) { }
            vectorDeplacement = movementSpeed;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (vectorDeplacement >= movementSpeed) { }
            vectorDeplacement = -movementSpeed;
        }
        if ((!Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow)) || (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.DownArrow)))
        {
            vectorDeplacement = 0;
        }



        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (vectorRotation <= rotationSpeed) { }
            vectorRotation = rotationSpeed;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (vectorRotation >= rotationSpeed) { }
            vectorRotation = -rotationSpeed;
        }
        if ((!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow)) || (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow)))
        {
            vectorRotation = 0;
        }


        moveControl.Movement(vectorDeplacement);
        moveControl.Rotation(vectorRotation);
    }

    public void AddScore()
    {
        
        score++;
        Debug.Log("Score Joueur 2 : " + score);
        // Update L'ui 
    }

    public void AddNbCase()
    {
        nbCase++;
        ballSpeed += 0.2f;
        FindAnyObjectByType<Ball>().TakeVelocity(ballSpeed);
    }

    public void RemoveNbCase()
    {
        nbCase--;
        ballSpeed -= 0.2f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            Ball scriptBall = collision.gameObject.GetComponent<Ball>();
            scriptBall.TakeVelocity(ballSpeed);
            scriptBall.isPlayerOne = false;
            //scriptBall.ChangeColor(color);
        }
    }

}
