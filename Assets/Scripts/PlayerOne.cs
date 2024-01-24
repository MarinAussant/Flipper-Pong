using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerOne : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI scoreTexte;
    [SerializeField] private TextMeshProUGUI speedTexte;


    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed;

    [SerializeField] private float ballSpeed;
    [SerializeField] private Color color;

    [SerializeField] private MovementController moveControl;

    private float vectorDeplacement = 0f;
    private float vectorRotation = 0f;

    private int score = 0;
    private int nbCase = 0;
    private bool isStun = false;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Ball").GetComponent<Ball>().BallInit(Random.value < 0.5f);
        GameObject.Find("GoalPlayer1").GetComponent<Wall>().ResetTerrain();
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

        if (isStun)
        {
            moveControl.Movement(-vectorDeplacement);
            moveControl.Rotation(-vectorRotation);
        }
        else
        {
            moveControl.Movement(vectorDeplacement);
            moveControl.Rotation(vectorRotation);
        }
    }

    public void AddScore()
    {
        score++;
        scoreTexte.text = "Score " + score;
    }

    public void AddNbCase()
    {
        nbCase++;
        speedTexte.text = "Speed " + (ballSpeed + (nbCase * 0.1f));
        FindAnyObjectByType<Ball>().TakeVelocity(ballSpeed + (nbCase * 0.1f));
    }

    public void RemoveNbCase()
    {
        nbCase--;
        speedTexte.text = "Speed " + (ballSpeed + (nbCase * 0.1f));
    }


    public void ExtendBar()
    {
        transform.localScale =  new Vector3(0.7f, 1.3f, 1f);
    }
    public void UnextendBar()
    {
        transform.localScale = new Vector3(0.7f, 0.9f, 1f);
    }

    public void ActiveStun()
    {
        isStun = true;
    }
    public void DesactiveStun()
    {
        isStun = false;
    }

    public void ResetPlayer()
    {
        transform.position = new Vector2(-7f, -0.6f);
        transform.rotation = Quaternion.Euler(0,0,0);

        UnextendBar();
        DesactiveStun();

        nbCase = 0;
        speedTexte.text = "Speed " + (ballSpeed + (nbCase * 0.1f));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball") 
        {
            Ball scriptBall = collision.gameObject.GetComponent<Ball>();
            scriptBall.TakeVelocity(ballSpeed + (nbCase * 0.1f));
            scriptBall.isPlayerOne = true;
            //scriptBall.ChangeColor(color);
        }
    }

}
