using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

  Rigidbody rb;

  void Start()
  {
    rb = GetComponent<Rigidbody>();
  }

  public void AddForce(float strength)
  {
    rb.AddForce(new Vector3(0, 0, strength));
  }
}
