using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _AnotherIndicator : MonoBehaviour {

    bool bCurrentlyHoldingFoodl = true;
    public List<GameObject> numberofShops = new List<GameObject>();

    void Update()
    {
        if (bCurrentlyHoldingFoodl == true) {
            foreach (var shop in numberofShops) {

            }

        }
    }
}
