using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeControl: SingletonManager<VolumeControl>
{
    public AudioMixer mixer;
    
    public void SetLevel (float sliderValue)
    {
        //mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
        mixer.SetFloat("MusicVol", sliderValue);
    }

    public float GetVolume()
    {
        float value;
        bool result = mixer.GetFloat("masterVol", out value);

        if (result)
        {
            return value;
        }

        else
        {
            return 0f;
        }
    }
}
