using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _TestMusicController : MonoBehaviour {

    private void Awake()
    {
        // Keeps the GameObject this is attached to persistent through scenes
        GameObject[] obj = GameObject.FindGameObjectsWithTag("Music");
        if (obj.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
