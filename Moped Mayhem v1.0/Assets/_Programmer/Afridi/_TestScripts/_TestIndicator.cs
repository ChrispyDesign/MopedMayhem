using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _TestIndicator : MonoBehaviour {

    //The pointer
    RectTransform m_RectTransform;
    //Main Camera in use
    Camera cMainCamera;
    //The Player
    public GameObject Player;
    //Current target (Delivery Point)
    public Transform tCurrentTarget;
    //Attach and stay to screen
    public bool bClampToScreen = true;
    //Checks the size of the screen to clamp
    [SerializeField] Vector2 vClampBorderSize;
    //Pivot Point of the pointer
    public Vector3 vOffset;

    //This is intialised before anything else
    void Awake() {
        //Grabs all libraries within RectTransform
        m_RectTransform = GetComponent<RectTransform>();
        //Sets cMainCamera to be the main camera we use
        cMainCamera = Camera.main;
    }

    //This sets all the code to be done every frame
    void FixedUpdate() {
        //If the player's Z or X position is less or equal to 10 then
        if (Player.transform.position.z <= 10 || Player.transform.position.x <= 10)
        {
            //This sets up a position within the program to fix itself to the main screen
            Vector3 vHaveClampPosition = cMainCamera.WorldToScreenPoint(tCurrentTarget.position + vOffset);
            //This edits the previous clamp position and sets all thier positions.
            Vector3 vCurrentlyClamped = new Vector3
                //This Vector3 X position is clamped to the screen's width and bordersize subtracted together
                (Mathf.Clamp(vHaveClampPosition.x, 0 + vClampBorderSize.x, Screen.width - vClampBorderSize.x),
                //This Vector3 Y position is clamped to the screen's height and bordersize subtracted together
                Mathf.Clamp(vHaveClampPosition.y, 0 + vClampBorderSize.y, Screen.height - vClampBorderSize.y),
                //This Vector3 Z position is left as it is with the previous clamp position
                vHaveClampPosition.z);

            //
            m_RectTransform.position = bClampToScreen ? vCurrentlyClamped : vHaveClampPosition;
        }
        //Or else
        else {

            //Sets the position to the Vector3 Coordinates of choosing
            m_RectTransform.position = new Vector3(-518, -329, 0);
        }
        
    }
}
