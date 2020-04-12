using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewWaveSO", menuName = "Wave")]
public class WaveSO : ScriptableObject
{
    public List<EnemySettings> enemySettings;
    public float respawnDelay;
    public float waveDelay;
}

[System.Serializable]
public class EnemySettings
{
    public GameObject enemyType;
    public int enemyCount;
}
