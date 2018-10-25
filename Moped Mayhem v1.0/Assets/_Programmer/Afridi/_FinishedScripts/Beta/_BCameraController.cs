using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _BCameraController : MonoBehaviour {
    public float xspeed = 0.0f;
    public float yspeed = 0.0f;
    public float zspeed = 0.0f;

    void Update()
    {
        transform.Rotate(
             xspeed * Time.deltaTime,
             yspeed * Time.deltaTime,
             zspeed * Time.deltaTime
        );
    }
}
