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
    private Displayer waveDisplayerManager;
    private int enemiesInCurrentWave;

    private void Start()
    {
        waveDisplayerManager = FindObjectOfType<Displayer>();
        StartCoroutine(SpawnWaves());
    }

    private IEnumerator SpawnWaves()
    {
        for (int i = 0; i < waves.Count; i++)
        {
            yield return new WaitUntil(() => enemiesAlive == 0);
            waveDisplayerManager.UpdateWaveText("Wave: " + (i + 1) + "/" + waves.Count);
            yield return StartCoroutine(WaitForSeconds(waves[i].waveDelay));
            yield return StartCoroutine(SpawnWave(waves[i]));
        }
    }

    public IEnumerator WaitForSeconds(float seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            waveDisplayerManager.UpdateWaveText((seconds - i).ToString());
            yield return new WaitForSeconds(1f);
        } 
    }

    private IEnumerator SpawnWave(WaveSO wave)
    {
        enemiesInCurrentWave = 0;
        wave.enemySettings.ForEach(es => enemiesInCurrentWave = enemiesInCurrentWave + es.enemyCount);
        waveDisplayerManager.UpdateWaveText("Remaining enemies: " + enemiesInCurrentWave + "/" + enemiesInCurrentWave);

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
        waveDisplayerManager.UpdateWaveText("Remaining enemies: " + enemiesAlive + "/" + enemiesInCurrentWave);
    }


}


