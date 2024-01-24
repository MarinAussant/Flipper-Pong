using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int Score1;
    public int Score2;

    public int Speed1;
    public int Speed2;

    public TextMeshProUGUI Score1UI;
    public TextMeshProUGUI Score2UI;

    public TextMeshProUGUI Speed1UI;
    public TextMeshProUGUI Speed2UI;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseScore1()
    {
        Score1++;
        Score1UI.text = "Score " + Score1;
    }

    public void IncreaseScore2()
    {
        Score2++;
        Score2UI.text = Score2 +" Score";
    }

    public void IncreaseSpeed1()
    {
        Speed1++;
        Speed1UI.text = "Speed " + Speed1;
    }

    public void IncreaseSpeed2()
    {
        Speed2++;
        Speed2UI.text = Speed2 + " Speed";
    }
}
