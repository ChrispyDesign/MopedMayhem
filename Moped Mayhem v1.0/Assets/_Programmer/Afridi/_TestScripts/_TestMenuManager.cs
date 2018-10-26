using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class _TestMenuManager : MonoBehaviour {

    public GameObject PlayButton;
    public GameObject OptionsButton;
    public GameObject QuitButton;

    public GameObject CurrentSelec;
    public Button CurrentButton;

    void Awake()
    {
        CurrentSelec = PlayButton;
        CurrentButton = CurrentSelec.GetComponent<Button>();
    }

    void Update () {


        QuitGame();
	}

    void PlayGame() {
        SceneManager.LoadScene(1);
    }

    void OptionsBtn() {

    }

    void QuitGame() {
        // Quits the application if exe file
#if UNITY_STANDALONE
        Application.Quit();
#endif

        // Stops the editor playing if in unity
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    void OptionContents() {

    }
}
