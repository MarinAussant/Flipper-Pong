using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEditor;
using UnityEngine;

public class PlayerTwo : MonoBehaviour
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


            yield return new WaitForEndOfFrame();
        }

    }



}
