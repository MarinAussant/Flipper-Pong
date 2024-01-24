using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{

    [SerializeField] private bool isPlayerOne;
    [SerializeField] private GameObject ball;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            Destroy(collision.gameObject);

            if (isPlayerOne)
            {
                GameObject.Find("Player2").GetComponent<PlayerTwo>().AddScore();
            }
            else
            {
                GameObject.Find("Player1").GetComponent<PlayerOne>().AddScore();
            }

            //Instantiate(ball, new Vector2(-0.06f, -0.6f), transform.rotation);

        }
    }

}
