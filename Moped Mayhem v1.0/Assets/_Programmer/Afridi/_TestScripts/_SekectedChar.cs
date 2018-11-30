using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _SekectedChar : MonoBehaviour {

    public GameObject[] genders = new GameObject[2];
    public _TestGameOptionsManager GOptions;

    private void Awake()
    {
        genders[0].SetActive(false);
        genders[1].SetActive(true);

		bool isFemale = true;

		var fem = GameObject.FindWithTag("Femin");
		_TestSelectChar selectedChar = null;
			selectedChar = fem.GetComponent<_TestSelectChar>();

		if (selectedChar)
		{
			isFemale = selectedChar.isSwitching;
		}

        if (isFemale == true)
        {
            genders[0].SetActive(true);
            genders[1].SetActive(false);
        }
        else {
            genders[0].SetActive(false);
            genders[1].SetActive(true);
        }

		//GOptions.LoadSettings();
    }
}
