using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public enum WaveManagerState
{
    Beginning, 
    SpawningWave, 
    Won, 
    Lost
}

public class WaveManager : MonoBehaviour
{
    private WaveManagerState state;
    public Transform[] spawnPoints;
    public List<WaveSO> waves;
    public float waveBreak;
    public float spawnBreak;
    public float spawnBreakError;
    public Transform gate;
    private int currentWave;

    private void Start()
    {
        state = WaveManagerState.Beginning;
        StartCoroutine(Begin());
    }

    private IEnumerator Begin()
    {
        for (currentWave = 0; currentWave < waves.Count; currentWave++)
        {
            yield return new WaitForSeconds(waveBreak);
            state = WaveManagerState.SpawningWave;
            StartCoroutine(SpawnWave(waves[currentWave]));
        }
        state = WaveManagerState.Won;
    }

    private IEnumerator SpawnWave(WaveSO wave)
    {
        Dictionary<GameObject, int> remainingPrefabs = new Dictionary<GameObject, int>();

        for (int i = 0; i < wave.enemyTypes.Count; i++)
        {
            remainingPrefabs.Add(wave.enemyTypes[i], wave.enemyCounts[i]);
        }

        while (remainingPrefabs.Values.Sum() > 0)
        {
            Transform spawnPoint = spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Length)];
            GameObject go = RandomFromRemaining(remainingPrefabs);
            EnemyBehaviour enemy = Instantiate(go, spawnPoint.position, spawnPoint.rotation).GetComponent<EnemyBehaviour>();
            enemy.SetDestination(gate);
            yield return new WaitForSeconds(spawnBreak + UnityEngine.Random.Range(-1f, 1f) * spawnBreakError);
        }
    }

    private static GameObject RandomFromRemaining(Dictionary<GameObject, int> dictOfRemaining)
    {
        int index = UnityEngine.Random.Range(0, dictOfRemaining.Count);
        dictOfRemaining[dictOfRemaining.ElementAt(index).Key]--;
        return dictOfRemaining.ElementAt(index).Key;
    }
}