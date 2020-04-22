using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Displayer : MonoBehaviour
{
    public List<Text> waveTexts;
    public Text portalHealth;

    public void UpdateWaveText(string text)
    {
        foreach (Text waveText in waveTexts)
        {
            waveText.text = text;
        }
    }

    public void UpdateHealthText(string text)
    {
        portalHealth.text = text;
    }
}
