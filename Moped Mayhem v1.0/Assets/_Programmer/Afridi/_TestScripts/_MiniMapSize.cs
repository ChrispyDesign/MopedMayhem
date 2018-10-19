using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class _MiniMapSize : MonoBehaviour {

    public RectTransform miniMapS;
    public RawImage imgS;
    public RectTransform miniMapL;
    public RawImage imgL;

    public Camera miniMapSml;
    public Camera miniMapLrg;

    const float fZ = 0f;

    void Start()
    {
        miniMapSml.enabled = true;
        miniMapLrg.enabled = false;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown("space"))
        {
            Color c = imgL.color;
            c.a = 0.8f;
            imgL.color = c;

            miniMapSml.enabled = false;
            miniMapLrg.enabled = true;

            imgL.rectTransform.sizeDelta = new Vector2(1920, 1080);
            imgL.transform.position = new Vector3(896, 510, fZ);
            imgS.enabled = false;
            imgL.enabled = true;
        }
        if (Input.GetKeyUp("space")) {

            Color c = imgS.color;
            c.a = 1f;
            imgS.color = c;

            miniMapSml.enabled = true;
            miniMapLrg.enabled = false;

            imgL.rectTransform.sizeDelta = new Vector2(400, 225);
            imgL.transform.position = new Vector3(974, 94, fZ);
            imgS.enabled = true;
            imgL.enabled = false;
        }
	}
}
