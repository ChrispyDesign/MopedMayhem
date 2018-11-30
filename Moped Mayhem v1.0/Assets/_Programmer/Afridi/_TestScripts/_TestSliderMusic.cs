// Main Author - Afridi Rahim
//
// Date last worked on --/--/18

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
        MainMixer.SetFloat("MainVolumeController", Mathf.Log10(value) * 20);
    }
    public void SetEffectAudioLevel(float value)
    {
        EffectMixer.SetFloat("EffectController", Mathf.Log10(value) * 20);
    }
}
