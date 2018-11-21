using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Audio;

public class _TestSliderMusic : MonoBehaviour
{
    public AudioMixer MainMixer;
    public AudioMixer EffectMixer;

    public void SetMainAudioLevel(float value)
    {
        MainMixer.SetFloat("MainMusicVol", Mathf.Log10(value) * 20);
    }
    public void SetEffectAudioLevel(float value)
    {
        EffectMixer.SetFloat("ButtonClicks", Mathf.Log10(value) * 20);
    }
}
