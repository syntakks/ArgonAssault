using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{
    int score;
    Text scoreText; 

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        UpdateScoreBoard(); 
    }

    public void ScoreHit(int points)
    {
        score += points;
        UpdateScoreBoard(); 
    }

    private void UpdateScoreBoard()
    {
        scoreText.text = score.ToString();
    }
}
