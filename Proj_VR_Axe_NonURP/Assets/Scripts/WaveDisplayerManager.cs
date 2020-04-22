using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveDisplayerManager : MonoBehaviour
{
    public List<Text> displayTexts;

    public void UpdateDisplayText(string text)
    {
        foreach (Text displayText in displayTexts)
        {
            displayText.text = text;
        }
    }
}
