using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{

    [SerializeField] private string playerProprio = "nobody";
    [SerializeField] private Color[] threeColor;

    public string powerUp = "none";

    public void ResetTile()
    {
        playerProprio = "nobody";
        powerUp = "none";
        GetComponent<SpriteRenderer>().color = threeColor[0];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            Ball scriptBall = collision.gameObject.GetComponent<Ball>();

            if (scriptBall.isPlayerOne)
            {
                if (playerProprio == "player2")
                {
                    // On enlève la case au joueur 2
                    GameObject.Find("Player2").GetComponent<PlayerTwo>().RemoveNbCase();

                    if (powerUp != "none")
                    {
                        switch (powerUp)
                        {
                            case "barExtend":
                                GameObject.Find("Player2").GetComponent<PlayerTwo>().UnextendBar();
                                break;
                        }
                    }

                    // On donne la case au joueur 1
                    GameObject.Find("Player1").GetComponent<PlayerOne>().AddNbCase();
                    GetComponent<SpriteRenderer>().color = threeColor[1];
                    playerProprio = "player1";

                    if (powerUp !=  "none")
                    {
                        switch (powerUp)
                        {
                            case "barExtend":
                                GameObject.Find("Player1").GetComponent<PlayerOne>().ExtendBar();
                                break;
                        }
                    }
                }
                else if (playerProprio == "nobody")
                {
                    GameObject.Find("Player1").GetComponent<PlayerOne>().AddNbCase();
                    GetComponent<SpriteRenderer>().color = threeColor[1];
                    playerProprio = "player1";

                    // On donne la case au joueur 1
                    if (powerUp != "none")
                    {
                        switch (powerUp)
                        {
                            case "barExtend":
                                GameObject.Find("Player1").GetComponent<PlayerOne>().ExtendBar();
                                break;
                        }
                    }
                }
            }


            if (!scriptBall.isPlayerOne)
            {
                if (playerProprio == "player1")
                {
                    // On enlève la case au joueur 1
                    GameObject.Find("Player1").GetComponent<PlayerOne>().RemoveNbCase();

                    if (powerUp != "none")
                    {
                        switch (powerUp)
                        {
                            case "barExtend":
                                GameObject.Find("Player1").GetComponent<PlayerOne>().UnextendBar();
                                break;
                        }
                    }

                    // On donne la case au joueur 2
                    GameObject.Find("Player2").GetComponent<PlayerTwo>().AddNbCase();
                    GetComponent<SpriteRenderer>().color = threeColor[2];
                    playerProprio = "player2";

                    if (powerUp != "none")
                    {
                        switch (powerUp)
                        {
                            case "barExtend":
                                GameObject.Find("Player2").GetComponent<PlayerTwo>().ExtendBar();
                                break;
                        }
                    }
                }
                else if (playerProprio == "nobody")
                {
                    // On donne la case au joueur 2
                    GameObject.Find("Player2").GetComponent<PlayerTwo>().AddNbCase();
                    GetComponent<SpriteRenderer>().color = threeColor[2];
                    playerProprio = "player2";

                    if (powerUp != "none")
                    {
                        switch (powerUp)
                        {
                            case "barExtend":
                                GameObject.Find("Player2").GetComponent<PlayerTwo>().ExtendBar();
                                break;
                        }
                    }
                }
            }

        }
    }


}
