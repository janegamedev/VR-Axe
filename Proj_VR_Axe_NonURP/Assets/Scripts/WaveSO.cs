using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewWaveSO", menuName = "Wave")]
public class WaveSO : ScriptableObject
{
    public List<GameObject> enemyTypes;
    public List<int> enemyCounts;
}