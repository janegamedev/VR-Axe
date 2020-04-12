using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class WaveGenerator : MonoBehaviour
{
    public Transform[] spawnPoints;
    public List<WaveSO> waves;

    public int enemiesAlive;

    private void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    private IEnumerator SpawnWaves()
    {
        foreach (WaveSO wave in waves)
        {
            yield return new WaitUntil(() => enemiesAlive == 0);
            yield return new WaitForSeconds(wave.waveDelay);
            StartCoroutine(SpawnWave(wave));
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
                EnemyBehaviour enemy = Instantiate(es.enemyType, spawnPoint.position, spawnPoint.rotation).GetComponent<EnemyBehaviour>();
                enemy.onDeath.AddListener(EnemyDied);
                enemiesAlive++;
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
    }


}


