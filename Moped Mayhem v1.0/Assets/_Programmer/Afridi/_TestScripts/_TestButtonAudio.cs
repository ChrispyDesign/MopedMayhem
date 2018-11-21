using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Audio;
using UnityEngine.UI;

public class _TestButtonAudio : MonoBehaviour
{
    [SerializeField] AudioClip MenuButtonClickAudio;
    [SerializeField] AudioMixerGroup AudioMix;

    public Button PlayButton;
    public Button OptionsButton;
    public Button LeaderBButton;
    public Button QuitButton;

    public AudioSource PlayAudio;
    public AudioSource OptionsAudio;
    public AudioSource LBoardAudio;
    public AudioSource QuitAudio;

    private int Count = 4;

    void Awake()
    {
        PlayButtonOnClick();
        OptionsButtonOnClick();
        LeaderBoardButtonOnClick();
        QuitButtonOnClick();
    }

    void PlayButtonOnClick() {
        if (MenuButtonClickAudio != null)
        {
            PlayAudio.clip = MenuButtonClickAudio;
            PlayAudio.outputAudioMixerGroup = AudioMix;
        }
        PlayAudio.playOnAwake = false;
        PlayButton.onClick.AddListener(() => PlayAudio.Play());
    }

    void OptionsButtonOnClick()
    {
        if (MenuButtonClickAudio != null)
        {
            OptionsAudio.clip = MenuButtonClickAudio;
            OptionsAudio.outputAudioMixerGroup = AudioMix;
        }
        OptionsAudio.playOnAwake = false;
        OptionsButton.onClick.AddListener(() => OptionsAudio.Play());
    }

    void LeaderBoardButtonOnClick()
    {
        if (MenuButtonClickAudio != null)
        {
            LBoardAudio.clip = MenuButtonClickAudio;
            LBoardAudio.outputAudioMixerGroup = AudioMix;
        }
        LBoardAudio.playOnAwake = false;
         LeaderBButton.onClick.AddListener(() => LBoardAudio.Play());
    }   

    void QuitButtonOnClick()
    {
        if (MenuButtonClickAudio != null)
        {
            QuitAudio.clip = MenuButtonClickAudio;
            QuitAudio.outputAudioMixerGroup = AudioMix;
        }
        QuitAudio.playOnAwake = false;
        QuitButton.onClick.AddListener(() => QuitAudio.Play());
    }
}