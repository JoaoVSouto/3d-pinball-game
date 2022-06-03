using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightFlipper : MonoBehaviour
{
    public float flipperStrength = 1000f;
    Rigidbody rb;
    HingeJoint hinge;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        hinge = GetComponent<HingeJoint>();
        
    }

    void Update()
    {
        print(hinge.angle);
        if (Input.GetKeyDown(KeyCode.D))
        {
            rb.AddForce(new Vector3(0, flipperStrength, 0));
        }   
    }
}
