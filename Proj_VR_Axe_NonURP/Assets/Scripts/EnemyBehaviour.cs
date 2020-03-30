using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour, IReceiveDamage
{
    public Transform spot;
    public Events.EventEnemyDeath onEnemyDeath;
    private NavMeshAgent agent;

    public Transform tempEndLocation;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
//        NavMeshHit closestHit;
//        if( NavMesh.SamplePosition(  transform.position, out closestHit, 500, 1 ) ){
//            transform.position = closestHit.position;
//            //go.AddComponent<NavMeshAgent>();
//            //TODO
//        }
//        else{
//            Debug.Log("...");
//        }
        Init(tempEndLocation.position);
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
//        if (!agent.isOnNavMesh)
//        {
//            agent.enabled = false;
//            agent.enabled = true;
//            Init(tempEndLocation.position);
//        }


        
    }

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