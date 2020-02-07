using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour, IReceiveDamage
{
    public Transform spot;
    public Events.EventEnemyDeath onEnemyDeath;
    
    public void GetHit()
    {
        Destroy(gameObject);
        onEnemyDeath?.Invoke(spot);
    }
}

public interface IReceiveDamage
{
    void GetHit();
}