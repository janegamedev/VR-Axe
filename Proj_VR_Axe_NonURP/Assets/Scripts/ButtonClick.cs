using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{
    public AudioSource buttonPress;

    public void PlaySound()
    {
        buttonPress.Play();
    }
}
