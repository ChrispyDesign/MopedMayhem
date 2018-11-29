using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Audio;
using UnityEngine.UI;

public class _TestPauseAudio : MonoBehaviour {

    [SerializeField] AudioClip PauseButtonClickAudio;
    [SerializeField] AudioClip PauseBackClickAudio;
    [SerializeField] AudioMixerGroup PauseMix;

    public Button ResumeButton;
    public Button RestartButton;
    public Button QuitButton;
    public Button OptionsButton;
    public Button ControlButton;

    public Button BackButtonOne;
    public Button BackButtonTwo;

    public AudioSource ResumeAudio;
    public AudioSource RestartAudio;
    public AudioSource QuitAudio;
    public AudioSource OptionsAudio;
    public AudioSource ControlAudio;
    public AudioSource NegativeAudio;

    void Awake()
    {
        RestartButtonOnClick();
        OptionsButtonOnClick();
        QuitButtonOnClick();
        BackButtonOnClick();
        ControlsButtonOnClick();
    }

    void RestartButtonOnClick()
    {
        if (PauseButtonClickAudio != null)
        {
            RestartAudio.clip = PauseButtonClickAudio;
            RestartAudio.outputAudioMixerGroup = PauseMix;
        }
        RestartAudio.playOnAwake = false;
        RestartButton.onClick.AddListener(() => RestartAudio.Play());
    }

    void ResumeButtonOnClick()
    {
        if (PauseButtonClickAudio != null)
        {
            ResumeAudio.clip = PauseButtonClickAudio;
            ResumeAudio.outputAudioMixerGroup = PauseMix;
        }
        ResumeAudio.playOnAwake = false;
        ResumeButton.onClick.AddListener(() => ResumeAudio.Play());
    }

    void OptionsButtonOnClick()
    {
        if (PauseButtonClickAudio != null)
        {
            OptionsAudio.clip = PauseButtonClickAudio;
            OptionsAudio.outputAudioMixerGroup = PauseMix;
        }
        OptionsAudio.playOnAwake = false;
        OptionsButton.onClick.AddListener(() => OptionsAudio.Play());
    }

    void QuitButtonOnClick()
    {
        if (PauseButtonClickAudio != null)
        {
            QuitAudio.clip = PauseButtonClickAudio;
            QuitAudio.outputAudioMixerGroup = PauseMix;
        }
        QuitAudio.playOnAwake = false;
        QuitButton.onClick.AddListener(() => QuitAudio.Play());
    }

    void ControlsButtonOnClick()
    {
        if (PauseButtonClickAudio != null)
        {
            ControlAudio.clip = PauseButtonClickAudio;
            ControlAudio.outputAudioMixerGroup = PauseMix;
        }
        ControlAudio.playOnAwake = false;
        ControlButton.onClick.AddListener(() => ControlAudio.Play());
    }

    void BackButtonOnClick()
    {
        if (PauseBackClickAudio != null)
        {
            NegativeAudio.clip = PauseBackClickAudio;
            NegativeAudio.outputAudioMixerGroup = PauseMix;
        }
        NegativeAudio.playOnAwake = false;
        BackButtonOne.onClick.AddListener(() => NegativeAudio.Play());
        BackButtonTwo.onClick.AddListener(() => NegativeAudio.Play());
    }
}
