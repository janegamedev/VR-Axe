using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalHealth : MonoBehaviour, IReceiveDamage
{
    public int health;
    
    //public Transform spot;
    public Events.EventOnDeath portalDeath;
    public Events.EventOnHit portalHit;

    public void GetHit()
    {
        health--;
        //Debug.Log("Health remaining: " + health);
        if (health <= 0)
        {
            //Game Over
            portalDeath?.Invoke(transform);
        }
        else
        {
            portalHit?.Invoke(transform);
        }
    }
}
