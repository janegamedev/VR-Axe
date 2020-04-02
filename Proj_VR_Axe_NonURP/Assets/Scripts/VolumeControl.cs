using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeControl: SingletonManager<VolumeControl>
{
    public AudioMixer mixer;
    
    public void SetLevel (float sliderValue)
    {
        mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
    }

    public float volume
    {
        get
        {
            if (mixer.GetFloat("MusicVol", out float value))
            {
                return Mathf.Pow(10, value) * 20;
            }
            else
            {
                return -1f;
            }
        }
    }
}
