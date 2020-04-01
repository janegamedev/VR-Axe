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
        //mixer.SetFloat("MusicVol", sliderValue);
    }

    public float GetVolume()
    {
        float value;
        bool result = mixer.GetFloat("MusicVol", out value);

        if (result)
        {
            Debug.Log(Mathf.Pow(10, value) * 20);
            return Mathf.Pow(10, value) * 20;
            
        }

        else
        {
            Debug.Log("Set to zero");
            return 0f;
        }
    }
}
