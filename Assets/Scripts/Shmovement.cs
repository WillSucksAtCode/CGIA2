using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shmovement : MonoBehaviour
{
    private Rigidbody rb;

    public float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        var ForwardDirection = Vector3.back;
        var RightDirection = Vector3.right;

        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(ForwardDirection * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(-ForwardDirection * speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(RightDirection * speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(-RightDirection * speed);
        }
    }

}
