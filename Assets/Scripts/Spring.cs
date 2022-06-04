using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
  public int springStretchLimit;
  public float stretchForce;
  public float ballForceDivider;
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
        GameObject.FindGameObjectWithTag("Ball").GetComponent<Ball>().AddForce((float)springCurrentStretch / ballForceDivider);
      }

      springCurrentStretch = 0;

      StartCoroutine("ResetSpring");
    }
  }

  IEnumerator ResetSpring()
  {
    yield return new WaitForSeconds(0.01f);
    transform.localScale = initialScale;
    transform.position = initialPosition;
  }

  private void OnCollisionEnter(Collision collision)
  {
    isTouchingBall = true;
  }

  private void OnCollisionExit(Collision collision)
  {
    isTouchingBall = false;
  }
}
