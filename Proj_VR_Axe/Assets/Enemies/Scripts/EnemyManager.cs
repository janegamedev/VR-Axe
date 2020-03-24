using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPositions;
    public float timeForRespawn;

    private void Start()
    {
        foreach (var spawn in spawnPositions)
        {
            SpawnEnemy(spawn);
        }
    }

    private void SpawnEnemy(Transform spot)
    {
        EnemyBehaviour enemy = Instantiate(enemyPrefab, spot.position, Quaternion.identity).GetComponent<EnemyBehaviour>();
        enemy.spot = spot;
        enemy.onEnemyDeath.AddListener(EnemyDeath);
    }

    private void EnemyDeath(Transform spot)
    {
        StartCoroutine(SpawnEnemyWithDelay(spot));
    }

    private IEnumerator SpawnEnemyWithDelay(Transform spot)
    {
        yield return new WaitForSeconds(timeForRespawn);
        
        SpawnEnemy(spot);
    }
}
