// Main Author - Afridi Rahim
//
// Date last worked on --/--/18

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _TestSelectChar : MonoBehaviour {

    public Toggle FeMale;
    public bool isSwitching = false;

    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        isSwitching = FeMale.isOn;
    }
}
