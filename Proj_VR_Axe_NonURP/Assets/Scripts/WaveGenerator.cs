using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class WaveGenerator : MonoBehaviour
{
    public Transform[] spawnPoints;
    public List<WaveSO> waves;
    public Transform gate;
    private int enemiesAlive;
    public WaveDisplayerManager waveDisplayerManager;

    private void Start()
    {
        waveDisplayerManager = FindObjectOfType<WaveDisplayerManager>();
        StartCoroutine(SpawnWaves());
    }

    private IEnumerator SpawnWaves()
    {
        for (int i = 0; i < waves.Count; i++)
        {
            yield return new WaitUntil(() => enemiesAlive == 0);
            waveDisplayerManager.UpdateDisplayText("Wave: " + (i + 1));
            yield return new WaitForSeconds(waves[i].waveDelay);
            yield return StartCoroutine(SpawnWave(waves[i]));
        }
    }

    private IEnumerator SpawnWave(WaveSO wave)
    {
        foreach (EnemySettings es in wave.enemySettings)
        {
            for (int i = 0; i < es.enemyCount; i++)
            {
                yield return new WaitForSeconds(wave.respawnDelay);
                Transform spawnPoint = spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Length)];
                spawnPoint.GetComponent<EnemyParticleSpawn>().SpawnParticles();
                EnemyBehaviour enemy = Instantiate(es.enemyType, spawnPoint.position, spawnPoint.rotation).GetComponent<EnemyBehaviour>();
                enemy.SetDestination(gate);
                enemy.onDeath.AddListener(EnemyDied);
                enemiesAlive++;
                waveDisplayerManager.UpdateDisplayText("Remaining enemies: " + enemiesAlive);
            }
        }

    }

    public void GateDied()
    {
        StopAllCoroutines();
    }

    public void EnemyDied(Transform pos)
    {
        enemiesAlive--;
        waveDisplayerManager.UpdateDisplayText("Remaining enemies: " + enemiesAlive);
    }


}


