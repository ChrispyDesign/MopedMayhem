using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.IO;
using UnityEngine;

public class _TestGameOptionsManager : MonoBehaviour {

    public Resolution[] resolutions;
    public Dropdown ScreenResolution;
    public Dropdown GraphicsQuality;
    public Dropdown AntiAliasing;
    public Dropdown ShadowQuality;
    public Dropdown VerticalSyn;
    public Toggle FullScreen;
    public Toggle ShadowsOn;
    public Toggle AnisoFilter;
    public _TestGameOptionsClass Settings;
    public AudioMixer MainMixer;
    public AudioMixer EffectMixer;
    public Button SaveSettings;

    public void OnEnable()
    {
        resolutions = Screen.resolutions;
        Settings = new _TestGameOptionsClass();
        ScreenResolution.onValueChanged.AddListener(delegate { OnScreenResolutionChange(); });
        GraphicsQuality.onValueChanged.AddListener(delegate { OnTextureQualityChange(); });
        AntiAliasing.onValueChanged.AddListener(delegate { OnAntiAliasingChange(); });
        ShadowQuality.onValueChanged.AddListener(delegate { OnShadowQualityChange(); });
        FullScreen.onValueChanged.AddListener(delegate { OnFullScreenChange(); });
        VerticalSyn.onValueChanged.AddListener(delegate { OnVSyncChange(); });
        SaveSettings.onClick.AddListener(delegate { SaveChanges(); });

        foreach (Resolution res in resolutions)
        {
            ScreenResolution.options.Add(new Dropdown.OptionData(res.ToString()));
        }
        LoadSettings();
    }

    public void OnVSyncChange()
    {
        QualitySettings.vSyncCount = Settings.vSync = VerticalSyn.value;
    }

    public void OnShadowsEnabled() {
        if (ShadowsOn.isOn) {
            QualitySettings.shadows = UnityEngine.ShadowQuality.Disable;
        }
        else {
            QualitySettings.shadows = UnityEngine.ShadowQuality.All;
        }
    }

    public void OnFilterChange()
    {
        if (AnisoFilter.isOn)
        {
            QualitySettings.anisotropicFiltering = AnisotropicFiltering.Disable;
        }
        else
        {
            QualitySettings.anisotropicFiltering = AnisotropicFiltering.Enable;
        }
    }

    public void OnTextureQualityChange()
    {
        QualitySettings.masterTextureLimit = Settings.textureQuality = GraphicsQuality.value;
    }

    public void OnShadowQualityChange()
    {
        switch (ShadowQuality.value) {
            case 0:
                QualitySettings.shadowResolution = ShadowResolution.Low;
                break;
            case 1:
                QualitySettings.shadowResolution = ShadowResolution.Medium;
                break;
            case 2:
                QualitySettings.shadowResolution = ShadowResolution.High;
                break;
            case 3:
                QualitySettings.shadowResolution = ShadowResolution.VeryHigh;
                break;
        }
    }

    public void OnAntiAliasingChange()
    {
        QualitySettings.antiAliasing = Settings.antiAliasing = (int)Mathf.Pow(2f, AntiAliasing.value);
    }

   

    public void OnFullScreenChange()
    {
       Settings.fullscreen = Screen.fullScreen = FullScreen.isOn;
    }

    public void OnScreenResolutionChange()
    {
        Screen.SetResolution(resolutions[ScreenResolution.value].width, resolutions[ScreenResolution.value].height, false);
    }

    public void SetMainAudioLevel(float value)
    {
        MainMixer.SetFloat("MainMusicVol", Mathf.Log10(value) * 20);
    }
    public void SetEffectAudioLevel(float value)
    {
        EffectMixer.SetFloat("MenClick", Mathf.Log10(value) * 20);
    }

    public void ApplyChanges() {
        SaveChanges();
    }

    public void SaveChanges() {
        string jsonData = JsonUtility.ToJson(Settings, true);
        File.WriteAllText(Application.persistentDataPath + "/Settings.json", jsonData);
    }

    public void LoadSettings() {
        Settings = JsonUtility.FromJson<_TestGameOptionsClass>(File.ReadAllText(Application.persistentDataPath + "/Settings.json"));
        AntiAliasing.value = Settings.antiAliasing;
        VerticalSyn.value = Settings.vSync; 
        GraphicsQuality.value = Settings.textureQuality;
        ScreenResolution.value = Settings.resolutionIndex;
        FullScreen.isOn = Settings.fullscreen;
        ScreenResolution.RefreshShownValue();
    }
}


