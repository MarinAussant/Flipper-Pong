using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{

    [SerializeField] private bool isPlayerOne;
    [SerializeField] private GameObject ball;

    [SerializeField] private GameObject barExtendTile;

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

        foreach (GameObject powerUpTIle in GameObject.FindGameObjectsWithTag("PowerUp"))
        {
            Destroy(powerUpTIle);
        }

        foreach (Tile tuile in tiles)
        {
            tuile.ResetTile();
        }

        // Ajout d'une tuile Bar Extend
        Tile tuileBarExtend = tiles[Random.Range(0, tiles.Length)];
        tuileBarExtend.powerUp = "barExtend";
        GameObject renderBarExtend = Instantiate(barExtendTile, tuileBarExtend.transform);
        renderBarExtend.transform.localPosition = Vector3.zero;
        renderBarExtend.transform.localScale = new Vector3(0.65f, 0.65f, 0.65f);

    }

    public void ResetPlayers()
    {
        GameObject.Find("Player1").GetComponent<PlayerOne>().ResetPlayer();
        GameObject.Find("Player2").GetComponent<PlayerTwo>().ResetPlayer();
    }

}
