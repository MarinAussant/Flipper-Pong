using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEditor;
using UnityEngine;

public class PlayerOne : MonoBehaviour
{

    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed;

    [SerializeField] private MovementController moveControl;

    private float vectorDeplacement = 0f;
    private float vectorRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("FrameTimedUpdate");
    }

    IEnumerator FrameTimedUpdate()
    {

        while (true)
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
            if ((!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D)) || (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D)) )
            {
                vectorRotation = 0;
            }

            
            moveControl.Movement(vectorDeplacement);
            moveControl.Rotation(vectorRotation);


            yield return new WaitForEndOfFrame();
        }
        
    }

    

}
