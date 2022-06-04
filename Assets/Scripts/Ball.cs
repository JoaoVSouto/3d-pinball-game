using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
  public float ballStrength;

  private Vector3 oldPosition;

  Rigidbody rb;

  void Start()
  {
    rb = GetComponent<Rigidbody>();
  }

  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Space))
    {
      rb.AddForce(new Vector3(0, 0, ballStrength));
    }
  }

  public float GetSpeed()
  {
    float speed = Vector3.Distance(oldPosition, transform.position);
    oldPosition = transform.position;

    return speed;
  }
}
