// Main Author - Afridi Rahim
//
// Date last worked on --/--/18

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _AlternativeIndicator : MonoBehaviour
{
    //Target to point at
    public Transform tTarget;
    //Distance till shown
    public float fHideDistance;

    void Update()
    {
        //Direction will be calculated by the distance between the transformation and the target
        var vDir = tTarget.position - transform.position;

        //if the directions length is greater than the hidden distance
        if (vDir.magnitude > fHideDistance)
        {
            //Do not show the pointer
            SetChildrenActive(false);
        }
        //or else
        else {
            //Show the pointer
            SetChildrenActive(true);
            //an angle made to rotate the x and y positions of the directions (This is what allows pointing)
            var vAngle = Mathf.Atan2(vDir.y, vDir.x) * Mathf.Rad2Deg;
            //Transforms the rotation into an angle that rotates through the Z axis
            transform.transform.rotation = Quaternion.AngleAxis(vAngle, Vector3.forward);
        }     
    }

    //This checks how many delivery points are there and whether to enable it or not
    void SetChildrenActive(bool bValue) {
        //Foreach child in the transformatiovs
        foreach (Transform child in transform) {
            //Each child can be set to true (Shown) or false (Invisible)
            child.gameObject.SetActive(bValue);
        }
    }
}
