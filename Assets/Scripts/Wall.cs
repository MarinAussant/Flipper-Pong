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
            ResetTerrain();
            ResetPlayers();

            GameObject tempBall = Instantiate(ball, new Vector2(-0.06f, -0.6f), transform.rotation);

            if (isPlayerOne)
            {
                GameObject.Find("Player2").GetComponent<PlayerTwo>().AddScore();
                tempBall.GetComponent<Ball>().BallInit(true);
            }
            else
            {
                GameObject.Find("Player1").GetComponent<PlayerOne>().AddScore();
                tempBall.GetComponent<Ball>().BallInit(false);
            }

        }
    }

    public void ResetTerrain()
    {
        Tile[] tiles = FindObjectsOfType<Tile>();

        foreach (Tile tuile in tiles)
        {
            tuile.ResetTile();
        }

        Tile tuileBarExtend = tiles[Random.Range(0, tiles.Length)];
        tuileBarExtend.powerUp = "barExtend";
        tuileBarExtend.GetComponent<SpriteRenderer>().color = new Color(1,1,1,1);
    }

    public void ResetPlayers()
    {
        GameObject.Find("Player1").GetComponent<PlayerOne>().ResetPlayer();
        GameObject.Find("Player2").GetComponent<PlayerTwo>().ResetPlayer();
    }

}
