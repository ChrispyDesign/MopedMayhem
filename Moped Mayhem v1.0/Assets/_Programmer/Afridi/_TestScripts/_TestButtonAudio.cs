using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Audio;
using UnityEngine.UI;

public class _TestButtonAudio : MonoBehaviour
{
    [SerializeField] AudioClip MenuButtonClickAudio;
    [SerializeField] AudioClip MenuBackClickAudio;
    [SerializeField] AudioMixerGroup AudioMix;

    public Button PlayButton;
    public Button OptionsButton;
    public Button LeaderBButton;
    public Button QuitButton;

    public Button BackButtonOne;
    public Button BackButtonTwo;
    public Button BackButtonThree;
    public Button BackButtonFour;

    public AudioSource PlayAudio;
    public AudioSource OptionsAudio;
    public AudioSource LBoardAudio;
    public AudioSource QuitAudio;
    public AudioSource NegativeAudio;

    private int Count = 4;

    void Awake()
    {
        PlayButtonOnClick();
        OptionsButtonOnClick();
        LeaderBoardButtonOnClick();
        QuitButtonOnClick();
        BackButtonOnClick();
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

    void BackButtonOnClick()
    {
        if (MenuBackClickAudio != null)
        {
            NegativeAudio.clip = MenuBackClickAudio;
            NegativeAudio.outputAudioMixerGroup = AudioMix;
        }
        NegativeAudio.playOnAwake = false;
        BackButtonOne.onClick.AddListener(() => NegativeAudio.Play());
        BackButtonTwo.onClick.AddListener(() => NegativeAudio.Play());
        BackButtonThree.onClick.AddListener(() => NegativeAudio.Play());
        BackButtonFour.onClick.AddListener(() => NegativeAudio.Play());
    }
}