using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

  public GameObject gameController;
  public enum Type
  {
    Green, Yellow, Pink, Blue
  };
  public Type type;

  void OnCollisionEnter(Collision other)
  {
    if (other.gameObject.tag == "Ball")
    {
      gameController.GetComponent<GameController>().IncreaseScore(1);
      other.gameObject.GetComponent<Ball>().Pull(1.2f);
    }
  }
}
