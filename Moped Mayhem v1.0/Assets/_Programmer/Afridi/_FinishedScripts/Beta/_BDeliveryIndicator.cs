// Main Author - Afridi Rahim
// Last Worked On - 25/10/2018
/* Alterations - Made a second Icon for the food to be on the Indicator : Completed
 *             - Arrow Rotates to Object : Completed
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class _BDeliveryIndicator : MonoBehaviour {

    private Camera m_MainCamera;
    private RectTransform m_Icon;
    private RectTransform m_FoodIcon;
    public RawImage m_IconImage;
    public RawImage m_FoodImage;
    private Canvas m_MainCanvas;

    public Texture m_TargetIconOnScreen;
    public Texture m_TargetIconForFood;

    [Space]
    [Range(0, 100)]
    public float f_EdgeBuffer;
    public Vector3 m_targetIconScale;
    public Vector3 m_foodIconScale;
    [Space]
    public bool bPoint2Target = true;
    //Indicates if the object is out of the screen
    private bool bOutOfScreen;
    void Awake()
    {
        m_MainCamera = Camera.main;
        m_MainCanvas = FindObjectOfType<Canvas>();
        Debug.Assert((m_MainCanvas != null), "No Canvas Attatched");
        InstainateTargetIcon();
    }
    void FixedUpdate()
    {
        UpdateTargetIconPosition();
    }

    private void InstainateTargetIcon()
    {
        m_Icon = new GameObject().AddComponent<RectTransform>();
        m_Icon.transform.SetParent(m_MainCanvas.transform);
        m_Icon.localScale = m_targetIconScale;
        m_Icon.name = name + "SIndicator";
        m_IconImage = m_Icon.gameObject.AddComponent<RawImage>();
        m_IconImage.texture = m_TargetIconOnScreen;

        m_FoodIcon = new GameObject().AddComponent<RectTransform>();
        m_FoodIcon.transform.SetParent(m_MainCanvas.transform);
        m_FoodIcon.localScale = m_foodIconScale;
        m_FoodIcon.name = name + "FIndicator";
        m_FoodImage = m_FoodIcon.gameObject.AddComponent<RawImage>();
        m_FoodImage.texture = m_TargetIconForFood;
    }
    private void UpdateTargetIconPosition()
    {
        Vector3 newPos = transform.position;
        newPos = m_MainCamera.WorldToViewportPoint(newPos);
        //Simple check if the target object is out of the screen or insidewd
        if (newPos.x > 1 || newPos.y > 1 || newPos.x < 0 || newPos.y < 0)
            bOutOfScreen = true;
        else
            bOutOfScreen = false;
        if (newPos.z < 0)
        {
            newPos.x = 1f - newPos.x;
            newPos.y = 1f - newPos.y;
            newPos.z = 0;
            newPos = Vector3Maxamize(newPos);
        }
        newPos = m_MainCamera.ViewportToScreenPoint(newPos);
        newPos.x = Mathf.Clamp(newPos.x, f_EdgeBuffer, Screen.width - f_EdgeBuffer);
        newPos.y = Mathf.Clamp(newPos.y, f_EdgeBuffer, Screen.height - f_EdgeBuffer);
        newPos.z = 0f;
        m_Icon.transform.position = newPos;
        m_FoodIcon.transform.position = newPos;
        //Operations if the object is out of the screen
        if (bOutOfScreen)
        {
            //Show the target off screen icon
            m_IconImage.texture = m_TargetIconOnScreen;
            m_FoodImage.texture = m_TargetIconForFood;

            if (bPoint2Target)
            {
                //Rotate the texture towards the target object
                var targetPosLocal = m_MainCamera.transform.InverseTransformPoint(transform.position);
                var targetAngle = -Mathf.Atan2(targetPosLocal.x, targetPosLocal.y) * Mathf.Rad2Deg - 360.0f;
                //Apply rotation
                m_Icon.transform.eulerAngles = new Vector3(0, 0, targetAngle);
            }

        }
        else
        {
            //Reset rotation to zero and swap the texture to the "on screen" one
            m_Icon.transform.eulerAngles = new Vector3(0, 0, 0);
            m_FoodIcon.transform.eulerAngles = new Vector3(0, 0, 0);
            m_IconImage.texture = m_TargetIconOnScreen;
            m_FoodImage.texture = m_TargetIconForFood;
        }

    }
    public Vector3 Vector3Maxamize(Vector3 vector)
    {
        Vector3 returnVector = vector;
        float max = 0;
        max = vector.x > max ? vector.x : max;
        max = vector.y > max ? vector.y : max;
        max = vector.z > max ? vector.z : max;
        returnVector /= max;
        return returnVector;
    }
    }
