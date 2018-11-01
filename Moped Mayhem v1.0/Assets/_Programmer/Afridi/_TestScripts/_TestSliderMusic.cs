using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class _TestSliderMusic : MonoBehaviour
{
    public AudioMixer MainMixer;
    public AudioMixer EffectMizer;

    public void SetMainAudioLevel(float value)
    {
        MainMixer.SetFloat("MainMusicVol", Mathf.Log10(value) * 20);
    }
    public void SetEffectAudioLevel(float value)
    {
        EffectMizer.SetFloat("ZaWarudo", Mathf.Log10(value) * 20);
    }
}
