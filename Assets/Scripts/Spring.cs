using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
  public int springStretchLimit;
  public float stretchForce;
  public float ballForceDivider;
  public float resetSpringTime;
  public GameObject gameController;
  int springCurrentStretch = 0;
  Vector3 initialScale;
  Vector3 initialPosition;

  bool isTouchingBall;

  void Start()
  {
    initialScale = transform.localScale;
    initialPosition = transform.position;
  }

  void Update()
  {
    HandleSpringStretch();
    HandleSpringRelease();
  }

  void HandleSpringStretch()
  {
    if (Input.GetKey(KeyCode.Space) && springCurrentStretch < springStretchLimit)
    {
      Vector3 objectScale = transform.localScale;
      transform.localScale = new Vector3(objectScale.x, objectScale.y, objectScale.z - stretchForce);
      transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - stretchForce / 2f);

      springCurrentStretch++;
    }
  }

  void HandleSpringRelease()
  {
    if (Input.GetKeyUp(KeyCode.Space))
    {
      if (isTouchingBall)
      {
        gameController.GetComponent<GameController>().ball.GetComponent<Ball>().AddForce((float)springCurrentStretch / ballForceDivider);
      }

      springCurrentStretch = 0;

      StartCoroutine("ResetSpring");
    }
  }

  IEnumerator ResetSpring()
  {
    yield return new WaitForSeconds(resetSpringTime);
    transform.localScale = initialScale;
    transform.position = initialPosition;
  }

  private void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.tag == "Ball")
    {
      isTouchingBall = true;
    }
  }

  private void OnCollisionExit(Collision collision)
  {
    if (collision.gameObject.tag == "Ball")
    {
      isTouchingBall = false;
    }
  }
}
