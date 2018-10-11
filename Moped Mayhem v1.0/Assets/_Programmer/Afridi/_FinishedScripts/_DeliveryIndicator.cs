// Main Author - Afridi Rahim
// Last Worked On - 11/10/2018
/* Alterations - 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class _DeliveryIndicator : MonoBehaviour {

    //Variables that control the camera and its offset and image transformation 
    private Camera m_MainCamera;
    private RectTransform m_Icon;
    private Image m_IconImage;
    private Canvas m_MainCanvas;
    private Vector3 m_CameraOffsetUp;
    private Vector3 m_CameraOffsetRight;
    private Vector3 m_CameraOffsetForward;

    //The Two Sprites that show's the icons depending if they are off or on screen
    public Sprite m_TargetIconOnScreen;
    public Sprite m_TargetIconOffScreen;

    //Used to set a minimum and maximum the edgebuffer and scale can go to
    [Range(0, 100)]
    public float f_EdgeBuffer;
    public Vector3 m_targetIconScale;

    //On Startup
    void Start()
    {
        //Set To Main Camera in Game
        m_MainCamera = Camera.main;
        //Finds A Canvas in the game and applys it
        m_MainCanvas = FindObjectOfType<Canvas>();
        //If there is no Canvas, pop a message saying we need one
        Debug.Assert((m_MainCanvas != null), "Need A Canvas To Operate");
        //Calls the Instantiate Function
        InstainateTargetIcon();
    }

    //For Each Interval
    void Update()
    {
        //Updates Icon's Position
        UpdateTargetIconPosition();
    }

    //This Function Creates and sets up the Indicator Icon
    private void InstainateTargetIcon()
    {
        //Set's the Icon as a new GameObject
        m_Icon = new GameObject().AddComponent<RectTransform>();
        //Set's the image onto the Main Canvas
        m_Icon.transform.SetParent(m_MainCanvas.transform);
        //Set's the scale of the icon through the input scale in the inspector
        m_Icon.localScale = m_targetIconScale;
        //Set's the Name of the Indicator
        m_Icon.name = name + "Indicator";
        //Adds's an Image onto the Icon
        m_IconImage = m_Icon.gameObject.AddComponent<Image>();
        //Sets the default image to be the the indicator on screen
        m_IconImage.sprite = m_TargetIconOnScreen;
    }

    //This Updates the icon's position for each time the player is rotated by
    private void UpdateTargetIconPosition()
    {
        //Created a new position that tranforms each interval to find the icon within the scene
        Vector3 newPos = transform.position;
        //Sets the New position to the camera which turns it into a viewport display
        newPos = m_MainCamera.WorldToViewportPoint(newPos);

        //if the new position's Z is less than 0
        if (newPos.z < 20) {
            //Set the New Position's axis to subtract by 1f
            newPos.x = 1f - newPos.x;
            newPos.y = 1f - newPos.y;

            //Makes the new pos become a 3-D Vector
            newPos = Vector3Maxamize(newPos);

            //Sprite Changes to the image off-screen
            m_IconImage.sprite = m_TargetIconOffScreen;
        }
        else //Or Else
        {
            //Changes the sprite 
            m_IconImage.sprite = m_TargetIconOnScreen;
        }

        //Sets the New position to the camera which turns it into a Screenpoint display
        newPos = m_MainCamera.ViewportToScreenPoint(newPos);
        //Fixes the new position x onto the edge of the screen's width
        newPos.x = Mathf.Clamp(newPos.x, f_EdgeBuffer, Screen.width - f_EdgeBuffer);
        //Fixes the new position y onto the edge of the screen's height
        newPos.y = Mathf.Clamp(newPos.y, f_EdgeBuffer, Screen.height - f_EdgeBuffer);
        //Transforms the icon's positon using the new position
        m_Icon.transform.position = newPos;
        Debug.Log(m_Icon.transform.position);
    }

    //Returns a 3-D Vector that is made up of the largest components of the two specified 3-D vectors
    public Vector3 Vector3Maxamize(Vector3 vector)
    {
        //Returning vector is the vector inputed
        Vector3 returnVector = vector;
        //Default max of the vector is 0
        float max = 0;

        //if Vector's X is greater than maximum size, then the vector's X becomes the maximum size
        max = vector.x > max ? vector.x : max;
        //if Vector's Y is greater than maximum size, then the vector's Y becomes the maximum size
        max = vector.y > max ? vector.y : max;
       

        //Divides the vector with max
        returnVector /= max;

        //Returns the Vector
        return returnVector;
    }
}
