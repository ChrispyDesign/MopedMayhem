using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _TestSelectChar : MonoBehaviour {

    public Toggle Male;
    public Toggle FeMale;
    public GameObject MMoped;
    public GameObject FMoped;

    public void Awake()
    {
        MMoped = GameObject.Find("Player");
        FMoped = GameObject.Find("Femin");
    }

    public void Start()
    {
        MMoped.SetActive(true);
        FMoped.SetActive(false);
    }

    private void Update()
    {
        PickPlayer();      
    }

    public void PickPlayer()
    {
        // afridi can suck salted nuts
        if (Male.isOn) {
            MMoped.SetActive(true);
            FMoped.SetActive(false);
        }

        if (FeMale.isOn) {
            MMoped.SetActive(false);
            FMoped.SetActive(true);
        }
    }
}
