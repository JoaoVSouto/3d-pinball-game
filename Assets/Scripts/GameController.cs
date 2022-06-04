using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

  public int totalBalls = 3;
  public Text ballsCountText;
  public Text scoreText;
  public Text gameOverScoreText;
  public GameObject ball;
  public Transform ballSpawn;
  public GameObject hudScreen;
  public GameObject gameOverScreen;
  int score = 0;
  int currentBalls;

  void Start()
  {
    currentBalls = totalBalls;
    ballsCountText.text = "Balls: " + currentBalls;
    scoreText.text = "Score: " + score;
  }

  public void IncreaseScore(int score)
  {
    this.score += score;
    scoreText.text = "Score: " + this.score;
  }

  public void LostCurrentGame(GameObject ball)
  {
    currentBalls--;
    ballsCountText.text = "Balls: " + currentBalls;

    Destroy(ball);

    bool hasLost = currentBalls < 0;

    GameObject newBall = Instantiate(ball, ballSpawn.position, ballSpawn.rotation);
    this.ball = newBall;

    if (hasLost)
    {
      hudScreen.SetActive(false);
      gameOverScreen.SetActive(true);
      gameOverScoreText.text = scoreText.text;
      Time.timeScale = 0f;
    }
  }

  public void PlayAgain()
  {

    score = 0;
    currentBalls = totalBalls;
    ballsCountText.text = "Balls: " + currentBalls;
    scoreText.text = "Score: " + score;

    hudScreen.SetActive(true);
    gameOverScreen.SetActive(false);

    Time.timeScale = 1f;
  }
}
