using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rb;
    public float speedScale = 200f;
    public float sideSpeed = 100f;

    public void Start()
    {
        rb.isKinematic = true;
        rb.isKinematic = false;
        rb.AddForce(transform.forward * speedScale);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-transform.right * sideSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(transform.right * sideSpeed * Time.deltaTime);
        }
    }
}
