using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class _MiniMapSize : MonoBehaviour {

    public RectTransform miniMap;
    public RawImage img;
    public Camera FOV;
    const float fZ = 0f;

    void Start()
    {
       
        
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown("space"))
        {
            Color c = img.color;
            c.a = 0.8f;
            img.color = c;
            miniMap.sizeDelta = new Vector2(2560, 1440);
            miniMap.transform.position = new Vector3(574, 254, fZ);
            FOV.orthographicSize = 160f;
        }
        if (Input.GetKeyUp("space")) {
            Color c = img.color;
            c.a = 1f;
            img.color = c;
            miniMap.sizeDelta = new Vector2(400, 225);
            miniMap.transform.position = new Vector3(974, 94, fZ);
            FOV.orthographicSize = 12.30658f;
        }
	}
}
