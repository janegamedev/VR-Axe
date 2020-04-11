using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHitParticles : MonoBehaviour
{
    public GameObject particlePrefab;
    
    public void SpawnParticles()
    {
        GameObject go = Instantiate(particlePrefab, transform.position, Quaternion.LookRotation( Camera.main.transform.position - transform.position));
        Destroy(go, 1f);
    }

}
