// Main Author - Afridi Rahim
// Last Worked On - 19/10/2018
/* Alterations - 
 * Implementations: Make the Position Changes Public Variables: COMPLETED
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class _MiniMap : MonoBehaviour {

    //Two Rectangular Transformation, one for the Small Mini-Map and the other for the Large Mini-Map
    public RectTransform m_SmlMiniMap;
    public RectTransform m_LrgMiniMap;

    //Two Raw Image's are used, one for the Small Mini-Map and the other for the Large Mini-Map
    public RawImage m_SmlImg;
    public RawImage m_LrgImg;

    //Two Camera's are used, one for the Small Mini-Map and the other for the Large Mini-Map
    public Camera c_SmlMiniMap;
    public Camera c_LrgMiniMap;

    //Position and Image size locations for Mini Map
    public RectTransform v_LrgImageLocation;

    //Position and Image size locations for Mini Map
    public RectTransform v_SmlImageLocation;

    //All Startup Variables are done through here 
    void Start()
    {
        //Small Minimap is enabled first whilst the large Minimap is disabled
        c_SmlMiniMap.enabled = true;
        c_LrgMiniMap.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //On Keypress 
        if (Input.GetKeyDown("space"))
        {
            //The Large Image's Alpha Colour is reduced
            Color c = m_LrgImg.color;
            c.a = 0.8f;
            m_LrgImg.color = c;

            //Small MiniMap is disabled and the Large Minimap is Enabled
            c_SmlMiniMap.enabled = false;
            c_LrgMiniMap.enabled = true;

			//Changes the size of the Large image 
			m_LrgImg.rectTransform.sizeDelta = v_LrgImageLocation.sizeDelta;
            //Changes the posiition of the Large Image
            m_LrgImg.transform.position = v_LrgImageLocation.position;
            //Enables the Large Mini Map and disables the Small Mini Map
            m_SmlImg.enabled = false;
            m_LrgImg.enabled = true;
        }
        //On Keypress 
        if (Input.GetKeyUp("space"))
        {
            //The Small Image's Alpha Colour is reduced
            Color c = m_SmlImg.color;
            c.a = 1f;
            m_SmlImg.color = c;

            //Small MiniMap is enabled and the Large Minimap is disabled
            c_SmlMiniMap.enabled = true;
            c_LrgMiniMap.enabled = false;

			//Changes the size of the Large image 
			m_LrgImg.rectTransform.sizeDelta = v_SmlImageLocation.sizeDelta;
            //Changes the posiition of the Large Image
            m_LrgImg.transform.position = v_SmlImageLocation.position;
            //Disables the Large Mini Map and Enables the Small Mini Map
            m_SmlImg.enabled = true;
            m_LrgImg.enabled = false;
        }
    }
}
