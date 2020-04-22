using UnityEngine;
using UnityEngine.Events;

public class Events
{
    [System.Serializable] public class EventOnDeath : UnityEvent <Transform> { }
    [System.Serializable] public class EventOnHit : UnityEvent <Transform> { }
    [System.Serializable] public class EventEnemySpawn : UnityEvent { }
    [System.Serializable] public class EventGameWon : UnityEvent { }
}