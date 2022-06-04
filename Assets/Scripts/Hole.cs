using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
  public GameObject gameController;

  void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.tag == "Ball")
    {
      gameController.GetComponent<GameController>().LostCurrentGame(other.gameObject);
    }
  }
}
