using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Audio;

public class _TestSliderMusic : MonoBehaviour, IPointerClickHandler
{
    public AudioMixer MainMixer;
    public AudioMixer EffectMizer;

    public AudioSource MenuSauce;
    public AudioClip ClickSauce;

    private void Start()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        PlayMainMenuClickSounds();
    }

    public void PlayMainMenuClickSounds()
    {
        MenuSauce.PlayOneShot(ClickSauce);

    }
    public void SetMainAudioLevel(float value)
    {
        MainMixer.SetFloat("MainMusicVol", Mathf.Log10(value) * 20);
    }
    public void SetEffectAudioLevel(float value)
    {
        EffectMizer.SetFloat("ZaWarudo", Mathf.Log10(value) * 20);
    }
}
