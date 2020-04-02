using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour, IReceiveDamage
{
    public Transform destination;
    public Events.EventOnDeath onDeath;
    private NavMeshAgent agent;

    //TODO: Inject objective location through constructor
    

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        SetAnimation();
    }

    private void SetAnimation()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetFloat("InputVertical", .5f);
        anim.SetFloat("InputMagnitude", .5f);
    }

    public void SetDestination(Transform spot)
    {
        destination = spot;
        if (agent.enabled)
        {
            if (agent.isOnNavMesh)
            {                
                agent.SetDestination(destination.position);
            }
            else
            {
                Debug.LogWarning("Agent is not on nav mesh");
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
        destination.gameObject.GetComponent<IReceiveDamage>().GetHit();
        Destroy(gameObject);
    }

    public void GetHit()
    {
        //onDeath?.Invoke(destination);
        Destroy(gameObject);
    }
    
    private bool IsAtDestination()
    {
        if (Vector3.Distance(transform.position, destination.transform.position) < UnityEngine.Random.Range(1, 3))
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