using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerTwo : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI scoreTexte;
    [SerializeField] private TextMeshProUGUI speedTexte;


    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed;

    [SerializeField] private float ballSpeed;
    [SerializeField] private Color color;

    [SerializeField] private MovementController moveControl;

    [SerializeField] private GameObject stunParticle;

    private float vectorDeplacement = 0f;
    private float vectorRotation = 0f;

    private GameObject actualStunParticle;

    private int score = 0;
    private int nbCase = 0;
    private bool isStun = false;

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
        scoreTexte.text = score + " Score";
        // Update L'ui 
    }

    public void AddNbCase()
    {
        nbCase++;
        speedTexte.text = (ballSpeed + (nbCase * 0.1f)) + " Speed";
        FindAnyObjectByType<Ball>().TakeVelocity(ballSpeed + (nbCase * 0.1f));
    }

    public void RemoveNbCase()
    {
        nbCase--;
        speedTexte.text = (ballSpeed + (nbCase * 0.1f)) + " Speed";
    }

    public void ExtendBar()
    {
        transform.localScale = new Vector3(0.7f, 1.3f, 1f);
    }
    public void UnextendBar()
    {
        transform.localScale = new Vector3(0.7f, 0.9f, 1f);
    }

    public void ActiveStun()
    {
        actualStunParticle = Instantiate(stunParticle, transform);
        isStun = true;
    }
    public void DesactiveStun()
    {
        Destroy(actualStunParticle);
        isStun = false;
    }


    public void ResetPlayer()
    {
        transform.position = new Vector2(7f, -0.6f);
        transform.rotation = Quaternion.Euler(0, 0, 0);

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
            scriptBall.isPlayerOne = false;
            //scriptBall.ChangeColor(color);
        }
    }

}
