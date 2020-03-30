using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnemyBehaviour : MonoBehaviour, IReceiveDamage
{
    public Transform spot;
    public Events.EventEnemyDeath onEnemyDeath;
    private NavMeshAgent agent;

    public GameObject tempEndLocation;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        Init(tempEndLocation.transform.position);
    }

    public void Init(Vector3 position)
    {
        if (agent.enabled)
        {
            if (agent.isOnNavMesh)
            {                
                Debug.Log("Setting destination");
                agent.SetDestination(position);
            }
            else
            {
                Debug.Log("Boop");
                //agent.SetDestination(position);
            }
        }
    }

    private void Update()
    {
        if (IsAtDestination())
        {
            DoDamage();
        }
    }

    public void DoDamage()
    {
        tempEndLocation.GetComponent<IReceiveDamage>().GetHit();
        Destroy(gameObject);
    }

    public void GetHit()
    {
        Destroy(gameObject);
        onEnemyDeath?.Invoke(spot);
    }
    
    private bool IsAtDestination()
    {
        if (Vector3.Distance(transform.position, tempEndLocation.transform.position) < Random.Range(1, 3))
            return true;
        else
        {
            return false;
        }
    }
}

public interface IReceiveDamage
{
    void GetHit();
}