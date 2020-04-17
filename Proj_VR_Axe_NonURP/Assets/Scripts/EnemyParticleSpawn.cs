using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class EnemyParticleSpawn : MonoBehaviour
{
    public VisualEffect spawnEffect;
    public float delay;

  public void SpawnParticles()
    {
        spawnEffect.SendEvent("ParticleOnPlay");
        Invoke("EndParticles", delay);
    }

    public void EndParticles()
    {

        spawnEffect.SendEvent("ParticleOnStop");
    }
}
