using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Audio;
using UnityEngine.UI;

public class _TestButtonAudio : MonoBehaviour
{
    [SerializeField] AudioClip MenuButtonClickAudio;
    AudioSource Audio;
    public Button PlayButton;
    public Button OptionsButton;
    public Button LeaderBButton;
    public Button QuitButton;
    private int Count = 4;


    void Awake()
    {
        PlayButtonOnClick();
        OptionsButtonOnClick();
        LeaderBoardButtonOnClick();
        QuitButtonOnClick();
    }

    void PlayButtonOnClick() {
        Audio = gameObject.AddComponent<AudioSource>();
        if (MenuButtonClickAudio != null)
            Audio.clip = MenuButtonClickAudio;
        Audio.playOnAwake = false;
        PlayButton.onClick.AddListener(() => Audio.Play());
    }

    void OptionsButtonOnClick()
    {
        Audio = gameObject.AddComponent<AudioSource>();
        if (MenuButtonClickAudio != null)
            Audio.clip = MenuButtonClickAudio;
        Audio.playOnAwake = false;
        OptionsButton.onClick.AddListener(() => Audio.Play());
    }

    void LeaderBoardButtonOnClick()
    {
        Audio = gameObject.AddComponent<AudioSource>();
        if (MenuButtonClickAudio != null)
            Audio.clip = MenuButtonClickAudio;
        Audio.playOnAwake = false;
        LeaderBButton.onClick.AddListener(() => Audio.Play());
    }

    void QuitButtonOnClick()
    {
        Audio = gameObject.AddComponent<AudioSource>();
        if (MenuButtonClickAudio != null)
            Audio.clip = MenuButtonClickAudio;
        Audio.playOnAwake = false;
        QuitButton.onClick.AddListener(() => Audio.Play());
    }
}