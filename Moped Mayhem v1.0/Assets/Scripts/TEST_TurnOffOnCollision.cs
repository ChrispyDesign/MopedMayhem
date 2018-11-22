using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST_TurnOffOnCollision : MonoBehaviour {

    public List<GameObject> m_ThingsToTurnOff;                 // list that stores all that you want to turn off

    // when the player collides with it, turn all those things off
    private void OnTriggerEnter(Collider other)
    {
        foreach (var obj in m_ThingsToTurnOff)
        {
            obj.gameObject.SetActive(false);
        }
    }
}
