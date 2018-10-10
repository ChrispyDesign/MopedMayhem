using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempPlayerMovement : MonoBehaviour
{
    [Range(0, 100)]
    public float speed = 5;
    [Range(0, 100)]
    public float rotSpeed = 3;
    [Range(0, 10)]
    public float baseAngularDrag = 5;

    [Range(0, 10)]
    public float extraAngularDrag = 5;

    [Range(0, 10)]
    public float multiplier = 10;

    int nThisIsAnInt;

    public Rigidbody rb;

    // Update is called once per frame
    void Update ()
    {
        rb.angularDrag = baseAngularDrag + (rb.velocity.magnitude / rb.maxAngularVelocity) * extraAngularDrag;

        if (Input.GetKey(KeyCode.W))
        {
            Vector3 impulse = rb.transform.forward * speed * multiplier * Time.deltaTime;
            rb.AddForce(impulse, ForceMode.Impulse);
        }

        if (Input.GetKey(KeyCode.S))
        {
            Vector3 impulse = -rb.transform.forward * speed * multiplier * Time.deltaTime;
            rb.AddForce(impulse, ForceMode.Impulse);
        }

        if (Input.GetKey(KeyCode.A))
        {
            
            float torque = -rotSpeed * multiplier * Time.deltaTime;
            rb.AddTorque(0, torque, 0, ForceMode.Impulse);
        }

        if (Input.GetKey(KeyCode.D))
        {
            float torque = rotSpeed * multiplier * Time.deltaTime;
            rb.AddTorque(0, torque, 0, ForceMode.Impulse);
        }
	}
}
