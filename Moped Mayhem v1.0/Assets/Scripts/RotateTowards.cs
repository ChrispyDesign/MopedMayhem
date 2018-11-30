// Main Author - Christopher Bowles
//	Alterations by -
//
// Date last worked on 23/11/18

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowards : MonoBehaviour {

    // The object whose rotation we want to match.
    public Transform target;

    // Angular speed in degrees per sec.
    public float speed;

    void Update()
    {
        // The step size is equal to speed times frame time.
        var step = speed * Time.deltaTime;

        // Rotate our transform a step closer to the target's.
        transform.rotation = Quaternion.RotateTowards(transform.rotation, target.rotation, step);
    }
}
