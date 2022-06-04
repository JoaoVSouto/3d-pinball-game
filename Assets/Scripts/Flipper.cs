using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour
{
  public enum Side { Left, Right };
  public Side side;
  public float flipperStrength = 1000f;

  Rigidbody rb;


  void Start()
  {
    rb = GetComponent<Rigidbody>();
  }

  UnityEngine.KeyCode GetKeyBySide()
  {
    switch (side)
    {
      case Side.Left:
        return KeyCode.A;
      case Side.Right:
        return KeyCode.D;
      default:
        return 0;
    }
  }

  bool IsOnInterval()
  {
    if (side == Side.Left)
    {
      return transform.rotation.z >= -0.12f;
    }
    else if (side == Side.Right)
    {
      return transform.rotation.z <= 0.12f;
    }
    else
    {
      return false;
    }
  }

  void Update()
  {
    if (Input.GetKey(GetKeyBySide()) && IsOnInterval())
    {
      rb.AddForce(new Vector3(0, flipperStrength, 0));
    }
  }
}
