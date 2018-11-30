// Main Author - Afridi Rahim
//
// Date last worked on --/--/18

using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class _TestScreenResEdit : MonoBehaviour {

    Resolution[] resolutions;
    public Dropdown dropdownMenu;
    void Start()
    {
        resolutions = Screen.resolutions;
        
        for (int i = 0; i < resolutions.Length; i++)
        {
            dropdownMenu.options.Add(new Dropdown.OptionData(dropdownMenu.options[i].text));
            dropdownMenu.value = i;
            dropdownMenu.options[i].text = ResToString(resolutions[i]);
            dropdownMenu.onValueChanged.AddListener(delegate { Screen.SetResolution(resolutions[dropdownMenu.value].width, resolutions[dropdownMenu.value].height, false, 60); });
        }
    }

    private void Update()
    {
        Debug.Log(Screen.currentResolution);
    }

    string ResToString(Resolution res)
    {
        return res.width + " x " + res.height;
    }
}
