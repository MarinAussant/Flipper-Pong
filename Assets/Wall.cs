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

            
            ResetTerrain();
            ResetPlayers();
            Instantiate(ball, new Vector2(-0.06f, -0.6f), transform.rotation);

        }
    }

    public void ResetTerrain()
    {
        foreach (Tile tuile in FindObjectsOfType<Tile>())
        {
            tuile.ResetTile();
        }
    }

    public void ResetPlayers()
    {
        GameObject.Find("Player1").GetComponent<PlayerOne>().ResetPlayer();
        GameObject.Find("Player2").GetComponent<PlayerTwo>().ResetPlayer();
    }

}
