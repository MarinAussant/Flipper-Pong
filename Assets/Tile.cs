using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{

    [SerializeField] private string playerProprio = "nobody";
    [SerializeField] private Color[] threeColor;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            Ball scriptBall = collision.gameObject.GetComponent<Ball>();

            if (scriptBall.isPlayerOne)
            {
                if (playerProprio == "player2")
                {
                    GameObject.Find("Player2").GetComponent<PlayerTwo>().RemoveNbCase();

                    
                    GameObject.Find("Player1").GetComponent<PlayerOne>().AddNbCase();
                    GetComponent<SpriteRenderer>().color = threeColor[1];
                    playerProprio = "player1";
                }
                else if (playerProprio == "nobody")
                {
                    GameObject.Find("Player1").GetComponent<PlayerOne>().AddNbCase();
                    GetComponent<SpriteRenderer>().color = threeColor[1];
                    playerProprio = "player1";
                }
            }

            if (!scriptBall.isPlayerOne)
            {
                if (playerProprio == "player1")
                {
                    GameObject.Find("Player1").GetComponent<PlayerOne>().RemoveNbCase();


                    GameObject.Find("Player2").GetComponent<PlayerTwo>().AddNbCase();
                    GetComponent<SpriteRenderer>().color = threeColor[2];
                    playerProprio = "player2";
                }
                else if (playerProprio == "nobody")
                {
                    GameObject.Find("Player2").GetComponent<PlayerTwo>().AddNbCase();
                    GetComponent<SpriteRenderer>().color = threeColor[2];
                    playerProprio = "player2";
                }
            }

        }
    }


}
