using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public int totalBalls = 3;
    public Text ballsCountText;
    public Text scoreText;
    int score = 0;
    int currentBalls;

    void Start()
    {
        currentBalls = totalBalls;
        ballsCountText.text = "Balls: " + currentBalls;
        scoreText.text = "Score: " + score;
    }

    void Update()
    {
        
    }

    public void IncreaseScore(int score) {
        this.score += score;
        scoreText.text = "Score: " + this.score;
    }
}
