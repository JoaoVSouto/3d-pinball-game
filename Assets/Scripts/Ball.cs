using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

  Rigidbody rb;
  public float speedLimit;

  const float UPPER_LIMIT = 1.2f;

  void Start()
  {
    rb = GetComponent<Rigidbody>();
  }

  void Update()
  {
    LimitBallOnUpperSide();
    LimitBallVelocity();
  }

  void LimitBallOnUpperSide()
  {
    if (transform.position.y >= UPPER_LIMIT)
    {
      transform.position = new Vector3(transform.position.x, UPPER_LIMIT, transform.position.z);
    }
  }
  void LimitBallVelocity()
  {
    if (rb.velocity.magnitude > speedLimit)
    {
      rb.velocity = rb.velocity.normalized * speedLimit;
    }
  }

  public void AddForce(float strength)
  {
    rb = GetComponent<Rigidbody>();
    rb.AddForce(new Vector3(0, 0, strength));
  }

  public void Pull(float strength)
  {
    rb.velocity *= strength;
  }

  public void PullByTangent(float strength)
  {
    rb.velocity = Vector3.Reflect(rb.velocity, transform.forward);
    rb.velocity *= strength;
  }
}
