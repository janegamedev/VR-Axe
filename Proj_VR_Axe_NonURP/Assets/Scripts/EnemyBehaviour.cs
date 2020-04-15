using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour, IReceiveDamage
{
    public Events.EventOnDeath onDeath;
    public Events.EventOnHit onHit;
    private NavMeshAgent agent;
    public Transform destination;

    //TODO: Inject objective location through constructor
    

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        SetAnimation();
    }

    private void SetAnimation()
    {
        Animator anim = GetComponent<Animator>();
        anim.speed = 0.65f;
        anim.SetFloat("InputVertical", .5f);
        anim.SetFloat("InputMagnitude", .5f);
    }

    public void SetDestination(Transform spot)
    {
        destination = spot;
        agent.SetDestination(spot.position);
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
        onDeath?.Invoke(transform);
        onHit?.Invoke(destination);
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