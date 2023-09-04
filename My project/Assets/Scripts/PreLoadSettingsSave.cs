using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PreLoadSettingsSave : MonoBehaviour
{
    public AudioMixer audioMixer;

    void Start()
    {
        audioMixer.SetFloat("Volume", SettingsMenu.GetVolume());    
    }
}