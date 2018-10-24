using UnityEngine;
using UnityEngine.UI;
public class _3rdPartScript : MonoBehaviour
{
    private Camera m_MainCamera;
    private RectTransform m_Icon;
    private RectTransform m_FoodIcon;
    private RawImage m_IconImage;
    private RawImage m_FoodImage;
    private Canvas m_MainCanvas;

    public Texture m_targetIconOffScreen;
    public Texture m_targetIconOnScreen;
    [Space]
    [Range(0, 100)]
    public float f_EdgeBuffer;
    public Vector3 m_targetIconScale;
    [Space]
    public bool bPoint2Target = true;
    //Indicates if the object is out of the screen
    private bool bOutOfScreen;
    void Start()
    {
        m_MainCamera = Camera.main;
        m_MainCanvas = FindObjectOfType<Canvas>();
        Debug.Assert((m_MainCanvas != null), "There needs to be a Canvas object in the scene for the OTI to display");
        InstainateTargetIcon();
    }
    void Update()
    {
        UpdateTargetIconPosition();
    }
    private void InstainateTargetIcon()
    {
        m_Icon = new GameObject().AddComponent<RectTransform>();
        m_Icon.transform.SetParent(m_MainCanvas.transform);
        m_Icon.localScale = m_targetIconScale;
        m_Icon.name = name + ": OTI icon";
        m_IconImage = m_Icon.gameObject.AddComponent<RawImage>();
        m_IconImage.texture = m_targetIconOffScreen;
    }
    private void UpdateTargetIconPosition()
    {
        Vector3 newPos = transform.position;
        newPos = m_MainCamera.WorldToViewportPoint(newPos);
        //Simple check if the target object is out of the screen or inside
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
        m_Icon.transform.position = newPos;
        //Operations if the object is out of the screen
        if (bOutOfScreen)
        {
            //Show the target off screen icon
            m_IconImage.texture = m_targetIconOffScreen;
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
            m_IconImage.texture = m_targetIconOffScreen;
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
