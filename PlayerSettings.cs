using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PlayerSettings : MonoBehaviour
{
    // Initializing variables.
    [Header("Visual Components:")]
    [SerializeField] private GameObject musicObject;
    [SerializeField] private Slider masterVolumeSlider;
    [SerializeField] private TextMeshProUGUI masterVolumeStatusText;
    [SerializeField] private Slider musicVolumeSlider;
    [SerializeField] private TextMeshProUGUI musicVolumeStatusText;
    [SerializeField] private Slider sfxVolumeSlider;
    [SerializeField] private TextMeshProUGUI sfxVolumeStatusText;
    [SerializeField] private Slider dialogueVolumeSlider;
    [SerializeField] private TextMeshProUGUI dialogueVolumeStatusText;
    [SerializeField] private TMP_Dropdown resolutionDropdown;
    [SerializeField] private TMP_Dropdown displayModeDropdown;
    [SerializeField] private TMP_Dropdown qualityDropdown;
    [SerializeField] private TMP_Dropdown maxFPSDropdown;

    [Header("Audio Components:")]
    [SerializeField] private AudioSource buttonSFX;
    [SerializeField] private AudioSource music;
    [SerializeField] private Volume globalVolume;
    [SerializeField] private AudioMixer mixer;
    [HideInInspector] private bool initializing = true;
    [HideInInspector] private Resolution[] resolutions;

    // Initializing variables and text upon start.
    private void Start()
    {
        // Finding the current list of possible resolutions based on the current system running the game.
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<String> options = new List<String>();
        int currentResolutionIndex = 0;

        for(int i = 0; i < resolutions.Length; i++)
        {
            String option = resolutions[i].width + " x " + resolutions[i].height + " @ " + resolutions[i].refreshRateRatio + "hz";
            options.Add(option);

            // Finding the resolution that matches the current system default.
            if(resolutions[i].width == Screen.width && resolutions[i].height == Screen.height
                && resolutions[i].refreshRateRatio.value == Screen.currentResolution.refreshRateRatio.value)
            {
                currentResolutionIndex = i;
            }
        }

        // Showing the list of available resolutions in the dropdown menu. Also setting the current resolution to the one that matches the system default.
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        // Resetting the current resolution based on past player choice.
        Resolution resolution = resolutions[PlayerPrefs.GetInt("resolution")];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        resolutionDropdown.value = PlayerPrefs.GetInt("resolution");
        resolutionDropdown.RefreshShownValue();

        // Setting the quality setting based on past player choice.
        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("qualityLevel"));
        qualityDropdown.value = PlayerPrefs.GetInt("qualityLevel");
        qualityDropdown.RefreshShownValue();

        // Setting the window-type setting based on past player choice.
        SetWindowType(PlayerPrefs.GetInt("windowType"));

        // Setting the audio settings based on past player choices.
        masterVolumeSlider.value = 1f;
        musicVolumeSlider.value = 1f;
        sfxVolumeSlider.value = 1f;
        dialogueVolumeSlider.value = 1f;
        masterVolumeSlider.value = PlayerPrefs.GetFloat("masterVolume");
        musicVolumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
        sfxVolumeSlider.value = PlayerPrefs.GetFloat("sfxVolume");
        dialogueVolumeSlider.value = PlayerPrefs.GetFloat("dialogueVolume");
        masterVolumeStatusText.text = Mathf.RoundToInt(masterVolumeSlider.value * 100) + "%";
        musicVolumeStatusText.text = Mathf.RoundToInt(musicVolumeSlider.value * 100) + "%";
        sfxVolumeStatusText.text = Mathf.RoundToInt(sfxVolumeSlider.value * 100) + "%";
        dialogueVolumeStatusText.text = Mathf.RoundToInt(dialogueVolumeSlider.value * 100) + "%";

        // Setting the maximum FPS setting to the default setting.
        Application.targetFrameRate = -1;
        SetMaxFPS(PlayerPrefs.GetInt("maxFPS"));
        maxFPSDropdown.value = PlayerPrefs.GetInt("maxFPS");
        maxFPSDropdown.RefreshShownValue();

        initializing = false;
    }

    // Handling the setting of the master volume.
    public void SetMasterVolume()
    {
        masterVolumeStatusText.text = Mathf.RoundToInt(masterVolumeSlider.value * 100) + "%";
        mixer.SetFloat("masterVolume", Mathf.Log10(masterVolumeSlider.value) * 20);
        PlayerPrefs.SetFloat("masterVolume", masterVolumeSlider.value);
    }

    // Handling the setting of the music volume.
    public void SetMusicVolume()
    {
        musicVolumeStatusText.text = Mathf.RoundToInt(musicVolumeSlider.value * 100) + "%";
        mixer.SetFloat("musicVolume", Mathf.Log10(musicVolumeSlider.value) * 20);
        PlayerPrefs.SetFloat("musicVolume", musicVolumeSlider.value);
    }

    // Handling the setting of the SFX volume.
    public void SetSFXVolume()
    {
        sfxVolumeStatusText.text = Mathf.RoundToInt(sfxVolumeSlider.value * 100) + "%";
        mixer.SetFloat("sfxVolume", Mathf.Log10(sfxVolumeSlider.value) * 20);
        PlayerPrefs.SetFloat("sfxVolume", sfxVolumeSlider.value);
    }

    // Handling the setting of the dialogue volume.
    public void SetDialogueVolume()
    {
        dialogueVolumeStatusText.text = Mathf.RoundToInt(dialogueVolumeSlider.value * 100) + "%";
        mixer.SetFloat("dialogueVolume", Mathf.Log10(dialogueVolumeSlider.value) * 20);
        PlayerPrefs.SetFloat("dialogueVolume", dialogueVolumeSlider.value);
    }

    // Handling the setting of the game's resolution.
    public void SetResolution(int resolutionIndex)
    {
        if(!initializing)
            buttonSFX.Play();

        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        PlayerPrefs.SetInt("resolution", resolutionIndex);
        PlayerPrefs.Save();

        resolutionDropdown.value = resolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    // Handling the setting of the game's quality level.
    public void SetQuality(int quality)
    {
        if(!initializing)
            buttonSFX.Play();

        QualitySettings.SetQualityLevel(quality);
        PlayerPrefs.SetInt("qualityLevel", quality);
        PlayerPrefs.Save();

        qualityDropdown.value = quality;
        qualityDropdown.RefreshShownValue();
    }

    // Handling the setting of the game's window-type.
    public void SetWindowType(int type)
    {
        if(!initializing)
            buttonSFX.Play();

        if (type == 0)
            Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;

        if(type == 1)
            Screen.fullScreenMode = FullScreenMode.FullScreenWindow;

        if(type == 2)
            Screen.fullScreenMode = FullScreenMode.Windowed;

        PlayerPrefs.SetInt("windowType", type);
        PlayerPrefs.Save();

        displayModeDropdown.value = type;
        displayModeDropdown.RefreshShownValue();
    }

    // Handling the setting of the game's colorblind filter.
    public void SetMaxFPS(int fps)
    {
        if(!initializing)
            buttonSFX.Play();

        switch(fps)
        {
            case 0:
                Application.targetFrameRate = -1;
                break;
            case 1:
                Application.targetFrameRate = 240;
                break;
            case 2:
                Application.targetFrameRate = 144;
                break;
            case 3:
                Application.targetFrameRate = 120;
                break;
            case 4:
                Application.targetFrameRate = 60;
                break;
            case 5:
                Application.targetFrameRate = 30;
                break;
        }

        PlayerPrefs.SetInt("maxFPS", fps);
        PlayerPrefs.Save();

        maxFPSDropdown.value = fps;
        maxFPSDropdown.RefreshShownValue();
    }
}