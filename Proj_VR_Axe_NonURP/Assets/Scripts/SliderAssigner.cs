using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderAssigner : MonoBehaviour
{
    public Slider volume;

    private void Awake()
    {
        volume = GetComponent<Slider>();
        volume.value = VolumeControl.Instance.volume;
        volume.onValueChanged.AddListener(OnValueChange);
    }

    public void OnValueChange(float value)
    {
        VolumeControl.Instance.SetLevel(value);
    }
}
