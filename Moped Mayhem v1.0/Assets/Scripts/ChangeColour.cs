using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColour : MonoBehaviour {

    public GameObject m_FoodItem;                               // stores the game object with the colour on it
    private Color m_FoodColour;                                 // stores the hex code of the colour
    private SpriteRenderer m_ThisSpriteRenderer;                // stores the sprite renderer of this sprite
    [Range(0, 255)]
    public int m_nAlphaValue = 0;                             // after changing colour, this float is what the alpha will be set to
    //private Color m_ThisColour;                               // the colour after being set

	// Use this for initialization
	void Start () {
        m_ThisSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();                                                   // grabs the sprite rendererer off this game object
        m_FoodColour = m_FoodItem.GetComponent<Food>().m_TicketColor;                                                       // grabs the colour of the m_FoodItem
        m_ThisSpriteRenderer.color = new Vector4(m_FoodColour.r, m_FoodColour.g, m_FoodColour.b, m_nAlphaValue);            // feeds this colour back to the sprite renderer's colour
        Debug.Log(m_nAlphaValue);
        //m_ThisSpriteRenderer.color = m_FoodColour;                                                                        // sets the colour of this sprite to that of the food item.
        //m_ThisColour = m_ThisSpriteRenderer.color;                                                                        // sets ThisColour to be the new colour
        //m_ThisColour.a = m_AlphaValue;                                                                                    // tweaks the Alpha of ThisColour
        
        
        //m_ThisColour = m_ThisSpriteRenderer.color;
        //m_ThisColour.a = m_AlphaValue;                                      // sets the Alpha of the colour
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
