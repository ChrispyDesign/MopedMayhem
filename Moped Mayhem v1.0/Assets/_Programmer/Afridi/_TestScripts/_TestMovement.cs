using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _TestMovement : MonoBehaviour {


    //creates a variable to store the character controller component we just made but doesn’t expose it in the inspector because we made it private.
    private CharacterController control;
    public float speed = 5.0f;

    // Use this for initialization
    void Start()
    {
        //gets the CharacterController sub component of this object and assigns it to our controller variable
        control = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        //Will Move the Character in the direction of the vector we pass it into
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            control.transform.Translate(Vector3.back * speed);
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            control.transform.Translate(Vector3.right * speed); ;
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            control.transform.Translate(Vector3.forward * speed);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            control.transform.Translate(Vector3.left * speed);
        }
    }
}
