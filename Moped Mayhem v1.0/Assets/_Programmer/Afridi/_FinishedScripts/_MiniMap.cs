using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class _MiniMap : MonoBehaviour {

    //Two Rectangular Transformation, one for the Small Mini-Map and the other for the Large Mini-Map
    public RectTransform miniMapS;
    public RectTransform miniMapL;

    //Two Raw Image's are used, one for the Small Mini-Map and the other for the Large Mini-Map
    public RawImage imgS;
    public RawImage imgL;

    //Two Camera's are used, one for the Small Mini-Map and the other for the Large Mini-Map
    public Camera miniMapSml;
    public Camera miniMapLrg;

    //Constant Z value so that the z position doesn't change
    const float fZ = 0f;

    //All Startup Variables are done through here 
    void Start()
    {
        //Small Minimap is enabled first whilst the large Minimap is disabled
        miniMapSml.enabled = true;
        miniMapLrg.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //On Keypress 
        if (Input.GetKeyDown("space"))
        {
            //The Large Image's Alpha Colour is reduced
            Color c = imgL.color;
            c.a = 0.8f;
            imgL.color = c;

            //Small MiniMap is disabled and the Large Minimap is Enabled
            miniMapSml.enabled = false;
            miniMapLrg.enabled = true;

            imgL.rectTransform.sizeDelta = new Vector2(1007, 536);
            imgL.transform.position = new Vector3(496, 265, fZ);
            imgS.enabled = false;
            imgL.enabled = true;
        }
        if (Input.GetKeyUp("space"))
        {

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
