using UnityEngine;
using UnityEngine.Events;

public class Events
{
    [System.Serializable] public class EventEnemyDeath : UnityEvent <Transform> { }
}