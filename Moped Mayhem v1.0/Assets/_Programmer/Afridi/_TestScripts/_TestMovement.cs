using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _TestMovement : MonoBehaviour {

    void Update()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 80.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 10.0f;
        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);

    }
}
