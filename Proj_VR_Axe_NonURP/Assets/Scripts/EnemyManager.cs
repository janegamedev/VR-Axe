
using System.Collections;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;
    public float timeForRespawn;
    public Transform gate;

    private void Start()
    {
        StartCoroutine(RespawnEnemy());
    }

    private IEnumerator RespawnEnemy()
    {
        while(true)
        {
            if (gate.GetComponent<PortalHealth>().health < 0)
            {
                yield break;
            }

            yield return new WaitForSeconds(timeForRespawn);
        
            Transform spawnPoint = spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Length)];

            SpawnEnemy(spawnPoint);
        }
    }

    private void SpawnEnemy(Transform point)
    {
        EnemyBehaviour enemy = Instantiate(enemyPrefab, point.position, point.rotation).GetComponent<EnemyBehaviour>();
        enemy.SetDestination(gate);
    }
}
