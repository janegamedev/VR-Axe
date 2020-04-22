using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalHealth : MonoBehaviour, IReceiveDamage
{
    public int health;

    public Events.EventOnDeath portalDeath;
    public Events.EventOnHit portalHit;

    public Displayer waveDisplayerManager;

    public void Start()
    {
        waveDisplayerManager.UpdateHealthText("Health remaining: " + health);
    }

    public void GetHit()
    {
        health--;
        if (health <= 0)
        {
            waveDisplayerManager.UpdateHealthText("CRITICAL FALIURE!");
            portalDeath?.Invoke(transform);
        }
        else
        {
            waveDisplayerManager.UpdateHealthText("Health remaining: " + health);
            portalHit?.Invoke(transform);
        }
    }
}
