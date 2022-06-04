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

  int GetScore()
  {
    switch (type)
    {
      case Type.Green:
        return 12;
      case Type.Yellow:
        return 27;
      case Type.Pink:
        return 34;
      case Type.Blue:
        return 41;
      default:
        return 0;
    }
  }

  float GetStrength()
  {
    switch (type)
    {
      case Type.Green:
        return 1.2f;
      case Type.Yellow:
        return 1.4f;
      case Type.Pink:
        return 1.6f;
      case Type.Blue:
        return 1.2f;
      default:
        return 0;
    }
  }

  void OnCollisionEnter(Collision other)
  {
    if (other.gameObject.tag == "Ball")
    {
      gameController.GetComponent<GameController>().IncreaseScore(GetScore());
      if (type == Type.Blue)
      {
        other.gameObject.GetComponent<Ball>().PullByTangent(GetStrength());
      }
      else
      {
        other.gameObject.GetComponent<Ball>().Pull(GetStrength());
      }
    }
  }
}
