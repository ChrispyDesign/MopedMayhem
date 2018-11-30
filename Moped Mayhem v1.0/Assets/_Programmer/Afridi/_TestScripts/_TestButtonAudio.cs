// Main Author - Afridi Rahim
//
// Date last worked on --/--/18

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
    public Button ControlButton;
    public Button CreditsButton;

    public Button BackButtonOne;
    public Button BackButtonTwo;
    public Button BackButtonThree;
    public Button BackButtonFour;
    public Button BackButtonFive;
    public Button BackButtonSix;

    public AudioSource PlayAudio;
    public AudioSource OptionsAudio;
    public AudioSource LBoardAudio;
    public AudioSource CreditsAudio;
    public AudioSource ControlAudio;
    public AudioSource QuitAudio;
    public AudioSource NegativeAudio;

    void Awake()
    {
        PlayButtonOnClick();
        OptionsButtonOnClick();
        LeaderBoardButtonOnClick();
        QuitButtonOnClick();
        BackButtonOnClick();
        CreditsButtonOnClick();
        ControlsButtonOnClick();
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

    void CreditsButtonOnClick()
    {
        if (MenuButtonClickAudio != null)
        {
            CreditsAudio.clip = MenuButtonClickAudio;
            CreditsAudio.outputAudioMixerGroup = AudioMix;
        }
        CreditsAudio.playOnAwake = false;
        CreditsButton.onClick.AddListener(() => CreditsAudio.Play());
    }

    void ControlsButtonOnClick()
    {
        if (MenuButtonClickAudio != null)
        {
            ControlAudio.clip = MenuButtonClickAudio;
            ControlAudio.outputAudioMixerGroup = AudioMix;
        }
        ControlAudio.playOnAwake = false;
        ControlButton.onClick.AddListener(() => ControlAudio.Play());
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