using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class Wall : MonoBehaviour
{

    [SerializeField] private bool isPlayerOne;
    [SerializeField] private GameObject ball;

    [SerializeField] private GameObject barExtendTile;
    [SerializeField] private GameObject stunTile;

    [SerializeField] private GameObject goalP1Particle;
    [SerializeField] private GameObject goalP2Particle;

    [SerializeField] private GameObject resetP1Particle;
    [SerializeField] private GameObject resetP2Particle;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            Destroy(collision.gameObject);

            GameObject tempBall = Instantiate(ball, new Vector2(-0.06f, -0.6f), transform.rotation);

            if (isPlayerOne)
            {
                GameObject.Find("Player2").GetComponent<PlayerTwo>().AddScore();
                StartCoroutine(AnimationP2E1());
            }
            else
            {
                GameObject.Find("Player1").GetComponent<PlayerOne>().AddScore();
                StartCoroutine(AnimationP1E1());
            }

        }
    }

    IEnumerator AnimationP1E1()
    {

        Instantiate(goalP1Particle);

        yield return new WaitForSeconds(1);

        StartCoroutine("AnimationP1E2");

    }
    IEnumerator AnimationP1E2()
    {

        Instantiate(resetP2Particle);

        yield return new WaitForSeconds(0.5f);

        StartCoroutine("AnimationP1E3");

    }
    IEnumerator AnimationP1E3()
    {

        ResetTerrain();
        ResetPlayers();

        yield return new WaitForSeconds(1);

        FindAnyObjectByType<Ball>().BallInit(false);
    }

    IEnumerator AnimationP2E1()
    {

        Instantiate(goalP2Particle);

        yield return new WaitForSeconds(1);

        StartCoroutine("AnimationP2E2");

    }
    IEnumerator AnimationP2E2()
    {

        Instantiate(resetP1Particle);

        yield return new WaitForSeconds(0.5f);

        StartCoroutine("AnimationP2E3");

    }
    IEnumerator AnimationP2E3()
    {

        ResetTerrain();
        ResetPlayers();

        yield return new WaitForSeconds(1);

        FindAnyObjectByType<Ball>().BallInit(true);
    }



    public void AnimationP2()
    {
        float timeStamp = 0f;
        Instantiate(goalP2Particle);

        while (timeStamp < 1)
        {
            timeStamp += Time.deltaTime;
        }

        Instantiate(resetP1Particle);
        timeStamp = 0f;

        while (timeStamp < 0.3)
        {
            timeStamp += Time.deltaTime;
        }

        ResetTerrain();
        ResetPlayers();

        timeStamp = 0f;

        while (timeStamp < 1)
        {
            timeStamp += Time.deltaTime;
        }

        FindAnyObjectByType<Ball>().BallInit(true);

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
        Instantiate(barExtendTile, tuileBarExtend.transform);

        // Ajout d'une tuile Stun
        Tile tuileStun = tiles[Random.Range(0, tiles.Length)];
        tuileStun.powerUp = "stun";
        Instantiate(stunTile, tuileStun.transform);

    }

    public void ResetPlayers()
    {
        GameObject.Find("Player1").GetComponent<PlayerOne>().ResetPlayer();
        GameObject.Find("Player2").GetComponent<PlayerTwo>().ResetPlayer();
    }

}
