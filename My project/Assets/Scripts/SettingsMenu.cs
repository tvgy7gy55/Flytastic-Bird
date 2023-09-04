using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public Slider slider;

    public Dropdown resolutionDropdown;

    public SettingsMenu settingsMenu;

    private static float savedVolume;

    Resolution[] resolutions;

    void Start()
    {
        //For music save

        audioMixer.SetFloat("Volume", PlayerPrefs.GetFloat("VolumeSave", savedVolume));

        //For slider save

        slider.value = GetVolume();

        //For resolution

        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currectResolutionIndex = 0;

        for(int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currectResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currectResolutionIndex;
        resolutionDropdown.RefreshShownValue();

    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];

        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetVolume(float volume)
    {
        savedVolume = volume;
        audioMixer.SetFloat("Volume", volume);
        PlayerPrefs.SetFloat("VolumeSave", savedVolume);
    }

    public static float GetVolume()
    {
        return PlayerPrefs.GetFloat("VolumeSave", savedVolume);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

}
